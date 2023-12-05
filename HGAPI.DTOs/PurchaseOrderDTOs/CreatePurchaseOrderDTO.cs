using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.PurchaseOrderDTOs
{
    public class CreatePurchaseOrderDTO
    {
        [Display(Name = "id usuario")]
        [Required(ErrorMessage = "El campo id usuario es obligario,")]
        [MaxLength(50, ErrorMessage = "El campo id usuario solo puede tener 50 caracteres.")]
        public int IdUserPlayer { get; set; }

        [Display(Name = "id producto")]
        [Required(ErrorMessage = "El campo id porducto es obligario,")]
        [MaxLength(50, ErrorMessage = "El campo id producto solo puede tener 50 caracteres.")]
        public int IdProductGames { get; set; }

        [Display(Name ="Nombre")]
        [Required(ErrorMessage ="El campo nombre es obligario,")]
        [MaxLength(50, ErrorMessage ="El campo nombre solo puede tener 50 caracteres.")]
        public string NameOrder { get; set; }

        [Display(Name = "Datos")]
        [Required(ErrorMessage = "El campo datos es obligario,")]
        [MaxLength(50, ErrorMessage = "El campo datos solo puede tener 50 caracteres.")]
        public DateTime DateOrder { get; set; }

        [Display(Name = "Titular")]
        [Required(ErrorMessage = "El campo Titular es obligario,")]
        [MaxLength(30, ErrorMessage = "El campo Titular solo puede tener 30 caracteres.")]
        public string Headline { get; set; }

        [Display(Name = "estado")]
        [Required(ErrorMessage = "El campo estado es obligario,")]
        [MaxLength(50, ErrorMessage = "El campo estado solo puede tener 50 caracteres.")]
        public string StateOrder { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "El campo total es obligario,")]
        [MaxLength(30, ErrorMessage = "El campo total solo puede tener 30 caracteres.")]
        public int Total {  get; set; }
    }
}
