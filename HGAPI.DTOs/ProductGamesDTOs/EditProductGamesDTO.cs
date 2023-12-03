using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.ProductGamesDTOs
{
    public class EditProductGamesDTO
    {
        public EditProductGamesDTO(GetIdResultProductGamesDTO idResultProductGamesDTO)
        {
            Id = idResultProductGamesDTO.Id;
            NameProduct = idResultProductGamesDTO.NameProduct;
            DescriptionProduct = idResultProductGamesDTO.DescriptionProduct;
            PriceProduct = idResultProductGamesDTO.PriceProduct;
            TypeProduct = idResultProductGamesDTO.TypeProduct;
        }

        public EditProductGamesDTO()
        {
            NameProduct = string.Empty;
            DescriptionProduct = string.Empty;

        }
        [Required(ErrorMessage ="El campo id es obligarorio")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener mas de 50 caracteres")]
        public string NameProduct { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "El campo Description es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Description no puede tener mas de 50 caracteres")]
        public string DescriptionProduct { get; set; }

        [Display(Name = "precio")]
        [Required(ErrorMessage = "El campo precio es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo precio no puede tener mas de 50 caracteres")]
        public int PriceProduct { get; set; }

        [Display(Name = "tipo de producto")]
        [Required(ErrorMessage = "El campo tipo de producto es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo tipo de producto no puede tener mas de 50 caracteres")]
        public string TypeProduct { get; set; }
    }
}
