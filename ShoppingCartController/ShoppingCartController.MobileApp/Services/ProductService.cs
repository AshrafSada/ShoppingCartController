using Newtonsoft.Json;
using ShoppingCartController.MobileApp.Models;

namespace ShoppingCartController.MobileApp.Services;

public class ProductService
{
    public static async Task<List<Product>> GetProductsAsync() => await ProductService.GetFromLocalFileAsync();

    private static async ValueTask<List<Product>> GetFromLocalFileAsync()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("productData.json");
        using var reader = new StreamReader(stream);
        var fileContents = await reader.ReadToEndAsync();
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        var result = JsonConvert.DeserializeObject<List<Product>>(fileContents, settings);
        return result!;
    }
}
