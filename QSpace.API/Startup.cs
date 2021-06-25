
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QSpace.Data;
using QSpace.Data.Data;
using QSpace.Infrastructure.Services;
using QSpace.Infrastructure.Services.Auth;
using QSpace.Infrastructure.Services.Users;
using QSpace.Infrastructure.AutoMapper;
using QSpace.Infrastructure.Services.MCQuestion;
using QSpace.Infrastructure.Services.Quiz;
using QSpace.Infrastructure.Services.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QSpace.Infrastructure.Services.Files;
using QSpace.Infrastructure.Services.Session;

namespace QSpace.API
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
            services.AddDbContext<QSpaceDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            
            

            services.AddIdentity<QSpace.Data.DbEntities.User, IdentityRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 6;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.SignIn.RequireConfirmedEmail = false;
                config.SignIn.RequireConfirmedPhoneNumber = false;
            }).AddEntityFrameworkStores<QSpaceDbContext>()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<IFileService, FileService>();
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IMCQuestionService, MCQuestionService>();
            services.AddScoped<ISessionService, SessionService>();

            services.AddRazorPages();
            services.AddControllersWithViews();
            /*
            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = Configuration["Jwt:Issuer"],
                      ValidAudience = Configuration["Jwt:Issuer"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"]))
                  };
              });
             

             services.AddSwaggerGen();
            
             services.AddSwaggerGen(c =>
             {
                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Please enter 'Bearer JWT' :) ",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Scheme = "Bearer"
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            }); 
             */
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IAuthService, AuthService>();
            //services.AddSingleton<IFileService, FileService>();
            //services.AddControllersWithViews();
            //services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            //services.AddScoped<IQuizService, QuizService>();
            //services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<IMCQuestionService, MCQuestionService>();
            //services.AddScoped<ISessionService, SessionService>();
            //services.AddSwaggerGen();
            
            //services.AddRazorPages();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        /*
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "QSpace");
            c.RoutePrefix = string.Empty;
        });
        
       */ 

            
            //app.UseRequestLocalization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    endpoints.MapDefaultControllerRoute();
            //});
            
            
             
        }
    }
}
