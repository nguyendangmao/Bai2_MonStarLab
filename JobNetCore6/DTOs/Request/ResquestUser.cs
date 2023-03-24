using System.ComponentModel.DataAnnotations;

namespace JobNetCore6.DTOs.Request
{
    public class ResquestUser
    {
        [Required(ErrorMessage = "Name description is required.")]
        [MaxLength(255, ErrorMessage = "Name description must not exceed 255 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Password description is required.")]
        [MaxLength(255, ErrorMessage = "Password description must not exceed 255 characters.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "AccountType description is required.")]
        [MaxLength(255, ErrorMessage = "AccountType description must not exceed 255 characters.")]
        public string? AccountType { get; set; }

        [Required(ErrorMessage = "UserRole description is required.")]
        [MaxLength(255, ErrorMessage = "UserRole description must not exceed 255 characters.")]

        public string? UserRole { get; set; }

        [Required(ErrorMessage = "IsDeleted description is required.")]
        public bool? IsDeleted { get; set; }
    }
}
