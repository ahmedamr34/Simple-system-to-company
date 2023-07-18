using System.ComponentModel.DataAnnotations;

namespace Demo.PeresentationLayer.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5 , ErrorMessage ="Minimum Password Length is 5")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        //[Required(ErrorMessage = "Confirm Password is Required")]
        //[Compare("Password", ErrorMessage = "Confirm Password does not match password")]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }
    }
}
