using System.ComponentModel.DataAnnotations;

namespace InkWorks.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Introduza o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introduza a password")]
        public string Password { get; set; }
    }
}
