namespace ShoppingCartController.MobileApp.Models;

public class Product
{
    public int Id { get; set; }
    public string Barcode { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = null!;
}
