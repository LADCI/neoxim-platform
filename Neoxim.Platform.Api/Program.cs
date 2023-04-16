using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Neoxim.Platform.Api.Constants;
using Neoxim.Platform.Api.Helpers;
using Neoxim.Platform.Core.AppSettings;
using Neoxim.Platform.Core.DI;
using Neoxim.Platform.Infrastructure.DI;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                // base-address of your identityserver
                options.Authority = builder.Configuration.GetValue<string>("OAuth2:Authority");
                options.Audience = builder.Configuration.GetValue<string>("OAuth2:Audience");

                // audience is optional, make sure you read the following paragraphs
                // to understand your options
                options.TokenValidationParameters.ValidateAudience = false;

                // it's recommended to check the type header to avoid "JWT confusion" attacks
                options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
            });

// Claims-Based Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(ClaimsConstant.Type.ADMIN, policy => policy.RequireAuthenticatedUser().RequireClaim(ClaimsConstant.Type.ADMIN, ClaimsConstant.Value.ADMIN));
    options.AddPolicy(ClaimsConstant.Type.DOWNLOAD, policy => policy.RequireAuthenticatedUser().RequireClaim(ClaimsConstant.Type.DOWNLOAD, ClaimsConstant.Value.DOWNLOAD));
    options.AddPolicy(ClaimsConstant.Type.UPLOAD, policy => policy.RequireAuthenticatedUser().RequireClaim(ClaimsConstant.Type.UPLOAD, ClaimsConstant.Value.UPLOAD));
    options.AddPolicy(ClaimsConstant.Type.WRITE, policy => policy.RequireAuthenticatedUser().RequireClaim(ClaimsConstant.Type.WRITE, ClaimsConstant.Value.WRITE));
    options.AddPolicy(ClaimsConstant.Type.READ, policy => policy.RequireAuthenticatedUser().RequireClaim(ClaimsConstant.Type.READ, ClaimsConstant.Value.READ));
    options.AddPolicy(ClaimsConstant.Type.SUBSCRIPTION_ACTIVE, policy => policy.RequireAuthenticatedUser().RequireClaim(ClaimsConstant.Type.SUBSCRIPTION_ACTIVE, ClaimsConstant.Value.SUBSCRIPTION));
});

// Options
builder.Services
    .Configure<OAuth2AppSetting>(builder.Configuration.GetSection("OAuth2"));

// Register all dependencies
builder.Services
       .Core()
       .Infrastructure(builder.Configuration)
       .AddScoped<IClaimsTransformation, AuthClaimsTransformationHelper>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger
builder.Services
        .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>()
        .AddSwaggerGen(cfg =>
        {
            cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "NeoXim - Platform API", Version = "v1" });
            var filePath = Path.Combine(AppContext.BaseDirectory, "Neoxim.Platform.Api.xml");
            cfg.IncludeXmlComments(filePath);
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint($"/swagger/v1/swagger.json", "Version 1.0");
        setup.OAuthClientId(builder.Configuration.GetValue<string>("OAuth2:ClientId"));
        setup.OAuthClientSecret(builder.Configuration.GetValue<string>("OAuth2:ClientSecret"));
        setup.OAuthAppName("NeoXim - Platform API");
        setup.OAuthScopeSeparator(" ");
        setup.OAuthUsePkce();
    });
}

// DB Migrations
app.ApplyEfMigrations();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/ping", () => "pong").Produces(StatusCodes.Status200OK).WithTags("Health");

app.Run();
