namespace ElectronicDevice.ElectronicDevices;

public abstract class ElectronicDeviceBase : IComparable<ElectronicDeviceBase>
{
    protected ElectronicDeviceBase(double power, string name)
    {
        Power = power;
        Name = name;
    }

    public virtual bool PluggedIn { get; set; }

    public double Power { get; }
    public string Name { get; }

    public abstract void TurnOn();

    public abstract void TurnOff();

    public int CompareTo(ElectronicDeviceBase? other)
    {
        return other is null ? 0 : Power.CompareTo(other.Power);
    }
}