using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.UserPlayerProductDTOs
{
    public class SearchQueryUserPlayerProductDTO
    {
        [Display(Name ="Nombre")]
        public string? NamePlayer__Like { get; set; }

        [Display(Name = "gmail")]
        public string? GmailPlayer__Like { get; set; }

        [Display(Name = "pagina")]
        public int skipe {  get; set; }

        [Display(Name = "CantReg X Pagina")]
        public int take { get; set; }

        public byte SeadRowCount { get; set; }
    }
}
