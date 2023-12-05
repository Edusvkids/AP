using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
namespace EdusvKids.WebUI.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OrderConfirmation()
        {
            var service = new SessionService();
            Session session = service.Get(TempData["Session"].ToString());


            if (session.PaymentStatus == "paid")
            {
                var transaction = session.PaymentIntentId.ToString();
                return View("Succes");
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
        public IActionResult CheckOut(string productName, decimal price, decimal total, int Id)
        {

            int amount = (int)total / (int)price;

            DateTime now = DateTime.Now;

            //CreateOrderInputDTOs order = new CreateOrderInputDTOs()
            //{
            //    DateOrder = now,
            //    Quantity = amount,
            //    email = "CryptoCurrenciesStripe@gmail.com",
            //    product_id = Id,
            //    total = total
            //};

           // var setOrder = _orderBL.AddOrder(order);


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

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

        }
    }
}
