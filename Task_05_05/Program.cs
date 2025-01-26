using System;

class Program
{ // У пользователя в консоли запрашивается числа n и m, генерируется прямоугольный массив целых числе [n*m]. Заполнение
  // случайными числами в диапазоне от -99 до 99 включительно. Осуществите без создания нового массива
  // преобразование текущего по следующему правилу:
  // • Если элемент меньше нуля, то отбрасываем знак и выделяем при выводе зеленым цветом
  // • Если элемент равен нулю, то перезаписываем единицу и выделяем при выводе красным цветом
    static void Main()
    {
        // запрашиваем у пользователя размеры массива
        Console.Write("Введите количество строк (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов (m): ");
        int m = int.Parse(Console.ReadLine());

        // создаём прямоугольный массив
        int[,] array = new int[n, m];

        // заполняем массив случайными числами в диапазоне от -99 до 99
        FillArray(array);

        // преобразуем массив по правилам и выводим его
        TransformAndPrintArray(array);
    }

    // метод для заполнения массива случайными числами
    static void FillArray(int[,] array)
    {
        Random random = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(-99, 100); // заполняем числами от -99 до 99
            }
        }
    }

    // метод для преобразования и вывода массива
    static void TransformAndPrintArray(int[,] array)
    {
        Console.WriteLine("Преобразованный массив:");

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                // применение правил преобразования
                if (array[i, j] < 0) // если элемент меньше нуля
                {
                    Console.ForegroundColor = ConsoleColor.Green; // устанавливаем зеленый цвет
                    Console.Write(Math.Abs(array[i, j]) + " "); // выводим модуль числа
                }
                else if (array[i, j] == 0) // если элемент равен нулю
                {
                    Console.ForegroundColor = ConsoleColor.Red; // устанавливаем красный цвет
                    Console.Write(1 + " "); // выводим единицу
                }
                else // если элемент больше нуля
                {
                    Console.ResetColor(); // сброс цвета
                    Console.Write(array[i, j] + " "); // выводим положительное число без изменения
                }
            }
            Console.WriteLine(); // переходим на новую строку после каждой строки массива
            Console.ResetColor(); // сброс цвета после завершения строки
        }
    }
}
