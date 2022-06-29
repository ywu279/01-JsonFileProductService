# 01-JsonFileProductService
Display JSON data on a ASP.NET Razor page by the following steps:
- adding a data source **products.json** under `wwwroot`
- adding a Model **Product.cs** which contains Product properties and customized `ToString()` method
- adding a Service **JsonFileProductService.cs** (retrieve the Json file >> Deserialize it to turn it into an array of products) 
- publishing this JsonFileProductService in **Program.cs** to tell ASP.NET that there's a service available 
  `builder.Services.AddTransient<JsonFileProductService>();`

## Acknowledgements
This project is basically an learning outcome of [ASP.NET Core 101](https://youtu.be/lE8NdaX97m0?list=PLdo4fOcmZ0oW8nviYduHq7bmKode-p8Wy).
Product.json and other code can be found [here](https://gist.github.com/bradygaster/3d1fcf43d1d1e73ea5d6c1b5aab40130#file-products-json)
