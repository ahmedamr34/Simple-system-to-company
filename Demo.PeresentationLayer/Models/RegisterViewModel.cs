using System.ComponentModel.DataAnnotations;

namespace Demo.PeresentationLayer.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare("Password", ErrorMessage = "Confirm Password does not match password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }
    }
}
