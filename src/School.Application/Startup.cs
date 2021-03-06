﻿using Microsoft.AspNetCore.Builder;
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
using School.Core.Validators.ValidateTeacherParameters;
using School.Repositories;
using School.Core.Validators.TeacherFilter;
using School.Core.ValidatorsTeacher;
using School.Core.Operations;
using StoneCo.Buy4.School.DataContracts.UpdateTeacher;
using StoneCo.Buy4.School.DataContracts.InsertTeacher;
using StoneCo.Buy4.School.DataContracts.DeleteTeacher;
using StoneCo.Buy4.School.DataContracts.GetTeachers;
using StoneCo.Buy4.School.DataContracts.GetTeacher;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using School.Core.Operations.Subscription.SubscriptionInformations;
using StoneCo.Buy4.School.DataContracts.InformationsSubscription;
using School.Core.Operations.Subscription.EnrolledStudents;
using StoneCo.Buy4.School.DataContracts.Subscription.EnrolledStudents;
using School.Core.Operations.Subscription.GetSubscriptions;
using School.Core.Operations.Subscription.InsertSubscription;
using StoneCo.Buy4.School.DataContracts.Subscription.InsertSubscription;
using StoneCo.Buy4.School.DataContracts.Subscription.GetSubscriptions;
using School.Core.Validators.Subscription;
using School.Core.Validators.NullOrZero;
using School.Core.Operations.Class.InsertClass;
using School.Core.Operations.Class.ClassCSVReader;
using StoneCo.Buy4.School.DataContracts.Class.InsertClass;
using School.Core.Validators.SchoolClassCsvFile;
using School.Core.Validators.ClassInputDtoParameters;
using Microsoft.OpenApi.Models;

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
            services.AddScoped<IClassRepository>(provider => new ClassRepository(provider.GetService<IConfiguration>().GetConnectionString("SchoolConnection")));
            services.AddScoped<ICourseRepository>(provider => new CourseRepository(provider.GetService<IConfiguration>().GetConnectionString("SchoolConnection")));
            services.AddScoped<ILevelRepository>(provider => new LevelRepository(provider.GetService<IConfiguration>().GetConnectionString("SchoolConnection")));
            services.AddScoped<IStudentRepository>(provider => new StudentRepository(provider.GetService<IConfiguration>().GetConnectionString("SchoolConnection")));
            services.AddScoped<ISubscriptionRepository>(provider => new SubscriptionRepository(provider.GetService<IConfiguration>().GetConnectionString("SchoolConnection")));
            services.AddScoped<ITeacherRepository>(provider => new TeacherRepository(provider.GetService<IConfiguration>().GetConnectionString("SchoolConnection")));

            // Teacher Operations
            services.AddScoped<ISchoolMappingResolver, SchoolMappingResolver>();
            services.AddScoped<IDeleteTeacher, DeleteTeacher>();
            services.AddScoped<IGetTeacher, GetTeacher>();
            services.AddScoped<IGetTeachers, GetTeachers>();
            services.AddScoped<IInsertTeacher, InsertTeacher>();
            services.AddScoped<ISearchTeacher, SearchTeacher>();
            services.AddScoped<IUpdateTeacher, UpdateTeacher>();
            // Subscription Operations
            services.AddScoped<IEnrolledStudents, EnrolledStudents>();
            services.AddScoped<IGetSubscriptions, GetSubscriptions>();
            services.AddScoped<IInsertSubscription, InsertSubscription>();
            services.AddScoped<ISubscriptionInformations, SubscriptionInformations>();
            // Class Operations
            services.AddScoped<IInsertClass, InsertClass>();
            services.AddScoped<IClassCsvReader, ClassCsvReader>();
            // Teacher Operation Base
            services.AddScoped<IOperationBase<DeleteTeacherRequest, DeleteTeacherResponse>, DeleteTeacher>();
            services.AddScoped<IOperationBase<GetTeacherRequest, GetTeacherResponse>, GetTeacher>();
            services.AddScoped<IOperationBase<GetTeachersRequest, GetTeachersResponse>, GetTeachers>();
            services.AddScoped<IOperationBase<InsertTeacherRequest, InsertTeacherResponse>, InsertTeacher>();
            services.AddScoped<IOperationBase<SearchTeacherRequest, SearchTeacherResponse>, SearchTeacher>();
            services.AddScoped<IOperationBase<UpdateTeacherRequest, UpdateTeacherResponse>, UpdateTeacher>();
            // Subscription Operation Base
            services.AddScoped<IOperationBase<EnrolledStudentRequest, EnrolledStudentResponse>, EnrolledStudents>();
            services.AddScoped<IOperationBase<GetSubscriptionsRequest, GetSubscriptionsResponse>, GetSubscriptions>();
            services.AddScoped<IOperationBase<InsertSubscriptionRequest, InsertSubscriptionResponse>, InsertSubscription>();
            services.AddScoped<IOperationBase<SubscriptionInformationsRequest, SubscriptionInformationsResponse>, SubscriptionInformations>();
            // Class Operation Base
            services.AddScoped<IOperationBase<InsertClassRequest, InsertClassResponse>, InsertClass>();
            // Validators
            services.AddScoped<IClassInputDtoValidator, ClassInputDtoValidator>();
            services.AddScoped<IClassInputDtoParametersValidator, ClassInputDtoParametersValidator>();
            services.AddScoped<IIsNullOrZeroValidator, IsNullOrZeroValidator>();
            services.AddScoped<ISubscriptionValidator, SubscriptionValidator>();
            services.AddScoped<ITeacherValidator, TeacherValidator>();
            services.AddScoped<IFilterValidator, FilterValidator>();
            services.AddScoped<ITeacherParametersValidator, TeacherParametersValidator>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Application", Version = "v1" });
            });
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
