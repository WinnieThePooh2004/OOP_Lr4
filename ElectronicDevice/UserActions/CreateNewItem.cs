using System.Reflection;
using ElectronicDevice.ElectronicDevices;
using ElectronicDevice.Helpers;

namespace ElectronicDevice.UserActions;

public class CreateNewItem : IUserAction
{
    public string ReactOn => "4";

    public void DoAction(List<ElectronicDeviceBase> allDevices)
    {
        // getting all types that can be created, using switch or if-else is not good idea because of 2nd SOLID principle
        var allDeviceTypes = typeof(ElectronicDeviceBase).Assembly
            .GetTypes()
            .Where(type => type.IsAssignableTo(typeof(ElectronicDeviceBase)) &&
                           type is { IsAbstract: false, IsClass: true })
            .ToList();

        Console.WriteLine("Choose device type:");

        for (var i = 0; i < allDeviceTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}) {allDeviceTypes[i].Name}");
        }

        CreateNewInstance(allDeviceTypes, allDevices);
    }

    private static void CreateNewInstance(IReadOnlyList<Type> allDeviceTypes, ICollection<ElectronicDeviceBase> allDevices)
    {
        var type = allDeviceTypes[Reader.Read<int>(index => index <= allDeviceTypes.Count && index > 0) - 1];
        // getting first constructor and its parameters to be able to construct new object
        var constructor = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).First();
        var constructorParameters = constructor.GetParameters();
        var parameters = new object[constructorParameters.Length];
        for (var i = 0; i < constructorParameters.Length; i++)
        {
            // reading parameters from console
            var parameter = constructorParameters[i];
            if (parameter.ParameterType == typeof(string))
            {
                Console.WriteLine($"Enter string parameter '{parameter.Name}'");
                parameters[i] = Console.ReadLine()!;
                continue;
            }

            Console.WriteLine($"Enter parameter '{parameter.Name}' of type '{parameter.ParameterType.Name}'");

            var readerMethod = typeof(Reader).GetMethod(nameof(Reader.Read),
                BindingFlags.Public | BindingFlags.Static,
                Array.Empty<Type>())!.MakeGenericMethod(parameter.ParameterType);

            parameters[i] = readerMethod.Invoke(null, null)!;
        }

        // creating new instance of object using reflection
        var newObject = (ElectronicDeviceBase)constructor.Invoke(parameters);
        allDevices.Add(newObject);
    }
}