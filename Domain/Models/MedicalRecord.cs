using System.ComponentModel.DataAnnotations;

namespace AtendimentoMedico.Domain.Models
{
    //prontuario
    public class MedicalRecord
    {
        [Key]
        public int ID { get; set; }

        public int ConsultationId { get; set; }
        public Consultation Consultation { get; set; } = null!;

        public string? Description { get; set; }
        public string? Prescription { get; set; }
    }
}
