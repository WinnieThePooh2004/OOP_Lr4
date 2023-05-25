// See https://aka.ms/new-console-template for more information

using ElectronicDevice.ElectronicDevices;
using ElectronicDevice.ElectronicDevices.BuiltInKitchenDevices;
using ElectronicDevice.ElectronicDevices.Chargers;
using ElectronicDevice.ElectronicDevices.PortableDevices;
using ElectronicDevice.UserActions;

var allActions = typeof(Program).Assembly.GetTypes()
    .Where(type => type.IsAssignableTo(typeof(IUserAction)) && !type.IsAbstract)
    .Select(type => (IUserAction)Activator.CreateInstance(type)!)
    .ToDictionary(action => action.ReactOn);

string? input;

var allDevices = new List<ElectronicDeviceBase>
{
    new Fridge(0.08, "Fridge"),
    new WashingMachine(0.06, "Washing machine"),
    new Phone(0.01, "iPhone 12"),
    new Laptop(0.03,"Hp envy 360"),
    new PhoneCharger(0.02, "Type-C charger"),
    new LaptopCharger(0.04, "Laptop charger")
};

do
{
    Console.WriteLine(
        """
        Select option:
        1) Show all devices
        2) Sort devices
        3) Delete device
        4) Create new device
        5) Plug in device
        6) Plug out device
        7) Turn on device
        8) Turn off device
        9) Add charger
        10) Start charging
        11) End charging
        12) Show charge level
        [q] Quit
        """);
    input = Console.ReadLine()!;
    Console.WriteLine();
    if (input == "q")
    {
        break;
    }
    if (allActions.TryGetValue(input, out var action))
    {
        try
        {
            action.DoAction(allDevices);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        Console.WriteLine();
        continue;
    }

    Console.WriteLine("Invalid input");
} while (input != "q");

Console.WriteLine("Have a nice day!");