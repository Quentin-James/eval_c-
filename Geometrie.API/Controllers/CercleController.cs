using Microsoft.AspNetCore.Mvc;
using Geometrie.DAL; // Assurez-vous que ce namespace est correct
using System.Collections.Generic;
using Geometrie.BLL;

namespace Geometrie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CercleController : ControllerBase
    {
        private readonly CercleRepository _cercleRepository;

        public CercleController(CercleRepository cercleRepository)
        {
            _cercleRepository = cercleRepository;
        }

        // GET: api/Cercle
        [HttpGet]
        public ActionResult<IEnumerable<Cercle_DAL>> GetCercles()
        {
            return Ok(_cercleRepository.GetAllCercles());
        }

        // GET: api/Cercle/5
        [HttpGet("{id}")]
        public ActionResult<Cercle_DAL> GetCercle(int id)
        {
            var cercle = _cercleRepository.GetCercleById(id);
            if (cercle == null)
            {
                return NotFound();
            }
            return Ok(cercle);
        }

        // POST: api/Cercle
        [HttpPost]
        public ActionResult AddCercle([FromBody] Cercle_DAL cercle)
        {
            _cercleRepository.AddCercle(cercle);
            return CreatedAtAction(nameof(GetCercle), new { id = cercle.Id }, cercle);
        }

        // PUT: api/Cercle/5
        [HttpPut("{id}")]
        public ActionResult UpdateCercle(int id, [FromBody] Cercle_DAL cercle)
        {
            var existingCercle = _cercleRepository.GetCercleById(id);
            if (existingCercle == null)
            {
                return NotFound();
            }
            _cercleRepository.UpdateCercle(id, cercle);
            return NoContent();
        }

        // DELETE: api/Cercle/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCercle(int id)
        {
            var existingCercle = _cercleRepository.GetCercleById(id);
            if (existingCercle == null)
            {
                return NotFound();
            }
            _cercleRepository.DeleteCercle(id);
            return NoContent();
        }

        // POST: api/Cercle/CalculateTotalArea
        [HttpPost("CalculateTotalArea")]
        public ActionResult<double> CalculateTotalArea([FromBody] List<int> ids)
        {
            var totalArea = _cercleRepository.CalculerAireTotale(ids);
            return Ok(totalArea);
        }
    }
}