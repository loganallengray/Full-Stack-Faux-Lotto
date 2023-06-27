using FS_Faux_Lotto.Models;
using FS_Faux_Lotto.Repositories;
using FS_Faux_Lotto.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FS_Faux_Lotto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinGameController : ControllerBase
    {
        private readonly ICoinGameRepository _coinGameRepository;
        public CoinGameController(ICoinGameRepository coinGameRepository)
        {
            _coinGameRepository = coinGameRepository;
        }

        // GET: api/<CoinGameController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_coinGameRepository.GetAll());
        }

        // GET api/<CoinGameController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_coinGameRepository.GetById(id));
        }

        // POST api/<CoinGameController>
        [HttpPost]
        public IActionResult Post(CoinGame coinGame)
        {
            _coinGameRepository.Add(coinGame);
            return CreatedAtAction("Get", new { id = coinGame.Id }, coinGame);
        }

        // DELETE api/<CoinGameController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _coinGameRepository.Delete(id);
            return NoContent();
        }
    }
}
