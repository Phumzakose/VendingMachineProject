namespace VendingMachineFunctions;


public class Manager
{


  public List<VendingMachine> registerVendingMachine = new List<VendingMachine>();

  public Dictionary<string, int> soldProducts = new Dictionary<string, int>();



  public void RegisterVendingMachine(VendingMachine vendingMachine)
  {
    registerVendingMachine.Add(vendingMachine);
  }

  public List<VendingMachine> GetVendingMachines()
  {
    return registerVendingMachine;
  }

  public int GetNumberOfVendingMachines()
  {
    int number = registerVendingMachine.Count();
    return number;
  }

  public double GetTotalIncome(VendingMachine vendingMachine, VendingMachine vendingMachine2, VendingMachine vendingMachine3)
  {
    return vendingMachine.TotalAmountOfProductsBought() + vendingMachine2.TotalAmountOfProductsBought() + vendingMachine3.TotalAmountOfProductsBought();

  }
  public Dictionary<string, int> GetAllSoldItems()
  {
    foreach (var vm in registerVendingMachine)
    {

      foreach (var item in vm.boughtItems)
      {
        if (soldProducts.ContainsKey(item.Key))
        {
          soldProducts[item.Key] += item.Value;
        }
        else
        {
          soldProducts.Add(item.Key, item.Value);
        }

      }

    }
    return soldProducts;
  }

  public String GetMostPopularProduct()
  {
    GetAllSoldItems();

    var most = soldProducts.FirstOrDefault(x => x.Value == soldProducts.Values.Max()).Key;

    return "The most popular product is " + most;
  }
  public String GetLeastPopularProduct()
  {
    GetAllSoldItems();

    var least = soldProducts.FirstOrDefault(x => x.Value == soldProducts.Values.Min()).Key;

    return "The least popular product is " + least;
  }

  public double TotalAmount()
  {
    GetAllSoldItems();
    double amount = 0;
    foreach (var item in registerVendingMachine)
    {
      amount += item.TotalAmountOfProductsBought();

    }
    return amount;
  }










}