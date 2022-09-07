using System.ComponentModel.DataAnnotations;

namespace CarDirectory.Models
{
    public class IdModel
    {
        public IdModel()
        {
            Id = Guid.NewGuid();
            Create = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; private set; }
        public DateTime Create { get; private set; }
    }
}
