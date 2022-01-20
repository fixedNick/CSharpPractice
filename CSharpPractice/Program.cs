using CSharpPractice;
using System;

while (true)
{
    Console.WriteLine("[0] Exit");
    Console.WriteLine("[1] Перестановки N & K");
    Console.WriteLine("[2] График y=sin(x)");
    Console.WriteLine("[3] Отображение правильного многоугольника");
    Console.WriteLine("[4] Инвертирование строк");
    Console.WriteLine("[5] Треугольник Паскаля");
    Console.Write("Ваш выбор выбор:");
    if(int.TryParse(Console.ReadLine(), out int choice) == false)
    {
        Console.WriteLine("-- Error: Bad input value");
        continue;
    }
    
    if(choice < 0 || choice > 5)
    {
        Console.WriteLine("-- Error: Bad choice");
        continue;
    }

    switch((TaskNumber) choice)
    {
        case TaskNumber.TwoNumbersCombo:
            TwoNumbersCombo.Init();
            break;
    
    }
}


enum TaskNumber : int
{
    TwoNumbersCombo = 1,
    SinGraph = 2,
    RightMultiangle = 3,
    InvertStrings = 4,
    PascalTriangle = 5
};
