public partial class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ─────────────────────────────
        // Services
        // ─────────────────────────────

        builder.Services.AddControllers();

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Employee Department API",
                Version = "v1",
                Description = "Clean Architecture API with CQRS + FluentValidation"
            });

            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (File.Exists(xmlPath))
                options.IncludeXmlComments(xmlPath);
        });

        var app = builder.Build();

        // ─────────────────────────────
        // Middleware Pipeline
        // ─────────────────────────────

        // Swagger ALWAYS ON
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Department API v1");
            c.RoutePrefix = string.Empty; // Swagger at root
        });

        // Auto migrate DB (DEV usage but always executed here)
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.MigrateAsync();
        }

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }
}