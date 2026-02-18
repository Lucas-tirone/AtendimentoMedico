using System.ComponentModel.DataAnnotations;

namespace AtendimentoMedico.Domain.Models
{
    public class Consultation
    {
        [Key]
        public int ConsultationID { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        public DateTime ConsultationTime { get; set; }
        public ConsultationStatus Status { get; set; } = ConsultationStatus.Agendada;
        public MedicalRecord? MedicalRecord { get; set; }

        public enum ConsultationStatus
        {
            Agendada = 1,
            Confirmada = 2,
            Cancelada = 3,
            Realizada = 4,
            Faltou = 5
        }
    }
}
