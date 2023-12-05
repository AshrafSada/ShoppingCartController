using System.Collections.ObjectModel;
using System.Diagnostics;
using ShoppingCartController.MobileApp.Models;
using ShoppingCartController.MobileApp.Services;

namespace ShoppingCartController.MobileApp.ViewModels;

public class ProductViewModel : BaseViewModel
{
    public ObservableCollection<Product> ProductsCollection { get; } = [];
    public Command LoadProductsCommand { get; }

    private readonly ProductService _productService;

    public ProductViewModel(ProductService productService)
    {
        Title = "Products";
        _productService = productService;
        LoadProductsCommand = new Command(async () => await GetProductsAsync());
    }

    private async Task GetProductsAsync()
    {
        await Task.Delay(3000); // simulate a bit of startup work
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            // get products from the service
            var products = await ProductService.GetProductsAsync();

            // clear the existing products
            if (products.Count > 0)
                ProductsCollection.Clear();

            // add retrieved products to the collection
            foreach (var product in products)
                ProductsCollection.Add(product);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex}");
            await Application.Current!.MainPage!.DisplayAlert("Service Error",
                  "An error occurred while getting data from service!",
                  "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
