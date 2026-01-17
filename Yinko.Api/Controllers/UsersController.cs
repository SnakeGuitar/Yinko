using Microsoft.AspNetCore.Mvc;
using Yinko.Application.Common.Models;
using Yinko.Application.Users.Commands.CreateUser;
using Yinko.Application.Users.Commands.DeleteUser;
using Yinko.Application.Users.Commands.LoginUser;
using Yinko.Application.Users.Commands.UpdateUser;
using Yinko.Application.Users.Queries.GetUser;
using Yinko.Domain.Entities;
using Yinko.Infrastructure.Persistence;

namespace Yinko.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var userDto = await Mediator.Send(new GetUserQuery(id));
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(CreateUserCommand command)
        {
            var userId = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetUser), new { id = userId }, null);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] string email)
        {
            var userDto = await Mediator.Send(new LoginUserCommand(email));
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await Mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }
    }
}
