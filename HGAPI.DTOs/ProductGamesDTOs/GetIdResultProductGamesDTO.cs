using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.ProductGamesDTOs
{
    public class GetIdResultProductGamesDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string NameProduct { get; set; }

        [Display(Name = "Description")]
        public string DescriptionProduct { get; set; }

        [Display(Name = "precio")]
        public int PriceProduct { get; set; }

        [Display(Name = "tipo de producto")]
        public string TypeProduct { get; set; }
    }
}
