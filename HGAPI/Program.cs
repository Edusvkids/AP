using HGAPI.Endpoints;
using HGAPI.Models.DAL;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

////////////////////////////////////////////////////////////
builder.Services.AddDALDependecies(builder.Configuration);//
////////////////////////////////////////////////////////////

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();


var app = builder.Build();

app.AddEndpointDependencies();
app.AddProductGamesEndPoints();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


/****************************/
app.UseAuthentication();//////
app.UseAuthorization();///////
/****************************/

app.Run();