using AtendimentoMedico.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using AtendimentoMedico.Application.Interfaces;


namespace AtendimentoMedico.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        //dependecyInjection 
        protected readonly IRepository<Patient> _patientRepository;

        public PatientController(IRepository<Patient> repositoryPatient)
        {
            _patientRepository = repositoryPatient;
        }

        
        [HttpGet("GetList")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAll()
        {
            var listPatient = await _patientRepository.GetAllAsync();
            if (!listPatient.Any())
                return NoContent();

            return Ok(listPatient);
        }

        [HttpGet("GetById/{id:int}", Name = "patientById")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            if (patient == null)
                return NotFound($"Any patient found with {id}");

            return Ok(patient);
        }

        [HttpPost("CreatePatient")]
        public async Task<ActionResult> Post(Patient patient)
        {
            if (patient is null)
                return BadRequest("Patient is null");

            var exist = await _patientRepository.ExistAsync(p => p.CPF == patient.CPF);
            if (exist)
                return BadRequest("This CPF is already registered");

            var newPatient = await _patientRepository.CreateAsync(patient);

            return new CreatedAtRouteResult("patientById", new { id = newPatient.PatientID }, newPatient);
        }

        [HttpPut("UpdatePatient/{id:int}")]
        public async Task<ActionResult> Put(int id, Patient patient)
        {
            if (id <= 0)
                return BadRequest("Id bellow than 0");
            if (patient is null)
                return NotFound($"Patient with {id} is null");
            if (patient.PatientID != id)
                return BadRequest("Id mismatch");

            var existing = await _patientRepository.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            existing.FullName = patient.FullName;
            existing.Adress = patient.Adress;
            existing.Phone  = patient.Phone;
            existing.Active = patient.Active;
        
            var updated = await _patientRepository.UpdateAsync(existing);

            return Ok(updated);
        }

        [HttpDelete("DeletePatient/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var getPatient = await _patientRepository.GetByIdAsync(id);

            if (getPatient is null)
                return NotFound($"Patient with {id} is null or not found");

            await _patientRepository.DeleteAsync(id);

            return Ok(getPatient);
        }

    }
}
