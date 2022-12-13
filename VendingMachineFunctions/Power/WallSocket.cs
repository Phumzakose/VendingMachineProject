namespace VendingMachineFunctions;

public class WallSocket : PowerSource
{
  public WallSocket(bool isOn) : base(isOn)
  {

  }
  public override string GetDescription()
  {
    return "Using Electricity";
  }

}