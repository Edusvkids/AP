using HGAPI.DTOs.UserPlayerDTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace EdusvKids.WebUI.Controllers
{
	public class AccountController : Controller
	{
        readonly HttpClient _httpClient;


        public AccountController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("API");

        }

        public async Task<IActionResult> SignIn()
		{
            await HttpContext.SignOutAsync(); // cerrar la session para que pueda iniciar nuevamente 
            return View(new UserLoginInputDTO());
		}
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginInputDTO userLogin)
        {           
            var response = await _httpClient.PostAsJsonAsync("/account/signin", userLogin);
            if (response.IsSuccessStatusCode)
            {
                var user  = await response.Content.ReadFromJsonAsync<UserLoginOutputDTO>();
                var claims = new List<Claim>{                   
                    new Claim(ClaimTypes.Name, user.UserName),
                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                     new Claim("Token", user.Token),

                };
                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                };
              
               await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);
                return Redirect("/Home/Index");
            }
            else return View(userLogin);
        }

        public IActionResult SignUp()
		{
			return View(new CreateUserPlayerDTO());
		}

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserPlayerDTO user)
        {
            var response = await _httpClient.PostAsJsonAsync("/account/signup", user);
            if (response.IsSuccessStatusCode)
                return Redirect("/Account/SignIn");
            else return View(user);
        }

        // solo es demo para saber como obtener informacion del usuario que inicio session
        public IActionResult GetInfoUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userName= User.Identity.Name;
                var claimsPrincipal = User as ClaimsPrincipal;
                int idUser = 0;
                int.TryParse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value, out idUser);                
                var token = claimsPrincipal.FindFirst("Token")?.Value;

                return Json(new { IdUser = idUser, UserName = userName, Toke = token });
            }
            else
            {
                return Content("No inicio session");
            }
           
        }
    }
}
