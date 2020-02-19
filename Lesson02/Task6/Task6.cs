using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

/* Папкин Игорь
 * Задание 6 
 * 
 * Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000
 * 000. «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать
 * подсчёт времени выполнения программы, используя структуру DateTime. */

namespace Task6
{
    class Task6
    {
        //Метод подсчета цифр в числе
        public static int Digits(int number)
        {
            int digits = 0;

            while (number > 0)
            {
                number /= 10;
                digits++;
            }

            return digits;
        }

        static void Main()
        {
            const int mln = 10000000;
            int goodNumber = 0;
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            //Подсчет "хороших чисел"
            for (int i = 1; i < mln; i++) 
            {
                if ((i % Digits(i)) == 0)
                    goodNumber++;
            }
            stopWatch.Stop();
            
            TimeSpan ts = stopWatch.Elapsed;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Хороших чисел в: {mln} ровно {goodNumber}");

            string elapsedTime = String.Format("{0:00}ч :{1:00}мин :{2:00}сек :{3:000}мс", ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds);
            Console.WriteLine("Время выполнения программы подсчета \"хороших чисел\" составило ровно: " + elapsedTime);

            Console.ReadKey();
        }
    }
}
