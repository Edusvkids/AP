using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();




builder.Services.AddHttpClient("API", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["APIS:HGAPI"]);
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {     
        options.LoginPath = "/Account/Login"; // Ruta de inicio de sesión
        // Configura el nombre del parámetro de URL para redireccionamiento no autorizado        
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Habilita la autenticación
app.UseAuthorization(); // Habilita la autorización

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Vida}/{id?}");

app.Run();
