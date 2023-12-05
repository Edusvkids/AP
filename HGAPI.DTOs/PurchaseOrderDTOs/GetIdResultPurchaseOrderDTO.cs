using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.PurchaseOrderDTOs
{
    public class GetIdResultPurchaseOrderDTO
    {
        public int Id { get; set; }
        public int IdUserPlayer { get; set; }
        public int IdProductGames { get; set; }

        [Display(Name ="Nombre")]
        public string NameOrder { get; set; }

        [Display(Name ="datos")]
        public DateTime DateOrder { get; set; }

        [Display(Name ="Titular")]
        public string Headline { get; set; }

        [Display(Name = "Total")]
        public int Total {  get; set; }
    }
}
