using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice; // C# 9.0 namespace распространяется на файл.

/*
    Реализация всех возможных сочетаний из двух чисел.
    !!! Важное замечание!
        Если реально сделать сочетания из двух чисел, то их 2^2 = 4 (два числа на две позиции, с повторениями!)
        К примеру ввели 12 и 72, сочетания из них:
            [12, 12]
            [12, 72]
            [72, 12]
            [72, 72]

        Это слишком легко, скорее всего в задании имелось ввиду:
        1. Разбить числа на цифры, к примеру 1 2 и 7 2
        2. Найти все сочетания данных цифр(видимо повторения), с повторениями будет 4^4 комбинаций. (256 штук)

    За все действия отвечает метод MakeCombos(), в который передаем 
        - шаг(По сути это как i в цикле, просто отслеживать позицию для последующей перестановки)
        - нашу исходную строку, чтобы каждый рекурсивный вызов заполнял позицию(зависящую от step) каждой буквой из исходной строки
        - И уже рекурсивный вызов будет формировать нашу готовую строку(прибавлять постепенно каждый из символов, из исходной строки)
    
    Чтобы лучше понять как же работает метод MakeCombos и формируются все возможные перестановки, смотрим ниже, каждый отступ - это рекурсии, 
    которые побудил предыдущий отступ, когда step == 0, значит формирование завершено(мы заполнили все позиции)
    
MakeCombos(3,"ABC");
    MakeCombos(2, "ABC", "A")
        MakeCombos(1, "ABC", "AA")
            MakeCombos(0, "ABC", "AAA") => AAA
            MakeCombos(0, "ABC", "AAB") => AAB
            MakeCombos(0, "ABC", "AAC") => AAC
        MakeCombos(1, "ABC", "AB")
            MakeCombos(0, "ABC", "ABA") => ABA
            MakeCombos(0, "ABC", "ABB") => ABB
            MakeCombos(0, "ABC", "ABC") => ABC
        MakeCombos(1, "ABC", "AC")
            MakeCombos(0, "ABC", "ACA") => ACA
            MakeCombos(0, "ABC", "ACB") => ACB
            MakeCombos(0, "ABC", "ACC") => ACC
    MakeCombos(2, "ABC", "B")
        MakeCombos(1, "ABC", "BA")
            MakeCombos(0, "ABC", "BAA") => BAA
            MakeCombos(0, "ABC", "BAB") => BAB
            MakeCombos(0, "ABC", "BAC") => BAC
        MakeCombos(1, "ABC", "BB")
            MakeCombos(0, "ABC", "BBA") => BBA
            MakeCombos(0, "ABC", "BBB") => BBB
            MakeCombos(0, "ABC", "BBC") => BBC
        MakeCombos(1, "ABC", "BC")
            MakeCombos(0, "ABC", "BCA") => BCA
            MakeCombos(0, "ABC", "BCB") => BCB
            MakeCombos(0, "ABC", "BCC") => BCC
    MakeCombos(2, "ABC", "C")
        MakeCombos(1, "ABC", "CA")
            MakeCombos(0, "ABC", "CAA") => CAA
            MakeCombos(0, "ABC", "CAB") => CAB
            MakeCombos(0, "ABC", "CAC") => CAC
        MakeCombos(1, "ABC", "CB")
            MakeCombos(0, "ABC", "CBA") => CBA
            MakeCombos(0, "ABC", "CBB") => CBB
            MakeCombos(0, "ABC", "CBC") => CBC
        MakeCombos(1, "ABC", "CC")
            MakeCombos(0, "ABC", "CCA") => CCA
            MakeCombos(0, "ABC", "CCB") => CCB
            MakeCombos(0, "ABC", "CCC") => CCC     
*/

internal class TwoNumbersCombo
{
    private static List<string> Combos = new List<string>();

    private static int N;
    private static int K;

    public static void Init()
    {
        EnterNumbers();

        string numbersAsString = N.ToString() + K.ToString();
        MakeCombos(numbersAsString.Length, numbersAsString);

        ShowCombos();
    }

    private static void ShowCombos()
    {
        Console.WriteLine("[Итоговые комбинации]");
        foreach(var comb in Combos)
            Console.WriteLine(comb);
    }

    private static void MakeCombos(int step, string str, string completeStr = "")
    {
        if (step == 0)
            Combos.Add(completeStr.Trim());
        else
        {
            foreach (char ch in str)
                MakeCombos(step - 1, str, completeStr + " " + ch);
        }
    }

    private static void EnterNumbers()
    {
        N = EnterSingleNumber("N");
        K = EnterSingleNumber("K");
    }

    private static int EnterSingleNumber(string numberName = "")
    {
        while (true)
        {
            Console.Write($"Введите число {numberName}:");
            if(int.TryParse(Console.ReadLine(), out int enteredNumber) == false)
            {
                Console.WriteLine("-- Error: Bad input string");
                continue;
            }
            return enteredNumber;
        }
    }
}
