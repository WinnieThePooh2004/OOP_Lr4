using ElectronicDevice.ElectronicDevices;
using ElectronicDevice.ElectronicDevices.Chargers;
using ElectronicDevice.ElectronicDevices.PortableDevices;
using ElectronicDevice.Helpers;

namespace ElectronicDevice.UserActions;

public class AddChargerAction : IUserAction
{
    public string ReactOn => "9";

    public void DoAction(List<ElectronicDeviceBase> allDevices)
    {
        Console.WriteLine("Choose device to add charger:");
        var portableDevices = allDevices.OfType<PortableDeviceBase>().ToList();
        for (var i = 0; i < portableDevices.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {portableDevices[i].Name}");
        }
        var item = portableDevices.ReadIndexAndGetValue();
        if (item is null)
        {
            Console.WriteLine("Please, write valid index");
            return;
        }

        Console.WriteLine("Choose charger:");
        var chargers = allDevices.OfType<ChargerBase>().ToList();
        for (var i = 0; i < chargers.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {chargers[i].Name}");
        }

        var charger = chargers.ReadIndexAndGetValue();
        if (charger is null)
        {
            Console.WriteLine("Please, write valid index");
            return;
        }

        item.AddCharger(charger);
    }
}