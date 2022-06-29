using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductService;
        public IEnumerable<Product> Products { get; private set; }

        //Constructor
        //You might want to log this to the firewall/Azure/Cloud, etc
        //Logging is a service available to you by ASP.NET. No need to make a logger, simply ask for one by listing it in your arguments
        public IndexModel(
            ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public void OnGet()
        {
            //ask for JsonFileProductService and hold it in a varible called "Products"
            //Now index page knows about products.json data
            Products = ProductService.GetProducts();
        }
    }
}