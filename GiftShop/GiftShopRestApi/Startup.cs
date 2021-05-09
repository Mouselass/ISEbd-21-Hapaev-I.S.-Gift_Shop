using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftShopBusinessLogic.BusinessLogic;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.HelperModels;
using GiftShopDatabaseImplement.Implements;

namespace GiftShopRestApi
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
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IGiftStorage, GiftStorage>();
            services.AddTransient<IComponentStorage, ComponentStorage>();
            services.AddTransient<IWarehouseStorage, WarehouseStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
            services.AddTransient<OrderLogic>();
            services.AddTransient<ClientLogic>();
            services.AddTransient<GiftLogic>();
            services.AddTransient<MailLogic>();
            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = "smtp.gmail.com",
                SmtpClientPort = 587,
                MailLogin = "testforlabsprogramming@gmail.com",
                MailPassword = "12345qwerty73",
            });
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
