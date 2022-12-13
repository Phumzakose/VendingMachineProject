namespace VendingMachineFunctions;

public abstract class PowerSource : IPowerSource
{

  private bool isOn = false;

  public PowerSource() : this(false)
  {

  }

  public PowerSource(bool isOn)
  {
    this.isOn = isOn;
  }

  public void SwitchOn()
  {
    isOn = true;
  }

  public void SwitchOff()
  {
    isOn = false;
  }

  public abstract string GetDescription();

  public bool PowerIsOn()
  {
    return isOn;
  }
}