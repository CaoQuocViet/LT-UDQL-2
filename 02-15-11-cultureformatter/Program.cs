using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        var culture = CultureInfo.GetCultureInfo("vi-VN");

        // Display the culture name
        Console.WriteLine("Culture name: " + culture.Name);
        
        // Format date according to "vi-VN" culture
        DateTime currentDate = DateTime.Now;
        string formattedDate = currentDate.ToString("D", culture); // Full date format
        Console.WriteLine("Current date (vi-VN format): " + formattedDate);

        // Format currency according to "vi-VN" culture
        decimal money = 1234567.89M;
        string formattedMoney = money.ToString("C", culture); // Currency format
        Console.WriteLine("Currency (vi-VN format): " + formattedMoney + " Dong");

        // Format number according to "vi-VN" culture
        double number = 12345.6789;
        string formattedNumber = number.ToString("N", culture); // Number with grouping separators
        Console.WriteLine("Number (vi-VN format): " + formattedNumber);
    }
}
