using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Neoxim.Platform.Api.Helpers;
using Neoxim.Platform.Core.DI;
using Neoxim.Platform.Infrastructure.DI;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ActiveSubscription", builder => builder.RequireAuthenticatedUser().RequireClaim("subscription", "active"));
    options.AddPolicy("PremiumLicensesOnly", builder => builder.RequireAuthenticatedUser().RequireClaim("license", "premium"));
});

// Register all dependencies
builder.Services
       .Core()
       .Infrastructure(builder.Configuration)
       .AddScoped<IClaimsTransformation, AuthClaimsTransformationHelper>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(cfg =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorizaation header using the bearer scheme. \r\n\r\nEnter 'Bearer' [space] TOKEN in the text input bellow\r\n\r\nExample: Bearer e.ejnifnfe1232",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        },
        Scheme = "Bearer" // oauth2
    };

    // Auth Definition
    cfg.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    // Auth Requirement
    cfg.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            jwtSecurityScheme, new List<string>()
        }
    });

    // Doc
    cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "NeoXim - Platform API", Version = "v1" });
    var filePath = Path.Combine(AppContext.BaseDirectory, "Neoxim.Platform.Api.xml");
    cfg.IncludeXmlComments(filePath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// DB Migrations
app.ApplyEfMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
