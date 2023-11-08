using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.UserPlayerDTOs
{
    public class GetIdResultUserPlayerDTO
    {
        public int Id { get; set; }

        [Display(Name ="Nombre")]
        public string NamePlayer { get; set; }

        [Display(Name ="Gmail")]
        public string GmailPlayer { get; set; }

        [Display(Name ="Contraseña")]
        public string PasswordPlayer { get; set; }
    }
}
