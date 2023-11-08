using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.UserPlayerDTOs
{
    public class SearchResultUserPlayerçDTO
    {
        public int CoutRow {  get; set; }
        public List<UserPlayerDTO> Data { get; set; }
        public class UserPlayerDTO
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
}
