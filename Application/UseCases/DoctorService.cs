
using Application.Common;
using Application.Interfaces;
using AtendimentoMedico.Application.Interfaces;
using AtendimentoMedico.Domain.Models;


namespace Application.UseCases
{
    public class DoctorService : IDoctorService
    {
        private readonly IConsultationRepository _consultationRepository;
        private readonly IRepository<Doctor> _doctorRepository;

        public DoctorService(IConsultationRepository consultationRepository, IRepository<Doctor> doctorRepository )
        {
            _consultationRepository = consultationRepository;
            _doctorRepository = doctorRepository;
        }

        //tanto esse metodo quanto o pattern de result foi auxiliado pelo GPT
        public async Task<Result> DeleteAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor is null)
            {
                return Result.Failure("Doctor not found");
            }

            var hasActiveConsultations = await _consultationRepository.doctorHasAnyConsultationByIdAsync(id);

            if (hasActiveConsultations) 
            {
                return Result.Sucess("Doctor has active consultations");
            }

            await _doctorRepository.DeleteAsync(id);

            return Result.Sucess("Doctor deleted successfully");
        }
    }
}
