using MediatR;

namespace DomainEventDemo.DomainEvent
{
    /// <summary>
    /// 集成INotification，同一个事件可以被多个处理程序处理
    /// </summary>
    public class AddUserSuccessEvent : INotification
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
