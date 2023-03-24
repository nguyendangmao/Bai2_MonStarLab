using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace JobNetCore6.DTOs
{
    public class JobDTO
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bạn không đực bỏ trống cho trường này")]
        [MaxLength(250, ErrorMessage = "bạn không đực nhập quá 250 kí tự")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Bạn không đực bỏ trống cho trường này")]
        [MaxLength(250, ErrorMessage = "Product description must not exceed 500 characters.")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "Bạn không đực bỏ trống cho trường này")]
        public DateTime DateStart { get; set; }
        [Required(ErrorMessage = "Bạn không đực bỏ trống cho trường này")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập mã  thể loại")]
        public int CategoryId { get; set; }
    }
}
