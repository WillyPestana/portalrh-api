using Application.Business;
using Core.Business;
using Core.Repository;
using Core.Services;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.Identity.Web;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace PortalKalendaeAPI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Configure Services

            var modelBuilder = new ODataConventionModelBuilder();

            //DbContexts
            

            //Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });
            });

            //Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);

            services.AddControllers();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Portal RH API",
                    Description = "Developed by Willy Pestana - Owner @ Willy Pestana",
                    Contact = new OpenApiContact { Name = "Willy Pestana", Email = "willy.pestana@hotmail.com" },
                    License = new OpenApiLicense { Name = "WILLY PESTANA", Url = new Uri("https://github.com/WillyPestana") }
                });

                // Configure authentication for Swagger
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri($"{configuration["AzureAd:Instance"]}{configuration["AzureAd:TenantId"]}/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri($"{configuration["AzureAd:Instance"]}{configuration["AzureAd:TenantId"]}/oauth2/v2.0/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                { $"{configuration["AzureAd:Audience"]}/UserAccess", "User Access" }
                            }
                        }
                    }
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            },
                            Scheme = "oauth2",
                            Name = "oauth2",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            //OData
            services.AddControllers().AddOData(
                options => options.EnableQueryFeatures(null).AddRouteComponents(
                    routePrefix: "odata",
                    model: modelBuilder.GetEdmModel())).AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    });

            //SignalR
            services.AddSignalR();

            //Api Endpoints Configuration
            services.AddEndpointsApiExplorer();

            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("PortalRH", builder =>
                {
                    string[]? corsOrigins = configuration.GetSection("PortalRH:CorsOrigins").Get<string[]>();

                    if (corsOrigins != null)
                    {
                        builder.WithOrigins(corsOrigins)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    }
                });
            });

            //Repository
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));       

            //Configs
            services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);          

            //Business
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IBusinessDevelopmentBusiness, BusinessDevelopmentBusiness>();

            //Service

            #endregion
        }
    }
}
