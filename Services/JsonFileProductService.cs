using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class JsonFileProductService //【最终目标：get the JSON file and turn it into an enumerable or array of products！】
    {
        //Constructor
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        //get the webHostEnvironment passed in and then keep it
        public IWebHostEnvironment WebHostEnvironment { get; }

        //let the Web Host Environment know the path where this file comes from - wwwroot/data/products.json
        //因为大家的电脑都不一样，.WebRootPath（wwwroot）有可能在C盘或D盘，以后就算是挪动到其他地方，我们也不想损坏路径。所以需先declare一个WebHostEnvironment来获取web app运行所在地址
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }


        //retrieve the JSON file, "Deserialize" means convert the JSON file into an array of Product[]
        //IEnumerable - List的祖祖先，也就是说我可以使用List或Array或collection，完全取决于我，在这里return的是array
        public IEnumerable<Product> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
#pragma warning disable CS8603 // Possible null reference return.
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }
}
