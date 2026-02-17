using System.ComponentModel.DataAnnotations;

namespace AtendimentoMedico.Domain.Models
{
    public class Consultation
    {
        [Key]
        public int ConsultationID { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime ConsultationTime { get; set; }
        public string Status { get; set; } //= "Agendada";
        public MedicalRecord MedicalRecord { get; set; }

    }
}
