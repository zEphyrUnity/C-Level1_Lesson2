﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Папкин Игорь
 * Задание 7 
 * 
 * a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
 * б) *Разработать рекурсивный метод, который считает сумму чисел от a до b. */

namespace Task7
{
    class Task7
    {
        public static int sum = 0;

        public static void Recursion(int a, int b) 
        {
            Console.Write($"{a} ");
            sum += a;
            a++;

            if (a >= b) 
            {
                sum += b;
                return;
            } 
            Recursion(a, b);
        }

        static void Main()
        {
            int a;
            int b;

            Random ranNum = new Random();

            a = ranNum.Next(0, 100);
            b = ranNum.Next(0, 100);

            if (a > b)
            {
                a = a + b;
                b = a - b;
                a = a - b;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"a: {a}, b: {b}");

            Recursion(a, b);

            Console.WriteLine("");
            Console.WriteLine($"Сумма чисел от {a} до {b} = {sum}");
            Console.WriteLine("\n");

            Console.ReadKey();
        }
    }
}
