using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/* Папкин Игорь
 * Задание 4 
 * 
 * Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На
 * выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password:
 * GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь
 * вводит логин и пароль, программа пропускает его дальше или не пропускает. С помощью
 * цикла do while ограничить ввод пароля тремя попытками. */

namespace Lesson2
{
    //Метод проверки логина и пароля
    public class Verify
    {
        private const string login = "root";
        private const string password = "GeekBrains";

        public bool VerifyMeth(string log, string pass)
        {
            if (log == login && pass == password)
                return true;

            return false;
        }
    }

    public class Task4
    {
        static void Main()
        {
            string login;
            string password;
            const int attemptNum = 3;
            int attempt = 0;

            Verify Check = new Verify();

            //Ввод данных пользователем. Проверка методом VerifyMeth. Три попытки.
            while (attempt < attemptNum) 
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Введите ваш логин: ");
                login = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Введите ваш пароль: ");
                password = Console.ReadLine();
                Console.WriteLine();

                if (Check.VerifyMeth(login, password))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Логин и пароль введены верно");
                    break;
                }
                else
                {
                    attempt++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Логин и пароль введены не верно, повторите попытку. Попыток осталось: {3 - attempt}");
                }
            }

            Console.ReadKey();
        }

    }
 }

