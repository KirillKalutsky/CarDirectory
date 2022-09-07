using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarDirectory.Models
{
    [Index(nameof(RegisterSign), IsUnique = true)]
    public class Automobile : IdModel
    {
        public string RegisterSign { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int YearOfIssue { get; set; }
    }
}
