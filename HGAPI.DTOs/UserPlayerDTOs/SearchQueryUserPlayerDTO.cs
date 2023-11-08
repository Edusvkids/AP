using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.UserPlayerDTOs
{
    public class SearchQueryUserPlayerDTO
    {
        [Display(Name ="Nombre")]
        public string? NamePlayer_Like { get; set; }

        [Display(Name ="Gmail")]
        public string? GmailPlayer_Like { get; set; }

        [Display(Name ="Pagina")]
        public int Skip { get; set; }

        [Display(Name ="CantReg X pagina")]
        public int Take { get; set; }

        public byte SendRowCount { get; set; }
    }
}
