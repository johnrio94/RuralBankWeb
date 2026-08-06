// namespace RuralBankWeb.Models
// {
//     public class JobOpening
//     {
//         public int Id { get; set; }
//         public string Title { get; set; } = "";
//         public string Department { get; set; } = "";
//         public string Location { get; set; } = "";
//         public string EmploymentType { get; set; } = "Full-time";
//         public string Description { get; set; } = "";
//         public bool IsActive { get; set; } = true;
//         public DateTime DatePosted { get; set; } = DateTime.Now;
//     }
// }


using System.ComponentModel.DataAnnotations;

namespace RuralBankWeb.Models
{
    public class JobOpening
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; } = "";

        [Required, MaxLength(100)]
        public string Department { get; set; } = "";

        [Required, MaxLength(100)]
        public string Location { get; set; } = "";

        [MaxLength(50)]
        public string EmploymentType { get; set; } = "Full-time";

        public string Description { get; set; } = "";

        public bool IsActive { get; set; } = true;

        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}