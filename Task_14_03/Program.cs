namespace Task_14_03
{
    using System;

    public class FactorialCalculator
    {
        // статический метод для вычисления факториала
        public static long Factorial(int n)
        {
            // проверка на то, чтобы число не оказалось отрицательным
            if (n < 0)
            {
                Console.WriteLine("Ошибка: Факториал определен только для неотрицательных чисел.");
                return -1; // возвращаем -1, если произошла ошибка
            }

            // факториал 0=1
            if (n == 0)
            {
                return 1;
            }

            // вычисляем факториала  
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите неотрицательное целое число: ");
            int number = int.Parse(Console.ReadLine());

            long factorial = FactorialCalculator.Factorial(number);

            if (factorial != -1) // проверка на ошибку
            {
                Console.WriteLine($"Факториал числа {number} равен: {factorial}");
            }
        }
    }
}