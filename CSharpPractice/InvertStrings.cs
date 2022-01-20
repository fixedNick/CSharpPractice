using System;
using System.Collections.Generic;


namespace CSharpPractice;

internal class InvertStrings
{
    private static string EnteredString = string.Empty;
    private static string InvertedString = string.Empty;

    public static void Init()
    {
        EnterString();
        MakeInvert();
        ShowResult();
    }

    private static void EnterString()
    {
        Console.Write("Enter string: ");
        EnteredString = Console.ReadLine();
    }

    private static void MakeInvert()
    {
        for (int i = EnteredString.Length - 1; i >= 0; i--)
            InvertedString += EnteredString[i];
    }

    private static void ShowResult()
    {
        Console.WriteLine(InvertedString);
    }
}
