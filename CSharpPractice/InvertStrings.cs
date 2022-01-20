using System;
using System.Collections.Generic;


namespace CSharpPractice;

internal class InvertStrings
{
    private static List<string> EnteredStrings;
    private static List<string> InvertedStrings;

    public static void Init()
    {
        EnterStrings();
        MakeInvert();
        ShowResult();
        SaveResult();
    }

    private static void SaveResult()
    {
        System.IO.File.WriteAllLines("InvertedStringResult.txt", InvertedStrings);
    }

    private static void EnterStrings()
    {
        string filename = string.Empty;
        while (true)
        {
            Console.Write("Enter filename: ");
            filename = Console.ReadLine();
            if (System.IO.File.Exists(filename) == false)
                Console.WriteLine("Файл не найден");
            else break;
        }
        EnteredStrings = System.IO.File.ReadAllLines(filename).ToList();
    }

    private static void MakeInvert()
    {
        InvertedStrings = new List<string>();
        for (int line = 0; line < EnteredStrings.Count; line++)
        {
            InvertedStrings.Add(string.Empty);
            for (int i = EnteredStrings[line].Length - 1; i >= 0; i--)
                InvertedStrings[line] += EnteredStrings[line][i];
        }
    }

    private static void ShowResult()
    {
        foreach (var line in InvertedStrings)
            Console.WriteLine(line);
    }
}
