using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Neoxim.Platform.Api.Constants;
using Neoxim.Platform.Core.AppSettings;
using Swashbuckle.AspNetCore.SwaggerGen;

public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
        private readonly OAuth2AppSetting _oAuth2AppSetting;
    public ConfigureSwaggerGenOptions(IOptions<OAuth2AppSetting> options)
    {
        _oAuth2AppSetting = options.Value;
    }


    public void Configure(SwaggerGenOptions options)
    {
        options.OperationFilter<AuthorizeOperationFilter>();

        options.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.OAuth2,

            Flows = new OpenApiOAuthFlows
            {
                AuthorizationCode = new OpenApiOAuthFlow
                {
                    AuthorizationUrl = new Uri($"{_oAuth2AppSetting.Authority}/connect/authorize"),
                    TokenUrl = new Uri($"{_oAuth2AppSetting.Authority}/connect/token"),
                    Scopes = ClaimsConstant.Scopes.Dico
                }
            },
            Description = "Neoxim Server OpenId Security Scheme"
        });
    }
}

public class AuthorizeOperationFilter : IOperationFilter
{
    private const string SCHEME = "OAuth2";

    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if(context.MethodInfo == null)
            return;

        var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() || context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

        if (hasAuthorize)
        {
            operation.Responses.Add(StatusCodes.Status401Unauthorized.ToString(), new OpenApiResponse { Description = nameof(HttpStatusCode.Unauthorized) });
            operation.Responses.Add(StatusCodes.Status403Forbidden.ToString(), new OpenApiResponse { Description = nameof(HttpStatusCode.Forbidden) });

            operation.Security = new List<OpenApiSecurityRequirement>();

            var oauth2SecurityScheme = new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = SCHEME },
            };

            operation.Security.Add(new OpenApiSecurityRequirement()
            {
                [oauth2SecurityScheme] = new[] { SCHEME }
            });
        }
    }
}
