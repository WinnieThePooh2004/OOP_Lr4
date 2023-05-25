using ElectronicDevice.ElectronicDevices.Chargers;
using ElectronicDevice.Exceptions.ChargerException;

namespace ElectronicDevice.Exceptions;

public static class GuardClauses
{
    public static void ThrowIfChargerNotPluggedIn(this ChargerBase device)
    {
        if (!device.PluggedIn)
        {
            throw new UnplugedChargerException();
        }
    }
}