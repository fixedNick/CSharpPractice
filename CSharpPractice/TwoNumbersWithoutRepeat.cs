using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPractice
{
    internal class TwoNumbersWithoutRepeat
    {
        private static List<string> AllCombos;

        private static int K;
        private static int N;
        private static int[] buffer;

        public static void Init()
        {
            AllCombos = new List<string>();
            EnterNumbers();
            MakeCombos(0, 0);
            ShowCombos();
        }

        private static void ShowCombos()
        {
            foreach(var combo in AllCombos)
                Console.WriteLine(combo);

            Console.WriteLine($"Total combos: {AllCombos.Count}");
        }

        private static void EnterNumbers()
        {
            N = EnterSingleNumber("N");
            K = EnterSingleNumber("K");
            buffer = new int[K];
        }

        private static int EnterSingleNumber(string numberName = "")
        {
            while (true)
            {
                Console.Write($"Введите число {numberName}:");
                if (int.TryParse(Console.ReadLine(), out int enteredNumber) == false)
                {
                    Console.WriteLine("-- Error: Bad input string");
                    continue;
                }
                return enteredNumber;
            }
        }

        private static void MakeCombos(int idx, int begin)
        {
            for (int i = begin; i < N; i++)
            {
                buffer[idx] = i;
                if (idx + 1 < K) MakeCombos(idx + 1, buffer[idx] + 1);
                else  AllCombos.Add(string.Join(" ", buffer));
            }
        }
    }
}
