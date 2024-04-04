using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Homework_Product.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Please enter your real name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your lastname")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Please enter your real lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your phone")]
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Incorrect password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Choose your password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please repeat your password")]
        [Compare("NewPassword", ErrorMessage = "That does not match the password you entered above")]
        public string NewPasswordConfirmation { get; set; }

    }
}
