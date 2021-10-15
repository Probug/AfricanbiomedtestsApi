using System;
using System.Text;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens; 
using Microsoft.EntityFrameworkCore;
using Africanbiomedtests.Helpers;
using Africanbiomedtests.Middleware;
using Africanbiomedtests.Services;
using Microsoft.OpenApi.Models;

namespace Africanbiomedtests
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x =>
           x.UseSqlServer("ConnectionStrings")
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)); 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                   builder =>
                   {
                       builder
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .SetIsOriginAllowed(origin => true) //allow any origin
                       .AllowCredentials(); //allow credentials
                   });
            });
            // services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "africanbiomedtests", Version = "v1" });
            });

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<INewbornService, NewbornService>();
            services.AddScoped<IHealthcareProviderService, HealthcareProviderService>();
            services.AddScoped<IMedTestService, MedTestService>();
            services.AddScoped<IMedTestOrderService, MedTestOrderService>();
            services.AddScoped<IMedTestResultService, MedTestResultService>();
            services.AddScoped<IEmailService, EmailService>();
        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // generated swagger json and swagger ui middleware
                app.UseSwagger(options =>
                                {
                                    options.PreSerializeFilters.Add((swagger, httpReq) =>
                                    {
                                        if (httpReq.Headers.ContainsKey("X-Forwarded-Host"))
                                        {
                                            //The httpReq.PathBase and httpReq.Headers["X-Forwarded-Prefix"] is what we need to get the base path.
                                            //For some reason, they are returning as null/blank. Perhaps this has something to do with how the proxy is configured which I don't have control.
                                            //For the time being, the base path is manually set here that corresponds to the APIM API Url Prefix.
                                            //In this case we set it to 'sample-app'. 

                                            var basePath = "sample-app";
                                            var serverUrl = $"{httpReq.Scheme}://{httpReq.Headers["X-Forwarded-Host"]}/{basePath}";
                                            swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = serverUrl } };
                                        }
                                    });
                                }
                            );
                app.UseSwaggerUI(options =>
                                    {
                                        options.RoutePrefix = string.Empty;
                                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Africanbiomedtests API");
                                    }
                                );

            }
            // migrate database changes on startup (includes initial db creation)
            context.Database.Migrate();
            app.UseRouting();

            // global cors policy
            app.UseCors("AllowAll");

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(x => x.MapControllers());

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
        }
    }
}
