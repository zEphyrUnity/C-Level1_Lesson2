using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/* Папкин Игорь
 * Задание 1 - 3
 * 
 * 1. Написать метод, возвращающий минимальное из трёх чисел.
 * 2. Написать метод подсчета количества цифр числа.
 * 3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных
положительных чисел. */

namespace Task1_3
{
    internal class Methods_Lib
    {
        //Создание целочисленного массива, любого размера, случайных чисел в интервале -100, 100.
        public static int[] ArrayInt(int num = 10)
        {
            int[] array = new int[num];
            Random ranNum = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = ranNum.Next(-100, 100);    

            return array;
        }

        //Метод подсчета суммы всех нечетных положительных чисел, пока не будет введен 0.
        public static void PositiveOddSum()
        {
            string text;
            int num = 1;
            int sum = 0;

            do 
            { 
                text = Console.ReadLine();
                //Проверка введеных данных
                if (Regex.IsMatch(text, @"[0-9]"))
                    num = Int32.Parse(text);

                //Прибавить число, если оно больше нуля и нечетное
                if ((num > 0) && (num % 2 != 0))
                    sum += num;

                //Если число равно нулю закончить ввод чисел
                if (num == 0)
                    break;
            } 
            while (true);

            Console.WriteLine(sum);
        }
    }

    class Task1_3
    {
        static void Main()
        {
            const int numCol = 3;
            int minNumber;
            int number;
            int digits = 0;

            //Создание случайного числа от 0 до 1млн.
            Random randomNumber = new Random();
            number = randomNumber.Next(0, 1000000);

            //Объявление и инициализация массива
            var array1 = Methods_Lib.ArrayInt(numCol);

            Console.ForegroundColor = ConsoleColor.Green;
            //Вывод целочисленного массива методом
            Console.Write($"Массив из {numCol} элементов: ");
            for (int i = 0; i < array1.Length; i++)
                Console.Write($"{array1[i]} ");

            //*1  Поиск минимального значения массива
            minNumber = array1[0];

            for (int i = 1; i < array1.Length; i++)
                if (minNumber > array1[i])
                    minNumber = array1[i];

            Console.WriteLine();
            Console.Write($"Минимальное значения массива: {minNumber}");
            Console.WriteLine();

            //*2  Подсчет количества цифр в случайном числе number
            Console.Write($"Случайное число {number} содержит ");

            while (number > 0)
            {
                number /= 10;
                digits++;
            }

            Console.Write($"{digits} цифр");
            Console.WriteLine("\n");

            //*3  Вызов метода подсчета суммы всех нечетных положительных чисел, пока не будет введен 0.
            Console.WriteLine("Введите числа, когда будет введен 0, вы получите сумму всех нечетных чисел.");
            Console.ForegroundColor = ConsoleColor.Red;

            Methods_Lib.PositiveOddSum();

            Console.WriteLine("\n");
            Console.ReadKey();
        }
    }
}
