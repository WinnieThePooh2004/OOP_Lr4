namespace ElectronicDevice.ElectronicDevices.BuiltInKitchenDevices;

public class WashingMachine : BuiltInDeviceBase
{
    public WashingMachine(double power, string name) : base(power, name)
    {
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine("Washing machine is starting up...\n" +
                          "It is high time...");
    }

    public override void TurnOff()
    {
        Console.WriteLine("Washing machine is shutting down...\n" +
                          "Take out the clothes before they get moldy!");
    }
}