> Based on ASP.Net Core Web API

#### Reference
 
* [Create ASP.Net Core Web API](https://docs.microsoft.com/zh-cn/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.0&tabs=visual-studio-code) 
* [Official Config Example](https://github.com/RicoSuter/NSwag/blob/master/samples/WithMiddleware/Sample.AspNetCore21.Nginx/Startup.cs)

#### Tutorial

##### Install Dependencies

* `dotnet add package NSwag.AspNetCore --version 13.2.0`

##### Code

* **ConfigureServices()** Add `services.AddOpenApiDocument();`

* **Configure()** Add 
```
app.UseOpenApi();
app.UseSwaggerUi3();
```

* Add other namespaces if necessary

##### Create Controller to Test Swagger Configuration

* `dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers`

#### Build and Run! Have Fun!
