using HGAPI.Endpoints;
using HGAPI.Models.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

////////////////////////////////////////////////////////////
builder.Services.AddDALDependecies(builder.Configuration);//
////////////////////////////////////////////////////////////




var app = builder.Build();

app.AddUserPlayerEndpoints();

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