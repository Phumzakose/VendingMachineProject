namespace VendingMachineFunctions;

public interface IPowerSource
{
  bool PowerIsOn();

  string GetDescription();

  void SwitchOn();

  void SwitchOff();
}