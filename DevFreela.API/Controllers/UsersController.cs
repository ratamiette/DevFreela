using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            if(user is null)
                return NotFound();

            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel createUserInputModel)
        {
            var id = _userService.Create(createUserInputModel);

            return CreatedAtAction(nameof(GetById), new { id }, createUserInputModel);
        }

        // PUT api/users/{id}/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel loginModel)
        {
            // Will be implemented soon

            return NoContent();
        }
    }
}
