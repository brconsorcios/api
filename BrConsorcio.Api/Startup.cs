using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BrConsorcio.Api.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Text;
using System;
using Swashbuckle.AspNetCore.Swagger;

using Microsoft.EntityFrameworkCore;
using BrConsorcio.Api.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using BrConsorcio.Api.Helpers;
using BrConsorcio.Api.Models;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using BrConsorcio.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BrConsorcio.Api.Models.AnaliseCredito;
using Serilog;

namespace BrConsorcio.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        //public IConfigurationRoot Configuration { get; set; }

        private const string SecretKey = "comprefacilOTriunfo19";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var ligado = Boolean.Parse(Configuration.GetSection("LogApp").GetSection("Ligado").Value);
            var pasta = Configuration.GetSection("LogApp").GetSection("Pasta").Value;

            if (ligado == true)
            {
                Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(pasta, rollingInterval: RollingInterval.Day)
               .CreateLogger();
            }
            Log.Information("{p} {e}-> {m}", "Startup".PadRight(30), "ConfigureServices".PadRight(30), "Início da aplicação");

            //services.AddApplicationInsightsTelemetry(Configuration);

            // Add framework services.
            services.AddOptions();

            // Configuração para buscar os parametros no arquivo appsettings.json.
            services.Configure<BrConsorcioConfig>(Configuration.GetSection("BrConsorcioConfig"));
            services.Configure<PagConsorcio>(Configuration.GetSection("PagConsorcio"));
            services.Configure<Provider>(Configuration.GetSection("Provider"));
            services.Configure<Exp_WebAPI>(Configuration.GetSection("Exp_WebAPI"));
            services.Configure<EmailConfigModel>(Configuration.GetSection("EmailConfig"));
            services.Configure<EmailWebCredito>(Configuration.GetSection("EmailWebCredito"));
            services.Configure<ConfigEmailSoliciteContato>(Configuration.GetSection("ConfigEmailSoliciteContato"));
            services.Configure<BRApi>(Configuration.GetSection("BRApi"));
            services.Configure<CompApi>(Configuration.GetSection("CompApi"));
            services.Configure<RDStationApi>(Configuration.GetSection("RDStationApi"));
            //services.AddDbContext<BrConsorcioContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BrConsorcioDbConn")));

            // Make authentication compulsory across the board (i.e. shut
            // down EVERYTHING unless explicitly opened up).
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            // Use policy auth.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim("UserPolicy", "user"));
            });
            //  services.AddAuthorization();

            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {

                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });


            // Add framework services.
            //services.AddMvc();

            // Add our repository type

            services.AddScoped<IBrConsorcio, Services.BrConsorcio>();
            services.AddScoped<IEmailService, Services.EmailService>();
            services.AddScoped<ICompApiService, Services.CompApiService>();
            services.AddScoped<IRDStation, Services.RDStationApiService>();
            services.AddScoped<IBoletoAvulso, Services.BoletoAvulso>();
            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "BrConsorcio API",

                });
            });

            services.ConfigureSwaggerGen(options =>
            {
                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            services.Configure<GzipCompressionProviderOptions>(
              options => options.Level = CompressionLevel.Optimal);

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };
            services.AddAuthentication(options =>
            {

                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Audience = "http://localhost:5001/";
                options.TokenValidationParameters = tokenValidationParameters;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // Shows UseCors with CorsPolicyBuilder.
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseStaticFiles();
            app.UseResponseCompression();
            app.UseAuthentication();
            app.UseMvc();
        }

        public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
        {
            public void Apply(Operation operation, OperationFilterContext context)
            {
                var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
                var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
                var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

                if (isAuthorized && !allowAnonymous)
                {
                    if (operation.Parameters == null)
                        operation.Parameters = new List<IParameter>();

                    operation.Parameters.Add(new NonBodyParameter
                    {
                        Name = "Authorization",
                        In = "header",
                        Description = "Bearer Access Token",
                        Required = true,
                        Type = "string"
                    });
                }
            }
        }
    }
}
