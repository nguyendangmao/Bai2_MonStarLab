using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobNetCore6.Core.Models
{
    [Table("Job")]
    public class Job
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string? Content { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public bool Status { get; set; }
        [ForeignKey("CategoryId")]
        [Required]
        public int CategoryId { get; set; }
        //if it is virtual, ef can do tracking 
        public virtual Category? Category { get; set; }
    }
}
