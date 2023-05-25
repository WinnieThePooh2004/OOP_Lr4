using ElectronicDevice.ElectronicDevices;
using ElectronicDevice.Helpers;

namespace ElectronicDevice.UserActions;

public class DeleteDevice : IUserAction
{
    public string ReactOn => "3";

    public void DoAction(List<ElectronicDeviceBase> allDevices)
    {
        Console.WriteLine("Enter index of device to delete:");
        var index = allDevices.ReadIndexAndGetValue();
        if (index is null)
        {
            Console.WriteLine("Please, enter valid index");
            return;
        }

        allDevices.Remove(index);
    }
}