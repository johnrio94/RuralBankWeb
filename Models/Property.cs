using System.ComponentModel.DataAnnotations;

namespace RuralBankWeb.Models
{
    public class Property
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string? PropertyId { get; set; } = "";

        [Required, MaxLength(50)]
        public string PropertyType { get; set; } = "";

        [Required, MaxLength(150)]
        public string Location { get; set; } = "";

        [Required, MaxLength(50)]
        public string LotArea { get; set; } = "";

        [MaxLength(100)]
        public string? IndicativePrice { get; set; } = "Contact Us";

        [Required, MaxLength(20)]
        public string Status { get; set; } = "Available";

        public bool IsActive { get; set; } = true;

        public int SortOrder { get; set; } = 0;

        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}