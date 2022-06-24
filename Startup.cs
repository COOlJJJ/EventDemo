using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainEventDemo
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


            //领域事件和集成事件
            //领域事件(MediatR)
            //领域事件（Domain Event）是在一个特定领域由一个动作触发的，是发生在过去的行为产生的事件(行为可以是人操作的，也可以是系统自动的);
            //通常咱们会把领域事件用在一个应用程序进程内
            //领域事件的主要目的是为了让代码更加容易维护，让业务更加容易扩展，也就是对代码业务层面的优化

            //集成事件 (CAP和Masstransit)
            //集成事件(IntegrationEvent)同样也是指在过去的行为产生的事件(行为可以是人操作的，也可以是系统自动的)，一般用于跨多个微服务或外部系统
            //集成事件的主要目的就是为了让服务模块之间或系统之间的对接耦合性变低，只要约定好事件类型，发事件模块和处理事件的模块就会有很少对接，便于扩展和维护

            //MediatR是用.Net实现的简单中介者模式，无需其他依赖就能处理进程内的消息传递，支持请求/响应、命令、查询、通知和事件的同步或异步传递，通过C#的泛型智能调度。
            //中介者模式(Mediator)：用一个中介对象来封装一系列的对象交互。中介者使各对象不需要显示地相互引用，从而使其耦合松散，而且可以独立地改变它们之间的交互
            //在本例子中就是用户注册的对象 AddUserSuccessEvent
            //注册相关服务， 并且可以指定程序集，注册相关的处理服务
            services.AddMediatR(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
