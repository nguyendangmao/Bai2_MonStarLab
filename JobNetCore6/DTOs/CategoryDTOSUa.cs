using System.ComponentModel.DataAnnotations;

namespace JobNetCore6.DTOs
{
    public class CategoryDTOSUa
    {
        [Required(ErrorMessage = "Product description is required.")]
        [MaxLength(5, ErrorMessage = "Product description must not exceed 500 characters.")]

        public string? Name { get; set; }
    }
}
