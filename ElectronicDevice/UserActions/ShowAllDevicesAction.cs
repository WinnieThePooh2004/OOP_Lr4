using ElectronicDevice.ElectronicDevices;

namespace ElectronicDevice.UserActions;

public class ShowAllDevicesAction : IUserAction
{
    public string ReactOn => "1";

    public void DoAction(List<ElectronicDeviceBase> allDevices)
    {
        if (allDevices.Count == 0)
        {
            Console.WriteLine("No devices found");
            return;
        }
        for (var i = 0; i < allDevices.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {allDevices[i].Name}, power = {allDevices[i].Power}, " +
                              $"is plugged {(allDevices[i].PluggedIn ? "in" : "out")} ({allDevices[i].GetType().Name})");
        }
    }
}