using System;

class Program
{
    static void Main()
    {
        string data = "3,12,17,18,19,111";
        string[] numbers = data.Split(',');
        int sum = 0;
        foreach (string number in numbers)
        {
            sum += int.Parse(number);
        }
        Console.WriteLine("Sum: " + sum);
    }
}
