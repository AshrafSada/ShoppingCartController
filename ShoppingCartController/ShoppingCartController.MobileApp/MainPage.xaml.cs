using ShoppingCartController.MobileApp.Models;
using ShoppingCartController.MobileApp.Services;
using ShoppingCartController.MobileApp.ViewModels;
using ShoppingCartController.MobileApp.Views;

namespace ShoppingCartController.MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(ProductViewModel productViewModel)
        {
            BindingContext = productViewModel;
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            var product = ((VisualElement)sender).BindingContext as Product;

            if (product is null)
                return;

            await Shell.Current.GoToAsync(nameof(ProductDetailsPage), true,
                new Dictionary<string, object>()
                {
                    { nameof(Product), product }
                });
        }
    }
}
