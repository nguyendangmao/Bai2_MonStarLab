using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobNetCore6.DTOs
{
    public class CategoryDTO
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product description is required.")]
        [MaxLength(50, ErrorMessage = "Product description must not exceed 500 characters.")]
        public string? Name { get; set; }
    }
}
