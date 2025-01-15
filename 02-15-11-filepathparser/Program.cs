using System;

class Program
{
    static void Main()
    {
        string fullpath = @"C:\Documents\Photos\Test.jpg";

        string[] parts = fullpath.Split('\\');
        string filenameWithExtension = parts[parts.Length - 1];
        string[] fileParts = filenameWithExtension.Split('.');
        
        string extension = fileParts[fileParts.Length - 1];
        string filename = fileParts[0];
        string folder = string.Join("\\", parts, 0, parts.Length - 1);

        Console.WriteLine($"Folder: {folder}");
        Console.WriteLine($"Filename: {filenameWithExtension}");
        Console.WriteLine($"Filename No Extension: {filename}");
        Console.WriteLine($"Extension: {extension}");
    }
}