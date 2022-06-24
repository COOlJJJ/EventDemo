using DomainEventDemo.DomainEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DomainEventDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("AddUser")]
        public async Task<IActionResult> AddUser([FromServices] IMediator mediator)
        {

            // 模拟注册用户成功
            bool isSuccess = true;
            string userName = "Xiao Chen";

            if (isSuccess)
            {
                // 发布用户注册成功事件
                await mediator.Publish(new AddUserSuccessEvent
                {
                    UserId = Guid.NewGuid().ToString(),
                    UserName = userName
                });
            }

            return Ok("用户注册成功");
        }
    }
}
