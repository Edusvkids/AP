using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.ProductGamesDTOs
{
    public class SearchQueryProductGamesDTO
    {
        [Display(Name ="Nombre")]
        public string? NameProduct__like {  get; set; }

        [Display(Name ="Description")]
        public string? DescriptionProduct__like { get; set;}

        [Display(Name ="pagina")]
        public int Skipe {  get; set; }

        [Display(Name = "CantRed X Pagina")]
        public int Take { get; set; }

        public byte SeandRowCount { get; set; }
    }
}
