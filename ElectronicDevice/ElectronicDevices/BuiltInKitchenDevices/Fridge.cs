namespace ElectronicDevice.ElectronicDevices.BuiltInKitchenDevices;

public class Fridge : BuiltInDeviceBase
{
    public Fridge(double power, string name) : base(power, name)
    {
    }

    public override void TurnOn()
    {
        Console.WriteLine("Fridge is starting up...");
    }

    public override void TurnOff()
    {
        Console.WriteLine("Fridge is shutting down...\n" +
                          "Take out the food before it spoils!");
    }
}