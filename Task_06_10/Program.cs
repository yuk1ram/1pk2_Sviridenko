namespace Task_06_10
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите размерность массива (n): ");
            int n = int.Parse(Console.ReadLine());

            ArrayGeneration(n); // вызываем метод для генерации и вывода массива
        }

        public static void ArrayGeneration(int n)
        {
            // создание двумерного массива целых чисел
            int[,] array = new int[n, n];

            // используем Random для ввода случайных чисел
            Random random = new Random();

            // заполняем массив случайными числами
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = random.Next(1, 100); // генерируем числа от 1 до 99 включительно
                }
            }

            // вывод массива на консоль
            Console.WriteLine("Сгенерированный массив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(array[i, j] + "\t"); // используем табуляцию, чтобы выравнять текст
                }
                Console.WriteLine(); // переход на новую строку после каждой строки массива
            }
        }
    }
}

