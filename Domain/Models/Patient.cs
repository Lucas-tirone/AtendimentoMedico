using System.ComponentModel.DataAnnotations;

namespace AtendimentoMedico.Domain.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        public string? FullName { get; set; }
        public string? CPF {  get; set; }
        public string? Phone { get; set; }
        public string? Adress { get; set; }
        public bool Active {  get; set; }

    }
}
