using System.Globalization;

namespace ElectronicDevice.Helpers;

public static class Reader
{
    public static T Read<T>()
        where T : struct, IParsable<T>
    {
        T result;
        while (!T.TryParse(Console.ReadLine(), CultureInfo.CurrentCulture, out result))
        {
            Console.WriteLine("Please, enter correct value");
        }

        return result;
    }

    public static T Read<T>(Func<T, bool> predicate)
        where T : struct, IParsable<T>
    {
        T result;
        while (!T.TryParse(Console.ReadLine(), CultureInfo.CurrentCulture, out result) && !predicate(result))
        {
            Console.WriteLine("Please, enter correct value");
        }

        return result;
    }

    public static int ReadIndex<T>(this List<T> items)
    {
        var index = Read<int>(index => index < items.Count) - 1;
        if (index < items.Count && index > 0)
        {
            return index;
        }
        Console.WriteLine("Invalid index");
        return -1;
    }
    
    public static T? ReadIndexAndGetValue<T>(this List<T> items)
        where T : class
    {
        var index = Read<int>(index => index < items.Count) - 1;
        if (index < items.Count && index > 0)
        {
            return items[index];
        }
        Console.WriteLine("Invalid index");
        return null;
    }
}