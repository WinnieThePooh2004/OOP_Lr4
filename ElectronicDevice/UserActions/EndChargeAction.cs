﻿using ElectronicDevice.ElectronicDevices;
using ElectronicDevice.ElectronicDevices.PortableDevices;
using ElectronicDevice.Helpers;

namespace ElectronicDevice.UserActions;

public class EndChargeAction : IUserAction
{
    public string ReactOn => "11";

    public void DoAction(List<ElectronicDeviceBase> allDevices)
    {
        Console.WriteLine("Choose device to end charge:");
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

        item.EndCharge();
    }
}