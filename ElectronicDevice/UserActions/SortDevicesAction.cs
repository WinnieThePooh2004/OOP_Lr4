using ElectronicDevice.ElectronicDevices;

namespace ElectronicDevice.UserActions;

public class SortDevicesAction : IUserAction
{
    public string ReactOn => "2";

    public void DoAction(List<ElectronicDeviceBase> allDevices)
    {
        allDevices.Sort();
    }
}