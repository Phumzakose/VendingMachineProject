namespace VendingMachineFunctions;

public class VendingMachine
{

  public IPowerSource PowerSource { get; private set; }

  public VendingMachine(IPowerSource power)
  {
    PowerSource = power;

    Console.WriteLine($"Powering Vending Machine using: ${power.GetDescription()}.");

  }


  List<Product> products = new List<Product>();
  public Dictionary<string, int> boughtItems = new Dictionary<string, int>();

  double totalAmount = 0;
  double change = 0;
  int counter = 1;

  public void AddProducts(Product item)
  {
    products.Add(new Chips(item.ProductName!, item.ProductPrice, item.ProductSize!));
    products.Add(new Chocolate(item.ProductName!, item.ProductPrice, item.ProductSize!));
    products.Add(new Soda(item.ProductName!, item.ProductPrice, item.ProductSize!));
  }
  public List<Product> GetProducts()
  {
    return products;
  }

  public string BuyProduct(Product item)
  {

    if (PowerSource.PowerIsOn())
    {
      string message = "";
      var product = products.Find(x => x.ProductName == item.ProductName);
      if (product != null && product.ProductPrice == item.ProductPrice)
      {
        totalAmount += product.ProductPrice;
        message = product.ProductName!;
        if (boughtItems.ContainsKey(product.ProductName!))
        {
          boughtItems[product.ProductName!]++;
        }
        else
        {
          boughtItems.Add(product.ProductName!, counter);
        }
      }
      else if (product != null && product.ProductPrice < item.ProductPrice)
      {
        change = item.ProductPrice - product.ProductPrice;

        message = "R" + change;
      }
      else if (product != null && product.ProductPrice > item.ProductPrice)
      {
        message = "Your money is short";
      }
      return message;
    }
    else
    {
      return "Power is off";

    }
  }
  public Dictionary<string, int> GetBoughtItems()
  {
    return boughtItems;
  }

  public string GetPriceOfProduct(string product)
  {
    if (PowerSource.PowerIsOn())
    {

      string message = "";
      var item = products.Find(x => x.ProductName == product);
      if (item != null)
      {
        message = "The price of " + item.ProductName + " is " + item.ProductPrice;
      }
      return message;

    }
    else
    {
      return "Power is off";
    }

  }

  public double TotalAmountOfProductsBought()
  {
    return totalAmount;
  }










}