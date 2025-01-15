using System;

class Program
{
    static void Main()
    {
        string s = "She sells seashells by the seashore. The shells she sells are seashells";
        
        int countShe = CountOccurrences(s, "she");
        int countSel = CountOccurrences(s, "sel");

        Console.WriteLine($"So lan xuat hien cua 'she': {countShe}");
        Console.WriteLine($"So lan xuat hien cua 'sel': {countSel}");
    }

    static int CountOccurrences(string sentence, string word)
    {
        int count = 0;
        int index = 0;
        
        while ((index = sentence.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += word.Length;
        }

        return count;
    }
}