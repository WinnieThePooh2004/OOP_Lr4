namespace ElectronicDevice.Exceptions.PortableDeviceException;

public class NoAvailableChargersFoundException : Exception
{
    public NoAvailableChargersFoundException()
        : base("Cannot charge device. No available chargers found.")
    {
    }
}