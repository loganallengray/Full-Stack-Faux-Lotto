using FS_Faux_Lotto.Models;
using FS_Faux_Lotto.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FS_Faux_Lotto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet("{fireBaseId}")]
        public IActionResult GetUser(string fireBaseId)
        {
            return Ok(_userRepository.GetByFireBaseId(fireBaseId));
        }

        [HttpGet("details/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetByUserId(id));
        }

        [HttpGet("DoesUserExist/{fireBaseId}")]
        public IActionResult DoesUserExist(string fireBaseId)
        {
            var user = _userRepository.GetByFireBaseId(fireBaseId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            _userRepository.Add(user);

            return CreatedAtAction(
                nameof(GetUser),
                new { fireBaseId = user.FireBaseId },
                user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(User user)
        {
            var currentUser = GetCurrentUser();

            _userRepository.Update(user);
            return NoContent();
        }


        [HttpGet("Me")]
        public IActionResult Me()
        {
            var user = GetCurrentUser();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        private User GetCurrentUser()
        {
            var fireBaseId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userRepository.GetByFireBaseId(fireBaseId);
        }
    }
}
