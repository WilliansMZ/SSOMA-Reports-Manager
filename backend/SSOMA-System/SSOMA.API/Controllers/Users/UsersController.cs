using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SSOMA.Application.DTOs.Users;
using SSOMA.Application.Features.Users.Commands.CreateUser;
using SSOMA.Application.Features.Users.Commands.DeleteUser;
using SSOMA.Application.Features.Users.Commands.UpdateUser;
using SSOMA.Application.Features.Users.Queries.GetAllUsers;
using SSOMA.Application.Features.Users.Queries.GetUserById;

namespace SSOMA.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/Users
        
        [HttpPost]
       // [Authorize(Roles = "ssoma_manager")] // Solo usuarios con rol "admin"
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = userId }, new { id = userId });
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID mismatch");

            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));
            return result ? NoContent() : NotFound();
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }
    }
}
