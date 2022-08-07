using Contexts;
using Hamrahan.Models;
using HamrahanTemplate.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace HamrahanAPI
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

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
               // options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(option =>
                {
                    option.SaveToken = true;
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:44396/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("Key").Value))
                    };
                });



            services.AddControllers(
                //opt =>
            //{
            //    var policy = new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().Build();
            //    opt.Filters.Add(new AuthorizeFilter(policy));
            //}
            );



            //services.AddDbContext<HamrahanDbContext>(option =>
            //option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)); //just for not tracking queries for better performance
            //services.AddIdentity<Person, IdentityRole>(option =>
            //{
            //    option.User.RequireUniqueEmail = true;
            //    option.Password.RequireDigit = false;
            //    option.Password.RequiredLength = 8;
            //    option.Password.RequireNonAlphanumeric = false;


            //}).AddEntityFrameworkStores<HamrahanDbContext>().AddDefaultTokenProviders();


            services.AddAuthorization(options =>
            {
                options.AddPolicy("Read_Person",
                     policy => policy.RequireClaim("Permission", "Read_Person"));
            });

            #region settingApiResponsedetails
            services.AddControllers(setup =>
           //for returning default for not bad format request and for responding for xml requests
           setup.ReturnHttpNotAcceptable = true).AddXmlDataContractSerializerFormatters()

           .ConfigureApiBehaviorOptions(a =>
           {   //setting more details of requests
               a.InvalidModelStateResponseFactory = context =>
              {
                  var problemDetailsFactory = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
                  var problemDetail = problemDetailsFactory.CreateValidationProblemDetails(
                      context.HttpContext,
                      context.ModelState);
                   //add aditional info not added by default
                   problemDetail.Detail = "See The Error Field";
                  problemDetail.Instance = context.HttpContext.Request.Path;

                   //find out hich status code to use
                   var actionExecutingContext = context as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;
                  if ((context.ModelState.ErrorCount > 0) && (actionExecutingContext?.ActionArguments.Count ==
                  context.ActionDescriptor.Parameters.Count))
                  {
                      problemDetail.Status = StatusCodes.Status422UnprocessableEntity;
                      problemDetail.Title = "validation error occurred";
                      return new UnprocessableEntityObjectResult(problemDetail)
                      {
                          ContentTypes = { "application/problem+json" }
                      };
                  };

                  problemDetail.Status = StatusCodes.Status400BadRequest;
                  problemDetail.Title = "errors on input occurred";
                  return new BadRequestObjectResult(problemDetail)
                  {
                      ContentTypes = { "application/problem+json" }
                  };

              };
           });
            #endregion
            //adding auto mapper to project
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HamrahanAPI", Version = "v1" });
            });
            services.AddScoped<IUow, Uow>();





            services.AddIdentity<Person, IdentityRole>(option =>
            {
                option.User.RequireUniqueEmail = true;
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = false;


            }).AddEntityFrameworkStores<HamrahanDbContext>().AddDefaultTokenProviders();


        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(ILoggerFactory logger,IApplicationBuilder app, IWebHostEnvironment env)
            {
            
           
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HamrahanAPI v1"));
                }

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
