using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Core.Mapping;
using School.Core.Operations.DeleteTeacher;
using School.Core.Operations.SearchTeacher;
using School.Core.Operations.GetTeacher;
using School.Core.Operations.GetTeachers;
using School.Core.Operations.InsertTeacher;
using School.Core.Operations.UpdateTeacher;
using School.Core.Repositories;
using School.Core.Validators;
using School.Core.Validators.UpdateTeacher;
using School.Core.Validators.ValidateTeacherParameters;
using School.Repositories;
using School.Core.Validators.SearchTeacher;
using School.Core.ValidatorsTeacher;

namespace School.Application
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
            // Repositories
            services.AddScoped<ITeacherRepository>(provider => new TeacherRepository(provider.GetService<IConfiguration>().GetConnectionString("SchoolConnection")));
            //services.AddScoped<ITeacherRepository, TeacherRepository>();

            // Operations
            services.AddScoped<ISchoolMappingResolver, SchoolMappingResolver>();
            services.AddScoped<IDeleteTeacher, DeleteTeacher>();
            services.AddScoped<IGetTeacher, GetTeacher>();
            services.AddScoped<IGetTeachers, GetTeachers>();
            services.AddScoped<IInsertTeacher, InsertTeacher>();
            services.AddScoped<ISearchTeacher, SearchTeacher>();
            services.AddScoped<IUpdateTeacher, UpdateTeacher>();

            //Validators
            services.AddScoped<IInsertTeacherValidator, InsertTeacherValidator>();
            services.AddScoped<ISearchTeacherValidator, SearchTeacherValidator>();
            services.AddScoped<ITeacherValidator, TeacherValidator>();
            services.AddScoped<ITeacherParametersValidator, TeacherParametersValidator>();
            services.AddScoped<IUpdateTeacherValidator, UpdateTeacherValidator>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
