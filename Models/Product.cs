using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Product
    {
        public string? Id { get; set; }
        public string? Maker { get; set; }
        [JsonPropertyName("img")] //to map "img" in Json file to Image property
        public string? Image { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int[]? Ratings { get; set; }

        public override string ToString()
        {
            //convert all of this object information back to the JSON shape of text,
            //"Serialize" means take products one after another to return a nice string
            return JsonSerializer.Serialize<Product>(this);
        }

        //shorthand：
        //public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
