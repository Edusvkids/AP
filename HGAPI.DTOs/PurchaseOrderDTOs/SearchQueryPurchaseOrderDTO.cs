using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.PurchaseOrderDTOs
{
    public class SearchQueryPurchaseOrderDTO
    {
        [Display(Name ="Nombre")]
        public string? NameOrder__Like { get; set; }

        [Display(Name ="Titular")]
        public string? Headline__Like { get; set; }

        [Display(Name ="Pagina")]
        public int Skip {  get; set; }

        [Display(Name ="CanReg X Pagina")]
        public int Take { get; set; }

        public byte SendRowCount { get; set; }
    }
}
