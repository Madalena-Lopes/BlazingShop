//using BlazingShop.Data;

using BlazingShop.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(); //<-------------
//builder.Services.AddSingleton<WeatherForecastService>(); //servi�o de demonstra��o

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(cnnStr));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); //usamos em ASP.NET, minimal API, MVC

app.UseStaticFiles(); //servir arquivos est�ticos

app.UseRouting(); //rotas

app.MapBlazorHub();//<------------- Hub=centro do signalR - forma como trabalha, como fica ligado
app.MapFallbackToPage("/_Host"); //garante a p�gina _Host, p�gina do index da nossa aplica��o. 

app.Run();
