using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobNetCore6.DTOs.Request
{
    public class ResquestCategoryAdd
    {
        
        [Required]
        [MaxLength(255,ErrorMessage ="bạn k dc nhap qua 255 ki tự")]
        public string? Name { get; set; }
    }
}
