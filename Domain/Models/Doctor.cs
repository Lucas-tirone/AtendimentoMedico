using System.ComponentModel.DataAnnotations;

namespace AtendimentoMedico.Domain.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        [StringLength(10)]
        public string? CRM { get; set; }

        [Required]
        public string? Specialty { get; set; }

        public bool Active { get; set; }

    }
}
