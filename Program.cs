using Microsoft.AspNetCore.Http;
using System.Text.Json;
using WebApplication1.Models;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Publish the JsonFileProductService in ASP.NET, basically tell everyone in the restaurant that there's a service available
// Transient is the thing that comes and goes, so you'll get a NEW one of these service times you ask for it.
builder.Services.AddTransient<JsonFileProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.MapGet("/products", (context) =>
{
    var products = app.Services.GetService<JsonFileProductService>().GetProducts();
    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
    context.Response.ContentType = "application/json"; //tell the browser you're sending JSON data and most browsers will format it for you
    return context.Response.WriteAsync(json); 
});

app.Run();
