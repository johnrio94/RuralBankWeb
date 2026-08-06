// namespace RuralBankWeb.Models
// {
//     public class JobApplication
//     {
//         public int Id { get; set; }
//         public int JobId { get; set; }
//         public string JobTitle { get; set; } = "";
//         public string FullName { get; set; } = "";
//         public string Email { get; set; } = "";
//         public string Phone { get; set; } = "";
//         public string Address { get; set; } = "";
//         public string Message { get; set; } = "";
//         public string ResumeFileName { get; set; } = "";
//         public string ResumeStoredPath { get; set; } = "";
//         public DateTime DateApplied { get; set; } = DateTime.Now;
//     }
// }

using System.ComponentModel.DataAnnotations;

namespace RuralBankWeb.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        [MaxLength(150)]
        public string JobTitle { get; set; } = "";

        [Required, MaxLength(150)]
        public string FullName { get; set; } = "";

        [Required, MaxLength(150)]
        public string Email { get; set; } = "";

        [MaxLength(30)]
        public string Phone { get; set; } = "";

        [MaxLength(250)]
        public string Address { get; set; } = "";

        public string Message { get; set; } = "";

        [MaxLength(255)]
        public string ResumeFileName { get; set; } = "";

        [MaxLength(255)]
        public string ResumeStoredPath { get; set; } = "";

        public DateTime DateApplied { get; set; } = DateTime.Now;
    }
}