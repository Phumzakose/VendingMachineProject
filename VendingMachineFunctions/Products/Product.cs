namespace VendingMachineFunctions;
public class Product
{
  public string? ProductName { get; set; }
  public double ProductPrice { get; set; }
  public string? ProductSize { get; set; }

  public Product(string productName, double productPrice, string productSize)
  {
    ProductName = productName;
    ProductPrice = productPrice;
    ProductSize = productSize;

  }
}
