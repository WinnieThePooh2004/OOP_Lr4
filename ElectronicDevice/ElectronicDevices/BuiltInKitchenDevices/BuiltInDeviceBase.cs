using ElectronicDevice.Exceptions.BuiltInDevicesExceptions;

namespace ElectronicDevice.ElectronicDevices.BuiltInKitchenDevices;

public abstract class BuiltInDeviceBase : ElectronicDeviceBase
{
    protected BuiltInDeviceBase(double power, string name) : base(power, name)
    {
    }

    public override void TurnOn()
    {
        if (!PluggedIn)
        {
            throw new PluggedOutTurnOnException();
        }
    }
}