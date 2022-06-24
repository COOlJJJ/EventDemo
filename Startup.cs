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


            //�����¼��ͼ����¼�
            //�����¼�(MediatR)
            //�����¼���Domain Event������һ���ض�������һ�����������ģ��Ƿ����ڹ�ȥ����Ϊ�������¼�(��Ϊ�������˲����ģ�Ҳ������ϵͳ�Զ���);
            //ͨ�����ǻ�������¼�����һ��Ӧ�ó��������
            //�����¼�����ҪĿ����Ϊ���ô����������ά������ҵ�����������չ��Ҳ���ǶԴ���ҵ�������Ż�

            //�����¼� (CAP��Masstransit)
            //�����¼�(IntegrationEvent)ͬ��Ҳ��ָ�ڹ�ȥ����Ϊ�������¼�(��Ϊ�������˲����ģ�Ҳ������ϵͳ�Զ���)��һ�����ڿ���΢������ⲿϵͳ
            //�����¼�����ҪĿ�ľ���Ϊ���÷���ģ��֮���ϵͳ֮��ĶԽ�����Ա�ͣ�ֻҪԼ�����¼����ͣ����¼�ģ��ʹ����¼���ģ��ͻ��к��ٶԽӣ�������չ��ά��

            //MediatR����.Netʵ�ֵļ��н���ģʽ�����������������ܴ�������ڵ���Ϣ���ݣ�֧������/��Ӧ�������ѯ��֪ͨ���¼���ͬ�����첽���ݣ�ͨ��C#�ķ������ܵ��ȡ�
            //�н���ģʽ(Mediator)����һ���н��������װһϵ�еĶ��󽻻����н���ʹ��������Ҫ��ʾ���໥���ã��Ӷ�ʹ�������ɢ�����ҿ��Զ����ظı�����֮��Ľ���
            //�ڱ������о����û�ע��Ķ��� AddUserSuccessEvent
            //ע����ط��� ���ҿ���ָ�����򼯣�ע����صĴ������
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
