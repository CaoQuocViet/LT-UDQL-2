using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string tel = "01277111222"; 
        string maskedTel = Regex.Replace(tel, @"(\d{4,5})(\d{3})(\d{3})", "$1-$2-$3"); 
        Console.WriteLine(maskedTel);  
    }
}

// Learn Regex: https://regexr.com/