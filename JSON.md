
> JSON Serialize & Deserialize

```
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace TodoApi
{
    public class CSharpJson
    {
        public static string Serialize()
        {
            var product = new Product {Factory = Factory.Stephens, Name = "Soap", Price = 0.99};

            var result = JsonConvert.SerializeObject(product);

            return result;
        }
        
        public static void Deserialize()
        {
            var json = @"{'Factory':'Johns','Name':'Soap','Price':0.99}";
            var product = JsonConvert.DeserializeObject<Product>(json);

            var name = product.Name;
            var price = product.Price;
            var factory = product.Factory;
            
            Console.WriteLine(name);
            Console.WriteLine(price);
            Console.WriteLine(factory);
        }
    }

    public class Product
    {
        public Factory Factory;

        public string Name;
        public double Price;
    }

    // enum: convert index to string 
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Factory
    {
        Johns,
        Stephens
    }
    
    
}
```

