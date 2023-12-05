using Microsoft.VisualBasic;

namespace HGAPI.Models.EN
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public int IdUserPlayer { get; set; }
        public int IdProductGames { get; set; }
        public string NameOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public string Headline { get; set; }
        public string StateOrder { get; set; }
        public int Total {  get; set; }
    }
}
