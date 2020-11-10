using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SigninViewModel
    {
        [Required]
        [DataType(DataType.Text, ErrorMessage = "Username is missing or invalid.")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password is missing or invalid.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
