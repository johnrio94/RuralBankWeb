// using System.ComponentModel.DataAnnotations;

// namespace RuralBankWeb.Models
// {
//     public class PageSection
//     {
//         public int Id { get; set; }

//         [Required, MaxLength(50)]
//         public string PageKey { get; set; } = ""; // e.g. "Career", "About", "News"

//         [Required, MaxLength(50)]
//         public string SectionKey { get; set; } = ""; // e.g. "Hero", "Intro", "Requirements"

//         [MaxLength(200)]
//         public string Heading { get; set; } = "";

//         [MaxLength(200)]
//         public string Subheading { get; set; } = "";

//         public string Body { get; set; } = "";

//         [MaxLength(300)]
//         public string ImageUrl { get; set; } = "";

//         public int SortOrder { get; set; } = 0;
//     }
// }



using System.ComponentModel.DataAnnotations;

namespace RuralBankWeb.Models
{
    public class PageSection
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string PageKey { get; set; } = "";

        [Required, MaxLength(50)]
        public string SectionKey { get; set; } = "";

        [MaxLength(200)]
        public string? Heading { get; set; }

        [MaxLength(200)]
        public string? Subheading { get; set; }

        public string? Body { get; set; }

        [MaxLength(300)]
        public string? ImageUrl { get; set; }

        public int SortOrder { get; set; } = 0;
    }
}


