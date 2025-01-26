
using System;

class Program
{ // Даны два массива размером 10*10, заполненные целыми числами в диапазоне от 1 до 9 включительно.
  // Создать новый массив, который будет произведением двух предыдущих (перемножить элементы первых
  // двух массивов, стоящие на одинаковых позициях и записать их в результирующий массив)
  // Вывести результирующий массив.
    static void Main()
    {
        // размеры массивов
        int size = 10;

        // создаём и заполняем два исходных массива
        int[,] array1 = FillArray(size);
        int[,] array2 = FillArray(size);

        // создаём массив для хранения результата
        int[,] resultArray = new int[size, size];

        // умножение соответствующих элементов друг на друг и заполнение результирующего массива
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                resultArray[i, j] = array1[i, j] * array2[i, j];
            }
        }

        // вывод результата
        Console.WriteLine("Результирующий массив (произведение двух массивов):");
        PrintArray(resultArray);
    }

    // метод для создания и заполнения массива случайными числами от 1 до 9
    static int[,] FillArray(int size)
    {
        Random random = new Random(); // генератор случайных чисел
        int[,] array = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                array[i, j] = random.Next(1, 10); // заполнение любым числом от 1 до 9 включительно
            }
        }

        return array;
    }

    // метод для вывода массива на консоль
    static void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t"); // выводим элемент с табуляцией
            }
            Console.WriteLine(); // переход на новую строку
        }
    }
}