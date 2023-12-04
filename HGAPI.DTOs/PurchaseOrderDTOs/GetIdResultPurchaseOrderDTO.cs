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

        [Display(Name ="")]
    }
}
