using HGAPI.DTOs.UserPlayerDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EdusvKids.WebUI.Controllers
{
	public class AccountController : Controller
	{
        readonly HttpClient _httpClient;


        public AccountController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("API");

        }

        public IActionResult SignIn()
		{
			return View(new UserLoginInputDTO());
		}
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginInputDTO userLogin)
        {
            var response = await _httpClient.PostAsJsonAsync("/account/signin", userLogin);
            if (response.IsSuccessStatusCode)
                return Redirect("/Home/Index");
            else return View(userLogin);
        }

    }
}
