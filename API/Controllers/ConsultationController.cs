using AtendimentoMedico.Domain.Interfaces;
using AtendimentoMedico.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        protected readonly IRepository<Consultation> _consultationRepository;
        public ConsultationController(IRepository<Consultation> consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        [HttpGet("GetList")]
        public async Task<ActionResult<IEnumerable<Consultation>>> GetAllAsync()
        {
            var getAll = await _consultationRepository.GetAllAsync();
            if (!getAll.Any())
                return NoContent();

            return Ok(getAll);
        }

        [HttpGet("GetById/{id:int}", Name = "getConsultByID")]
        public async Task<ActionResult<Consultation>> GetByIdAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var getById = await _consultationRepository.GetByIdAsync(id);

            if (getById is null)
                return NotFound();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Consultation>> CreateAsync(Consultation consultation)
        {
            if (consultation == null)
                return BadRequest();

            var newConsult = await _consultationRepository.CreateAsync(consultation);
            return new CreatedAtRouteResult("getConsultByID", new { id = newConsult.ConsultationID }, newConsult);
        }
    }
}
