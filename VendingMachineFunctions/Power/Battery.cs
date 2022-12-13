namespace VendingMachineFunctions;

public class Battery : PowerSource
{
  public Battery(bool isOn) : base(isOn)
  {

  }
  public override string GetDescription()
  {
    return "Using Battery";
  }
}