using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using TaskManagementService.DBContext;
using TaskManagementService.Formatters;
using TaskManagementService.Repository;

namespace TaskManagementService
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
            var csvFormatterOptions = new CsvFormatterOptions();
            csvFormatterOptions.CsvDelimiter = ",";

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "text/csv" });
            });


            services.AddDbContext<TaskContext>(o => o.UseSqlServer(Configuration.GetConnectionString("TaskDB")));
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddControllers(
                options =>
            {
                options.OutputFormatters.Add(new CsvOutputFormatter(csvFormatterOptions));
                options.FormatterMappings.SetMediaTypeMappingForFormat("csv", MediaTypeHeaderValue.Parse("text/csv"));
            }
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Task Management System", Version = "v1" });

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c=>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManagementSystem v1"); 
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
