using HGAPI.DTOs.PurchaseOrderDTOs;
using HGAPI.Models.EN;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;
using static HGAPI.DTOs.PurchaseOrderDTOs.SearchResultPurchaseOrderDTO;
namespace EdusvKids.WebUI.Controllers
{
    public class CheckOutController : Controller
    {
        readonly HttpClient _httpClient;
        public CheckOutController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("API");

        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> OrderConfirmation()
        {
            var service = new SessionService();
            Session session = service.Get(TempData["Session"].ToString());


            if (session.PaymentStatus == "paid")
            {
                var transaction = session.PaymentIntentId.ToString();
                var response = await _httpClient.PutAsJsonAsync("/order", new { NumOrder= TempData["NumOrder"].ToString() });
                if (response.IsSuccessStatusCode)
                {
                    return View("Succes");
                }                   
            }
            return View("Login");
        }

        public IActionResult Succes()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public async Task<IActionResult> CheckOut( string productName, decimal price, int total, int Id)
        {

            int amount = (int)total / (int)price;

            DateTime now = DateTime.Now;
            var claimsPrincipal = User as ClaimsPrincipal;
            int idUser = 0;
            int.TryParse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value, out idUser);
            string numOrder = Guid.NewGuid().ToString();
            CreatePurchaseOrderDTO purchaseOrderDTO = new CreatePurchaseOrderDTO
            {
                IdProductGames = Id,
                IdUserPlayer = idUser,
                NameOrder = numOrder,
                DateOrder=DateTime.Now,
                Headline=productName,
                Total = total
            };
            var response = await _httpClient.PostAsJsonAsync("/order", purchaseOrderDTO);
            if (response.IsSuccessStatusCode)
            {
                var domain = "https://paymentgateway.somee.com/";

                var options = new SessionCreateOptions
                {
                    SuccessUrl = domain + $"CheckOut/OrderConfirmation/",
                    CancelUrl = domain + "CheckOut/Login",
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment"
                };

                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        UnitAmount = (long)(price * 100),
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = productName.ToString(),
                        }
                    },
                    Quantity = amount
                };

                options.LineItems.Add(sessionListItem);


                var service = new SessionService();
                Session session = service.Create(options);

                TempData["Session"] = session.Id;
                TempData["NumOrder"] = numOrder;

                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);
            }      
            else
                return View("Error");

        }
    }
}
