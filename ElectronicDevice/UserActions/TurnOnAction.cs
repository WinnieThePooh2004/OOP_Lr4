using ElectronicDevice.ElectronicDevices;
using ElectronicDevice.Helpers;

namespace ElectronicDevice.UserActions;

public class TurnOnAction : IUserAction
{
    public string ReactOn => "7";

    public void DoAction(List<ElectronicDeviceBase> allDevices)
    {
        Console.WriteLine("Enter index of device to turn on");
        var item = allDevices.ReadIndexAndGetValue();
        if (item is null)
        {
            Console.WriteLine("Please, enter valid index");
            return;
        }

        item.TurnOn();
    }
}