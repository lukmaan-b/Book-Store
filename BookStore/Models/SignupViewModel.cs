using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SignupViewModel
    {
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Username is missing or invalid.")]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password,ErrorMessage ="Password is missing or invalid.")]
        public string Password { get; set; }
    }
}
