using System.ComponentModel.DataAnnotations;

namespace registrationform.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage="Enter username")]
        public string Name {  get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

    }
}
