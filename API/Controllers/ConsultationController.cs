using API.DTOs;
using AtendimentoMedico.Application.Interfaces;
using AtendimentoMedico.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using API.DTOs.DTOsMapping;

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
        public async Task<ActionResult<IEnumerable<ConsultationDTO>>> GetAllAsync()
        {
            var getAll = await _consultationRepository.GetAllAsync();

            if (!getAll.Any())
                return NoContent();

            var consultationsToDTO = MappingConsultationDTO.toListConsultationDTO(getAll);

            return Ok(consultationsToDTO);
        }

        [HttpGet("GetById/{id:int}", Name = "getConsultByID")]
        public async Task<ActionResult<ConsultationDTO>> GetByIdAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var getById = await _consultationRepository.GetByIdAsync(id);

            if (getById is null)
                return NotFound();

            var consultationToDto = MappingConsultationDTO.ConsultationToDTO(getById);

            return Ok(consultationToDto);
        }

        [HttpPost]
        public async Task<ActionResult<ConsultationDTO>> CreateAsync(ConsultationDTO consultationDTO)
        {
            if (consultationDTO == null)
                return BadRequest();

            var newConsultation = MappingConsultationDTO.ConsultationDtoToConsultation(consultationDTO);

            var consultation = await _consultationRepository.CreateAsync(newConsultation);

            var newConsultationDTO = MappingConsultationDTO.ConsultationToDTO(consultation);

            return new CreatedAtRouteResult("getConsultByID",  new { id = consultation.ConsultationID},newConsultationDTO);
        }

        [HttpPut("UpdateStatus/{id:int}/status")]
        public async Task<ActionResult<ConsultationDTO>> UpdateAsync(int id, int status) 
        {
            if (id <= 0)
                return BadRequest("Id bellow than 0");

            var exist = await _consultationRepository.GetByIdAsync(id);

            if (exist == null)
                return NotFound();

            exist.Status = (Consultation.ConsultationStatus)status;

            var updateConsultation = await _consultationRepository.UpdateAsync(exist);

            return Ok(MappingConsultationDTO.ConsultationToDTO(exist)) ;

        }

    }
}
