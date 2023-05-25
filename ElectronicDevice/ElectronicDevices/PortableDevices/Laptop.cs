using ElectronicDevice.ElectronicDevices.Chargers;

namespace ElectronicDevice.ElectronicDevices.PortableDevices;

public class Laptop : PortableDeviceBase
{
    public Laptop(double power, string name) :
        base(power, name)
    {
    }

    protected override double DefaultBatteryUsage => 0.02;
    protected override double TurnedOffBatteryUsage => 0.025;

    protected override ChargerBase? FindBestCharger()
    {
        return PossibleChargers.Where(ch => ch is { PluggedIn: true, IsInUseNow: false })
            .MaxBy(ch => ch.Power);
    }

    public override void TurnOff()
    {
        Console.WriteLine("Laptop is shutting down...");
    }

    public override void TurnOn()
    {
        Console.WriteLine("Launching Windows...");
    }

    public override void AddCharger(ChargerBase charger)
    {
        if (charger is not LaptopCharger)
        {
            Console.WriteLine("Please, add laptop charger");
            return;
        }
        base.AddCharger(charger);
    }
}