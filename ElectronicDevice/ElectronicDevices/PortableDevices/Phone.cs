using ElectronicDevice.ElectronicDevices.Chargers;

namespace ElectronicDevice.ElectronicDevices.PortableDevices;

public class Phone : PortableDeviceBase
{
    public Phone(double power, string name) :
        base(power, name)
    {
    }

    protected override double DefaultBatteryUsage => 0.01;
    protected override double TurnedOffBatteryUsage => 0.012;
    protected override ChargerBase? FindBestCharger()
    {
        return PossibleChargers.Where(ch => ch is { PluggedIn: true, IsInUseNow: false })
            .MaxBy(ch => ch.Power);
    }

    public override void AddCharger(ChargerBase charger)
    {
        if (charger is not PhoneCharger)
        {
            Console.WriteLine("Please, select a phone charger");
            return;
        }
        base.AddCharger(charger);
    }
}