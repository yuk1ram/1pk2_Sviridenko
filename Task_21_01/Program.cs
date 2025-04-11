namespace Task_21_01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            // список чисел
            List<int> numbers = new List<int> { 0, 2, 11, 8, 5, 68, 77, 18, 9, 107, 11, 12, 200, 98, 50 };

            Console.WriteLine("Исходный список:");
            PrintList(numbers);

            // новый список с четными числами, умноженными на 10
            List<int> filteredNumbers = FilterAndMultiplyEvenNumbers(numbers);

            Console.WriteLine("\nРезультирующий список (четные числа × 10):");
            PrintList(filteredNumbers);
        }

        // метод для фильтрации четных чисел и умножения их на 10
        static List<int> FilterAndMultiplyEvenNumbers(List<int> inputList)
        {
            List<int> result = new List<int>();

            foreach (int number in inputList)
            {
                if (number % 2 == 0) // проверка на четность
                {
                    result.Add(number * 10); // умножение на 10 и добавление в результат
                }
            }

            return result;
        }

        // метод для вывода списка на консоль
        static void PrintList(List<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}