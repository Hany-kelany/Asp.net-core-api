using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[]? Image { get; set; }

        [ForeignKey("category")]
        public int CategoryId { get; set; }

        public Category? category  { get; set; }

    }
}
