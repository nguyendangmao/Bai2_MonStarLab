
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobNetCore6.Core.Models
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            Jobs = new Collection<Job>();

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
