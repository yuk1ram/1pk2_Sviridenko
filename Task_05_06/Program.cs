﻿using System;

class Program
{ // Осуществить генерация двумерного [10*5] массива по следующему правилу:
// • 1 столбец содержит нули
// • 2 столбце содержит числа кратные 2
// • 3 столбец содержит числа кратные 3
// • 4 столбец содержит числа кратные 4
// • 5 столбец содержит числа кратные 5
// Осуществить переворот массива (поменять строки и столбцы местами) вывести обновленный массив.
    static void Main()
    {
        // создаём двумерный массив размером 10x5
        int[,] array = new int[10, 5];

        // заполняем массив по правилам из условия
        for (int i = 0; i < 10; i++)
        {
            array[i, 0] = 0; // первый столбец содержит нули
            array[i, 1] = (i + 1) * 2; // второй столбец содержит числа кратные 2
            array[i, 2] = (i + 1) * 3; // третий столбец содержит числа кратные 3
            array[i, 3] = (i + 1) * 4; // четвёртый столбец содержит числа кратные 4
            array[i, 4] = (i + 1) * 5; // пятый столбец содержит числа кратные 5
        }

        // выводим оригинальный массив
        Console.WriteLine("Оригинальный массив:");
        PrintArray(array);

        // переворачиваем массив ( т. е. меняем строки и столбцы местами )
        int[,] transposedArray = TransposeArray(array);

        // выводим обновлённый массив
        Console.WriteLine("Обновленный массив (после переворота):");
        PrintArray(transposedArray);
    }

    // метод для вывода массива
    static void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t"); // выводим элементы с табуляцией
            }
            Console.WriteLine(); // переход на новую строку после вывода строки массива
        }
    }

    // метод для переворота массива
    static int[,] TransposeArray(int[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        int[,] transposed = new int[cols, rows]; // создаём новый массив с перевёрнутыми размерами

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposed[j, i] = array[i, j]; // меняем строки и столбцы местами
            }
        }

        return transposed; // возвращаем перевернутый массив
    }
}
