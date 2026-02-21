using AtendimentoMedico.Domain.Models;

namespace API.DTOs
{
    public class ConsultationDTO
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime ConsultationTime { get; set; }
        public Consultation.ConsultationStatus Status { get; set; }
       
    }
}
