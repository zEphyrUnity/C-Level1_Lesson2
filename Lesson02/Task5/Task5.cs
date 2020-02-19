using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/* Папкин Игорь
 * Задание 5 
 * 
 * а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
 *    массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
 * б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса */

namespace Task5
{
    public static class IndexMT
    {
        /* 16 и менее	Выраженный дефицит массы тела
         * 16—18,5	    Недостаточная (дефицит) масса тела
         * 18,5—24,99	Норма
         * 25—30	    Избыточная масса тела (предожирение)
         * 30—35	    Ожирение
         * 35—40	    Ожирение резкое
         * 40 и более	Очень резкое ожирение*/

        private const double severeWeightDeficit    = 15.99;
        private const double massShortage           = 16.0;
        private const double standart               = 18.5;
        private const double Overweight             = 25.0;
        private const double Obesity                = 30.0;
        private const double SharpObesity           = 35;
        private const double VerySharpObesity       = 40;

        private const double midStandart = (Overweight + standart) / 2;

        //Метод расчета индекса массы тела по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
        public static void IMT(int height, int weight)
        {
            double indexMT;
            double h = (double)height / 100;
            double requiredMass;

            //Расчет индекса массы тела.
            indexMT = weight / (h * h);
            Console.WriteLine($"Индекс массы вашего тела: {indexMT:#.##} при массе тела: {weight} и росте: {height}");
            Console.WriteLine("");

            //Расчет нормальной средней массы тела, для среднего нормального индекса массы тела.
            requiredMass = midStandart * (h * h);
            Console.WriteLine("При вашем росте средняя норма массы: {0:#.##}", requiredMass);
            Console.WriteLine("");

            switch (indexMT) 
            {
                case double imt when imt <= severeWeightDeficit:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("У вас выраженный дефицит массы тела. Настоятельно рекомендую вам набрать: {0:#.##}кг.", requiredMass - weight);
                    break;
                case double imt when imt > massShortage && imt < standart:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("У вас недостаточная (дефицит) масса тела. Рекомендую вам набрать: {0:#.##}кг.", requiredMass - weight);
                    break;
                case double imt when imt > standart && imt < Overweight :
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ваша масса тела в норме, так держать!");
                    break;
                case double imt when imt > Overweight && imt < Obesity :
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("У вас избыточная масса тела (предожирение). Рекомендую вам сбросить: {0:#.##}кг.", weight - requiredMass);
                    break;
                case double imt when imt > Obesity && imt < SharpObesity:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("У вас ожирение! Настоятельно рекомендую вам сбросить: {0:#.##}кг.", weight - requiredMass);
                    break;
                case double imt when imt > SharpObesity && imt < VerySharpObesity:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("У вас резкое ожирение! Ультимативно рекомендую вам сбросить: {0:#.##}кг.", weight - requiredMass);
                    break;
                case double imt when imt > VerySharpObesity :
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("У вас очень резкое ожирение! Поздно пить боржоми, пора выступать в суммо: {0:#.##}", weight - requiredMass + "кг вам ни за что не сбросить!");
                    break;
            }
        }
    }

    class Task5
    {
        static void Main()
        {
            int height;
            int weight;
            string text;

            Console.ForegroundColor = ConsoleColor.Yellow;
            //Ввод данных пользователем (только цифры). 
            do
            {
                Console.Write("Введите ваш рост: ");
                text = Console.ReadLine();
                if (Regex.IsMatch(text, @"[0-9]"))
                {
                    height = Int32.Parse(text);
                    break;
                }
            }
            while (true);

            Console.WriteLine("");
            //Ввод данных пользователем (только цифры). 
            do
            {
                Console.Write("Введите ваш вес: ");
                text = Console.ReadLine();
                if (Regex.IsMatch(text, @"[0-9]"))
                {
                    weight = Int32.Parse(text);
                    break;
                }
            }
            while (true);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");

            IndexMT.IMT(height, weight);

            Console.WriteLine("\n");
            Console.ReadKey();
        }
    }
}
