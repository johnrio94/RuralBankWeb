using System.ComponentModel.DataAnnotations;

namespace RuralBankWeb.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string? UnitId { get; set; } = "";

        [Required, MaxLength(100)]
        public string Description { get; set; } = "";

        [Required, MaxLength(50)]
        public string Category { get; set; } = "";

        [Required]
        public int ModelYear { get; set; }

        [MaxLength(50)]
        public string? Mileage { get; set; } = "";

        [MaxLength(100)]
        public string? IndicativePrice { get; set; } = "Contact Us";

        [Required, MaxLength(20)]
        public string Status { get; set; } = "Available";

        public bool IsActive { get; set; } = true;

        public int SortOrder { get; set; } = 0;

        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}