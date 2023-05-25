namespace ElectronicDevice.ElectronicDevices.Chargers;

public abstract class ChargerBase : ElectronicDeviceBase
{
    protected ChargerBase(double power, string name) : base(power, name)
    {
    }

    public bool IsInUseNow { get; set; }

    public override void TurnOn()
    {
        // this device does not require to be turned on
    }

    public override void TurnOff()
    {
        // this device does not require to be turned off
    }
}