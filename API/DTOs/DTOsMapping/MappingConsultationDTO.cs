using AtendimentoMedico.Domain.Models;

namespace API.DTOs.DTOsMapping
{
    public class MappingConsultationDTO
    {
        public static ConsultationDTO? ConsultationToDTO(Consultation consultation)
        {
            if (consultation is null)
                return null;

            return new ConsultationDTO()
            {
                ConsultationTime = consultation.ConsultationTime,
                DoctorID = consultation.DoctorId,
                PatientID = consultation.PatientId,
                Status = consultation.Status
            };
        }

        public static Consultation ConsultationDtoToConsultation(ConsultationDTO consultationDto) 
        {
            if (consultationDto == null)
                return null;

            return new Consultation() 
            {
                DoctorId = consultationDto.DoctorID,
                PatientId = consultationDto.PatientID,
                ConsultationTime = consultationDto.ConsultationTime,
                Status = consultationDto.Status
            };
        }

        public static List<ConsultationDTO> toListConsultationDTO(IEnumerable<Consultation> consultations) 
        {
            if(consultations == null)
                return new List<ConsultationDTO>();

            return consultations.Select(c => new ConsultationDTO
            {
                ConsultationTime = c.ConsultationTime,
                DoctorID = c.DoctorId,
                PatientID = c.PatientId,
                Status = c.Status,
            }).ToList();
            
        }
    }
}
