using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(config =>
//{
//    config.AddSecurityDefinition("basic", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Basic Authentication & Authorization by using this Basic Scheme",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        Scheme = "basic"
//    });


//    config.AddSecurityRequirement(new OpenApiSecurityRequirement
//            {
//                {
//                    new OpenApiSecurityScheme
//                    {
//                        Reference = new OpenApiReference
//                        {
//                            Type = ReferenceType.SecurityScheme,
//                            Id = "basic"
//                        },
//                    },
//                    new string[] {}
//                }
//            });

//    config.ResolveConflictingActions(x => x.First());
//});

//builder.Services.AddAuthentication("BasicAuthentication")
//    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
