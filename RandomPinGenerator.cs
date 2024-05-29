using System;
using System.Collections.Generic;

public class RandomPinGenerator
{
    private static Random random = new Random();

    public static string GeneratePin()
    {
        string pin;
        while (true)
        {
            pin = "";
            for (int i = 0; i < 4; i++)
            {
                pin += random.Next(0, 10);
            }

            if (!HasConsecutiveIdenticalDigits(pin) && !HasConsecutiveIncrementalDigits(pin))
            {
                break;
            }

           
        }
        return pin;
    }

    private static bool HasConsecutiveIdenticalDigits(string pin)
    {
        for (int i = 0; i < pin.Length - 1; i++)   
        {
            if (pin[i] == pin[i + 1])
            {
                return true;
            }
        }
        return false;
    }

    private static bool HasConsecutiveIncrementalDigits(string pin)
    {
        for (int i = 0; i < pin.Length - 1; i++)
        {
            if (pin[i] + 1 == pin[i + 1])
            {
                return true;
            }
        }
        return false;
    }

    public static HashSet<string> GenerateBatch(int batchSize)
    {
        var batch = new HashSet<string>();
        while (batch.Count < batchSize)
        {
            batch.Add(GeneratePin());
        }
        return batch;
    }
}

class Program
{
    static void Main(string[] args)
    {
        HashSet<string> batch = RandomPinGenerator.GenerateBatch(1000);
        foreach (var pin in batch)
        {
            Console.WriteLine(pin);
        }
    }
}
