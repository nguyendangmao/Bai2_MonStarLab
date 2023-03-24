using System.ComponentModel.DataAnnotations;

namespace JobNetCore6.DTOs
{
    public class CategoryDTOSUa
    {
        [Required(ErrorMessage = "Categories description is required.")]
        [MaxLength(50, ErrorMessage = "Categories description must not exceed 50 characters.")]

        public string? Name { get; set; }
    }
}
