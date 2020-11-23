using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bookStore.BusinessLogic.Abstractions;
using bookStore.BusinessLogic.Services;
using bookStore.Infractructure;
using bookStore.Infractructure.Abstractions;
using bookStore.Infractructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace bookStoreApi
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
            services.AddDbContext<BookStoreContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPrintingRepository, PrintingRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services.AddScoped<IAppService, AppService>();

            services.AddCors(o => o.AddPolicy("ReactPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images"
            }); ;*/

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");
            });
            app.UseCors("ReactPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
