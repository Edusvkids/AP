using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.ProductGamesDTOs
{
    public class SearchResultProductGamesDTO
    {
        public int CountRow { get; set; }
        public List<ProductGamesDTO> Data { get; set; }
        public class ProductGamesDTO
        {
            public int Id { get; set; }

            [Display(Name ="Nombre")]
            public string NameProduct { get; set; }

            [Display(Name = "Description")]
            public string DescriptionProduct { get; set; }

            [Display(Name = "precio")]
            public int PriceProduct { get; set; }

            [Display(Name = "Tipo")]
            public string TypeProduct { get; set; }
        }
    }
}
