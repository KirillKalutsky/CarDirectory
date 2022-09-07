using System.ComponentModel.DataAnnotations;

namespace CarDirectory.Models.Dto
{
    public class AutomobileDto
    {
        [Required]
        public string RegisterSign { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int YearOfIssue { get; set; }
    }
}
