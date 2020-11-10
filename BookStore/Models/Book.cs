using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        [Range(0,int.MaxValue,ErrorMessage ="Stock cannot be below 0")]
        public int? Stock { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
