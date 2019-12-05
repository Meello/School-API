using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Core.Mapping;
using School.Core.Operations;
using School.Core.Operations.DeleteTeacher;
using School.Core.Operations.FilterTeacher;
using School.Core.Operations.GetTeacher;
using School.Core.Operations.GetTeachers;
using School.Core.Operations.InsertTeacher;
using School.Core.Operations.UpdateTeacher;
using School.Core.Repositories;
using School.Core.Validators;
using School.Core.Validators.GetTeachersPerPage;
using School.Core.Validators.IdValidator;
using School.Core.Validators.UpdateTeacher;
using School.Core.Validators.ValidateTeacherParameters;
using School.Repositories;

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
            services.AddScoped<IIdExistValidator>(provider => new IdExistValidator(provider.GetService<IConfiguration>().GetConnectionString("SchoolConnection")));
            services.AddScoped<IGetTeachersPerPageValidator>(provider => new GetTeachersPerPageValidator(provider.GetService<IConfiguration>().GetConnectionString("SchoolConnection")));
            //services.AddScoped<ITeacherRepository, TeacherRepository>();

            // Operations
            services.AddScoped<ISchoolMappingResolver, SchoolMappingResolver>();
            services.AddScoped<IGetTeacher, GetTeacher>();
            services.AddScoped<IGetTeachers, GetTeachers>();
            services.AddScoped<IDeleteTeacher, DeleteTeacher>();
            services.AddScoped<IUpdateTeacher, UpdateTeacher>();
            services.AddScoped<IInsertTeacher, InsertTeacher>();
            services.AddScoped<ISearchTeacher, SearchTeacher>();
            services.AddScoped<IGetTeachersPerPage, GetTeachersPerPage>();
            services.AddScoped<IInsertTeacherValidator, InsertTeacherValidator>();
            services.AddScoped<IUpdateTeacherValidator, UpdateTeacherValidator>();
            services.AddScoped<ITeacherParametersValidator, TeacherParametersValidator>(); 

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
