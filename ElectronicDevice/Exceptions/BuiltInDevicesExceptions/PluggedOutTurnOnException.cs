namespace ElectronicDevice.Exceptions.BuiltInDevicesExceptions;

public class PluggedOutTurnOnException : Exception
{
    public PluggedOutTurnOnException()
        : base("Cannot turn on a device that is not plugged in.")
    {
    }
}