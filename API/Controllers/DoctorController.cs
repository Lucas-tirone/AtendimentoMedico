using Application.Interfaces;
using AtendimentoMedico.Application.Interfaces;
using AtendimentoMedico.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly IRepository<Doctor> _repository;
        private readonly IDoctorService _doctorService;

        public DoctorController(IRepository<Doctor> repository, IDoctorService doctorService)
        {
            _repository = repository;
            _doctorService = doctorService;
        }

        [HttpGet(Name = "getDoctorById")]
        public async Task<ActionResult> GetById(int id)
        {
            if (id <= 0) 
            {
                return BadRequest("id bellow or equal than 0");
            }

            var doctor = await _repository.GetByIdAsync(id);
            if (doctor == null) 
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Doctor doctor)
        {
            if (doctor is null) 
            {
                return BadRequest("body null");
            }

            var verifyExist = await _repository.ExistAsync(d => d.CRM == doctor.CRM);

            if (verifyExist)
            {
                return BadRequest($"Doctor with {doctor.CRM} already exist");
            }

            var doctorCreate = await _repository.CreateAsync(doctor);

            return new CreatedAtRouteResult("getDoctorById", new { id = doctorCreate.DoctorID}, doctorCreate);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id bellow or equal 0");

            var result = await _doctorService.DeleteAsync(id);

            if (!result.Success)
            {
                /*if (result.Message == "Doctor not found")
                    return NotFound(result.Message);*/

                return BadRequest(result.Message);
            }
           
            return Ok(result.Message);
        }

        /*[HttpPut]
        public async Task<ActionResult> Update(int id, Doctor entity)
        {
            

        }*/
    }
}
