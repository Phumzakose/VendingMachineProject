namespace VendingMachineFunctions;

public class SolarPower : PowerSource
{

  public SolarPower(bool isOn) : base(isOn)
  {

  }

  public override string GetDescription()
  {
    return "Using Solar Power";
  }
}


