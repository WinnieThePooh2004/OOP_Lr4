﻿using ElectronicDevice.ElectronicDevices;
using ElectronicDevice.Helpers;

namespace ElectronicDevice.UserActions;

public class PluginDeviceAction : IUserAction
{
    public string ReactOn => "5";

    public void DoAction(List<ElectronicDeviceBase> allDevices)
    {
        Console.WriteLine("Enter index of device to plug in");
        var item = allDevices.ReadIndexAndGetValue();
        if (item is null)
        {
            Console.WriteLine("Please, enter valid index");
            return;
        }

        item.PluggedIn = true;
    }
}