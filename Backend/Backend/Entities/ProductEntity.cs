using System.ComponentModel.DataAnnotations;

namespace Backend.Entities
{
    public class ProductEntity
    {
        [Key]
        public long Id { get; set; }
        public String Brand { get; set; }
        public String Title { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
