using FS_Faux_Lotto.Models;
using FS_Faux_Lotto.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FS_Faux_Lotto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardGameController : ControllerBase
    {
        private readonly ICardGameRepository _cardGameRepository;
        public CardGameController(ICardGameRepository cardGameRepository)
        {
            _cardGameRepository = cardGameRepository;
        }

        // GET: api/<CardGameController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cardGameRepository.GetAll());
        }

        // GET api/<CardGameController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_cardGameRepository.GetById(id));
        }

        // POST api/<CardGameController>
        [HttpPost]
        public IActionResult Post(CardGame cardGame)
        {
            _cardGameRepository.Add(cardGame);
            return CreatedAtAction("Get", new { id = cardGame.Id }, cardGame);
        }

        // DELETE api/<CardGameController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cardGameRepository.Delete(id);
            return NoContent();
        }
    }
}
