using AtendimentoMedico.Domain.Models;

namespace AtendimentoMedico.Application.Interfaces
{
    public interface IConsultationRepository : IRepository<Consultation>
    {
        Task<bool> doctorHasAnyConsultationByIdAsync(int id);
    }
}
