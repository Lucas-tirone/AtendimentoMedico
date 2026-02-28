using AtendimentoMedico.Application.Interfaces;
using AtendimentoMedico.Domain.Models;
using AtendimentoMedico.Infraestructure.Context;
using AtendimentoMedico.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class ConsultationRepository : Repository<Consultation>, IConsultationRepository
    {
        public ConsultationRepository(AppDbContext dbContext) : base(dbContext)
        {}

        public async Task<bool> doctorHasAnyConsultationByIdAsync(int id)
        {
            return await _dbContext.Set<Consultation>()
                .AsNoTracking().AnyAsync(c => c.DoctorId == id && 
                 (c.Status == Consultation.ConsultationStatus.Agendada 
                    || c.Status == Consultation.ConsultationStatus.Confirmada));
        }
    }
}
