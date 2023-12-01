using HGAPI.DTOs.UserPlayerProductDTOs;
using System.ComponentModel.DataAnnotations;
namespace HGAPI.DTOs.UserPlayerProductDTOs
{
    public class EditUserPlayerProductDTO
    {
        public EditUserPlayerProductDTO(GetldResultUserPlayerProductDTO getldResultUserPlayerProductDTO)
        {
            Id = getldResultUserPlayerProductDTO.Id;
            NamePlayer = getldResultUserPlayerProductDTO.NamePlayer;
            GmailPlayer = getldResultUserPlayerProductDTO.GmailPlayer;
            PruductStatus = getldResultUserPlayerProductDTO.PruductStatus;
        }

        public EditUserPlayerProductDTO()
        {
            NamePlayer = string.Empty;
            GmailPlayer = string.Empty;
            PruductStatus = string.Empty;
        }
        [Required(ErrorMessage ="El campo Id es obligatorio")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres.")]
        public string NamePlayer { get; set; }

        [Display(Name = "gmail")]
        [Required(ErrorMessage = "El campo gmail es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres.")]
        public string GmailPlayer { get; set; }

        [Display(Name = "estatus")]
        [Required(ErrorMessage = "El campo estatus es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo no debe de tener mas de 50 caracteres.")]
        public string PruductStatus { get; set; }
    }
}
