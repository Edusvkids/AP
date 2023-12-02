using HGAPI.Auth;
using HGAPI.Models.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Stripe;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

////////////////////////////////////////////////////////////
builder.Services.AddDALDependecies(builder.Configuration);//
////////////////////////////////////////////////////////////

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
var app = builder.Build();

app.AddEndpointDependencies();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


/****************************/
app.UseAuthentication(); // Habilita la autenticación
app.UseAuthorization(); // Habilita la autorización
/****************************/

app.Run();