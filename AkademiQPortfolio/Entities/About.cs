using System.ComponentModel.DataAnnotations;

namespace AkademiQPortfolio.Entities
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }

        public string? NameSurname { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Adress { get; set; }
        public string? ImageURL { get; set; }
    }
}
