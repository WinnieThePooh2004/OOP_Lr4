using ElectronicDevice.ElectronicDevices;
using ElectronicDevice.Helpers;

namespace ElectronicDevice.UserActions;

public class TurnOffAction : IUserAction
{
    public string ReactOn => "8";

    public void DoAction(List<ElectronicDeviceBase> allDevices)
    {
        Console.WriteLine("Enter index of device to turn off");
        var item = allDevices.ReadIndexAndGetValue();
        if (item is null)
        {
            Console.WriteLine("Please, enter valid index");
            return;
        }

        item.TurnOff();
    }
}