namespace VendingMachineFunctions.Test;

public class UnitTest1
{
  VendingMachine test1 = new VendingMachine(new WallSocket(true));
  VendingMachine test2 = new VendingMachine(new SolarPower(true));
  VendingMachine test3 = new VendingMachine(new Battery(true));

  Manager user = new Manager();
  private void AddItems()
  {
    test1.AddProducts(new Chocolate("BarOne", 15.06, "140g"));
    test1.AddProducts(new Chocolate("LunchBar", 16.50, "162g"));
    test1.AddProducts(new Chips("Doritos", 17.80, "145g"));
    test1.AddProducts(new Chips("Fritos", 13.22, "25g"));
    test1.AddProducts(new Soda("Coca-Cola", 16.22, "400ml"));
    test1.AddProducts(new Soda("Fanta", 14.00, "400ml"));
    test2.AddProducts(new Chocolate("BarOne", 15.06, "140g"));
    test2.AddProducts(new Chocolate("LunchBar", 16.50, "162g"));
    test2.AddProducts(new Chips("Doritos", 17.80, "145g"));
    test2.AddProducts(new Chips("Fritos", 13.22, "25g"));
    test2.AddProducts(new Soda("Coca-Cola", 16.22, "400ml"));
    test2.AddProducts(new Soda("Fanta", 14.00, "400ml"));
    test3.AddProducts(new Chocolate("BarOne", 15.06, "140g"));
    test3.AddProducts(new Chocolate("LunchBar", 16.50, "162g"));
    test3.AddProducts(new Chips("Doritos", 17.80, "145g"));
    test3.AddProducts(new Chips("Fritos", 13.22, "25g"));
    test3.AddProducts(new Soda("Coca-Cola", 16.22, "400ml"));
    test3.AddProducts(new Soda("Fanta", 14.00, "400ml"));

  }

  public void AddVendingMachine()
  {
    user.RegisterVendingMachine(test1);
    user.RegisterVendingMachine(test2);
    user.RegisterVendingMachine(test3);
  }

  [Fact]
  public void ItShouldBeAbleToreturnProductBought()
  {
    AddItems();
    Assert.Equal("BarOne", test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g")));

  }
  [Fact]
  public void ItShouldBeAbleToReturnErrorMessageIfMoneyIsNotEnough()
  {
    AddItems();
    Assert.Equal("Your money is short", test1.BuyProduct(new Chocolate("BarOne", 10.00, "140g")));

  }
  [Fact]
  public void ItShouldBeAbleToReturnChange()
  {
    AddItems();
    Assert.Equal("R36", test1.BuyProduct(new Soda("Fanta", 50.00, "400ml")));
  }
  [Fact]
  public void ItShouldBeAbleToReturnAllTheItemsBought()
  {
    AddItems();
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test1.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test1.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test1.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));

    Assert.Equal(test1.boughtItems, test1.GetBoughtItems());
  }
  [Fact]
  public void ItShouldBeAbleToReturnThePriceOfProduct()
  {
    AddItems();
    Assert.Equal("The price of Doritos is R17.8", test1.GetPriceOfProduct("Doritos"));

  }
  [Fact]
  public void ItShouldBeAbleToReturnTheAmountOfItemsBought()
  {
    AddItems();
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test1.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test1.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test1.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));

    Assert.Equal(95.98, test1.TotalAmountOfProductsBought());
  }
  [Fact]
  public void ItShouldBeAbleToGetAllTheVendingMachines()
  {
    AddVendingMachine();

    Assert.Equal(user.registerVendingMachine, user.GetVendingMachines());

  }
  [Fact]
  public void ItShouldBeAbleToReturnAllTheNumberOfVendingMachinesAvailable()
  {
    AddVendingMachine();

    Assert.Equal(3, user.GetNumberOfVendingMachines());


  }
  [Fact]
  public void ItShouldBeAbleToReturnTotalIncomeOfAllVendingMachines()
  {
    AddItems();

    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test2.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test3.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));

    Assert.Equal(95.98, user.GetTotalIncome(test1, test2, test3));

  }


  [Fact]
  public void ItShouldReturnList()
  {
    AddVendingMachine();
    AddItems();
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test1.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test1.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));

    Assert.Equal(user.soldProducts, user.GetAllSoldItems());

  }
  [Fact]
  public void ItShouldReturnTheMostPopular()
  {
    AddVendingMachine();
    AddItems();
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test1.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test1.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));

    Assert.Equal("The most popular product is LunchBar", user.GetMostPopularProduct());

  }

  [Fact]
  public void ItShouldBeAbleToReturnTheLeastPopularProduct()
  {
    AddVendingMachine();
    AddItems();
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test1.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test1.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));

    Assert.Equal("The least popular product is BarOne", user.GetLeastPopularProduct());

  }
  [Fact]

  public void GetTotalAmountOfAllVendingMachinesBoughtItems()
  {
    AddVendingMachine();
    AddItems();
    test1.BuyProduct(new Chocolate("BarOne", 15.06, "140g"));
    test1.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test1.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test3.BuyProduct(new Chips("Doritos", 17.80, "145g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    test2.BuyProduct(new Chocolate("LunchBar", 16.50, "162g"));
    Assert.Equal(135.76, user.TotalAmount());

  }
}