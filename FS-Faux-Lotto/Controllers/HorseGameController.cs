using FS_Faux_Lotto.Models;
using FS_Faux_Lotto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FS_Faux_Lotto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorseGameController : ControllerBase
    {
        private readonly IHorseGameRepository _horseGameRepository;
        public HorseGameController(IHorseGameRepository horseGameRepository)
        {
            _horseGameRepository = horseGameRepository;
        }

        // GET: api/<HorseGameController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_horseGameRepository.GetAll());
        }

        // GET api/<HorseGameController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_horseGameRepository.GetById(id));
        }

        // POST api/<HorseGameController>
        [HttpPost]
        public IActionResult Post(HorseGame horseGame)
        {
            _horseGameRepository.Add(horseGame);
            return CreatedAtAction("Get", new { id = horseGame.Id }, horseGame);
        }

        // DELETE api/<HorseGameController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _horseGameRepository.Delete(id);
            return NoContent();
        }
    }
}
