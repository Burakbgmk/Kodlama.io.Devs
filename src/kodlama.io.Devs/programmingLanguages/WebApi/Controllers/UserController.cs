using Application.Features.Users.Commands.CreateUser;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserForRegisterDto dto)
        {
            CreateUserCommand command = new() { UserRegister = dto };
            var result = await Mediator.Send(command);
            return Created("",result);
        }
    }
}
