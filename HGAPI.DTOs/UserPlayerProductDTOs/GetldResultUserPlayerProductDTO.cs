using System.ComponentModel.DataAnnotations;

namespace HGAPI.DTOs.UserPlayerProductDTOs
{
    public class GetldResultUserPlayerProductDTO
    {
        public int Id { get; set; }

        [Display(Name ="nombre")]
        public string NamePlayer { get; set; }

        [Display(Name = "gmail")]
        public string GmailPlayer { get; set; }

        [Display(Name = "estatus")]
        public string PruductStatus { get; set; }
    }
}
