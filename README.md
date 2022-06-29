# 01-JsonFileProductService
Display JSON data on a ASP.NET Razor page by the following steps:
- adding a data source **products.json** under `wwwroot`
- adding a Model **Product.cs** which contains Product properties and customized `ToString()` method
- adding a Service **JsonFileProductService.cs** (retrieve the Json file >> Deserialize it to turn it into an array of products) 
- publishing this JsonFileProductService in **Program.cs** to tell ASP.NET that there's a service available 
  `builder.Services.AddTransient<JsonFileProductService>();`
