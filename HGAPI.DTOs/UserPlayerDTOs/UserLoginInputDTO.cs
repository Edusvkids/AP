using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.UserPlayerDTOs
{
    public class UserLoginInputDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        [StringLength(80, ErrorMessage = "The password must be between 5 and 32 characters.", MinimumLength = 5)]
        public string Password { get; set; }
    }
}
