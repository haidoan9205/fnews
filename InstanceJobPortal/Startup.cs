using BLL.BussinessLogics;
using BLL.Helpers;
using BLL.Interfaces;
using DAL;
using DAL.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstanceJobPortal
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
            services.AddControllers();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingsSection);

            services.AddDbContext<DataContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var appSettings = appSettingsSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Instance Job Portal API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                         Reference = new OpenApiReference
                         {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                         }
                     },
                          new string[] { }
                   }
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            services.AddCors();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IApplicantLogic, ApplicantLogic>();
            services.AddScoped<ICompanyLogic, CompanyLogic>();
            services.AddScoped<IJobLogic, JobLogic>();
            services.AddScoped<ILoginLogic, LoginLogic>();
            services.AddScoped<IJobTypeLogic, JobTypeLogic>();
            services.AddScoped<ISkillLogic, SkillLogic>();
            services.AddSingleton<INotification, Notification>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Instance Job Portal API");
                c.RoutePrefix = string.Empty;
            });


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}