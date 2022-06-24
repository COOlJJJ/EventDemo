using DomainEventDemo.DomainEvent;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DomainEventDemo.DonmainEventHandler
{
    public class AddUserSuccessEventEmaiHandler : INotificationHandler<AddUserSuccessEvent>
    {
        public Task Handle(AddUserSuccessEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"发送邮件：{notification.UserName}注册成功，欢迎使用~~~");
            return Task.CompletedTask;
        }
    }
}
