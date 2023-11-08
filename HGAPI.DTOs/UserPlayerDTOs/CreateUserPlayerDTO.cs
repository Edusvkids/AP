using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.UserPlayerDTOs
{
    public class CreateUserPlayerDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        [MaxLength(50,ErrorMessage ="El Campo Nombre no puede tener mas de 50 carateres.")]
        public string NamePlayer { get; set; }

        [Display(Name = "Gmail")]
        [Required(ErrorMessage = "El campo Gmail es obligatorio")]
        [MaxLength(50, ErrorMessage = "El Campo Gmail no puede tener mas de 50 carateres.")]
        public string GmailPlayer { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        [MaxLength(50, ErrorMessage = "El Campo contraseña no puede tener mas de 50 carateres.")]
        public string PasswordPlayer { get; set; }
    }
}
