using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Hasher;
using AUD9001.ApplicationServices.API.Validators;
using AUD9001.ApplicationServices.Components.OpenWeather;
using AUD9001.ApplicationServices.Mappings;
using AUD9001.Authentication;
using AUD9001.DataAccess;
using AUD9001.DataAccess.CQRS;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AUD9001
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRolePolicy",
                    policy => policy.RequireRole("Administrator"));
            });

            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddProcessRequestValidator>());

            //poni¿sze pozwala wejsc do kontrolera pomimo b³ednego requestu
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();

            services.AddTransient<IWeatherConnector, WeatherConnector>();

            services.AddAutoMapper(typeof(ProcessesProfile).Assembly);

            services.AddMediatR(typeof(ResponseBase<>));

            services.AddScoped(serviceType: typeof(IRepository<>), implementationType: typeof(Repository<>));

            services.AddTransient<IHasher, Hasher>();

            services.AddDbContext<AUD9001StorageContext>(
                opt =>
                opt.UseSqlServer(this.Configuration.GetConnectionString("AUD9001DatabaseConnection"))
                    .LogTo(Console.WriteLine));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AUD9001", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AUD9001 v1"));
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
