using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Gọi hàm tính tổng từ 1 đến 10
        int sum = CalculateSum(1, 10);

        // 1. Console.WriteLine
        Console.WriteLine($"Dung Console.WriteLine: Tong tu 1 den 10 la: {sum}");

        // 2. Console.Write
        Console.Write("Dung Console.Write: Tong tu 1 den 10 la: ");
        Console.Write(sum);
        Console.Write("\n");

        // 3. Console.Out.WriteLine
        Console.Out.WriteLine($"Dung Console.Out.WriteLine: Tong tu 1 den 10 la: {sum}");

        // 4. Luu vao bien chuoi thong thuong
        string resultString = $"Dung String: Tong tu 1 den 10 la: {sum}";
        Console.WriteLine(resultString);

        // 5. Luu vao StringBuilder
        StringBuilder sb = new StringBuilder();
        sb.Append($"Dung StringBuilder: Tong tu 1 den 10 la: {sum}");
        Console.WriteLine(sb.ToString());

        // 6. Luu vao chuoi JSON
        string jsonString = $"{{\"message\": \"Tong tu 1 den 10 la: {sum}\"}}";
        Console.WriteLine($"Dung JSON String: {jsonString}");

        // 7. System.Diagnostics.Debug
        System.Diagnostics.Debug.WriteLine($"Dung Debug.WriteLine: Tong tu 1 den 10 la: {sum}");

        // 8. System.Diagnostics.Trace
        System.Diagnostics.Trace.WriteLine($"Dung Trace.WriteLine: Tong tu 1 den 10 la: {sum}");

        // Chèn chuỗi bằng StringBuilder
        StringBuilder sbInsert = new StringBuilder("Tong 1 den 10 la: 55");
        sbInsert.Insert(5, "tu ");
        Console.WriteLine($"Chen bang StringBuilder: {sbInsert.ToString()}");

        // Chèn chuỗi bằng string
        string original = "Tong 1 den 10 la: 55";
        string resultInsert = original.Insert(5, "tu ");
        Console.WriteLine($"Chen bang string: {resultInsert}");
    }

    // Hàm tính tổng các số từ start đến end
    private static int CalculateSum(int start, int end)
    {
        int sum = 0;
        for (int i = start; i <= end; i++)
        {
            sum += i;
        }
        return sum;
    }
}
