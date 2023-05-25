using ElectronicDevice.ElectronicDevices;

namespace ElectronicDevice.UserActions;

public interface IUserAction
{
    string ReactOn { get; }

    void DoAction(List<ElectronicDeviceBase> allDevices);
}