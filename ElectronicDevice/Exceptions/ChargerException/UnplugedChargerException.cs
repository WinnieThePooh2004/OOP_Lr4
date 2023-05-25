namespace ElectronicDevice.Exceptions.ChargerException;

public class UnplugedChargerException : Exception
{
    public UnplugedChargerException()
        : base("Cannot charge device. Charger is not plugged in.")
    {
    }
}