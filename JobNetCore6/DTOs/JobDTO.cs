using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace JobNetCore6.DTOs
{
    public class JobDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }

        public DateTime DateStart { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
    }
}
