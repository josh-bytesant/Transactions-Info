using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Transactions.Info.Extra.API.Helpers.Handlers;
using Transactions.Info.Infrastructure.Data.DBContexts;
using Transactions.Info.Infrastructure.Data.SeedData;
using static Transactions.Info.Infrastructure.ConfigureServices.ConfigureServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Basic Authentication & Authorization by using this Basic Scheme",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic"
    });


    config.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "basic"
                        },
                    },
                    new string[] {}
                }
            });

    config.ResolveConflictingActions(x => x.First());
});

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AccountInfoDbContext>();
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        await context.Database.MigrateAsync();
        await AccountInfoContextSeed.SeedAsync(context);
        AccountInfoComplexDataSeed.Initialize(context);
    }
    catch (System.Exception ex)
    {

        logger.LogError(ex, "An error occuredduring migraion");
    }
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
