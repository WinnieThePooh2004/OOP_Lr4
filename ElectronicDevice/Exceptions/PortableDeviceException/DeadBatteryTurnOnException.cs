namespace ElectronicDevice.Exceptions.PortableDeviceException;

public class DeadBatteryTurnOnException : Exception
{
    public DeadBatteryTurnOnException()
        : base("Cannot turn on device. Battery is dead.")
    {
    }
}