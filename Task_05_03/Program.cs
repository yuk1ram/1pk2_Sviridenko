using System;

class Program
{ // Даны два массива, заполненные символами английского алфавита размером 3*3. Проверить, являются
  // ли матрицы равными, если да, то вывести сообщение о том, что они равны, если нет, то вывести
  // повторно матрицы с цветовой индикацией только тех элементов, которые равны.
  // (матрицы считаются равными, если их соответствующие элементы равны).  
    static void Main()
    {
        // инициализируем две матрицы 3x3
        char[,] matrix1 = new char[3, 3];
        char[,] matrix2 = new char[3, 3];

        // заполняем первую матрицу случайными буквами
        FillMatrix(matrix1);
        // затем вторую матрицу случайными буквами
        FillMatrix(matrix2);

        // проверяем, равны ли матрицы
        if (AreMatricesEqual(matrix1, matrix2))
        {
            Console.WriteLine("Матрицы равны.");
        }
        else
        {
            Console.WriteLine("Матрицы не равны. Вот их содержимое с индикацией равных элементов:");
            PrintMatricesWithHighlight(matrix1, matrix2);
        }
    }

    // метод для заполнения матрицы случайными буквами
    static void FillMatrix(char[,] matrix)
    {
        Random random = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                // генерируем случайную букву от 'A' до 'Z'
                matrix[i, j] = (char)random.Next('A', 'Z' + 1);
            }
        }
    }

    // метод для проверки равенства матриц
    static bool AreMatricesEqual(char[,] matrix1, char[,] matrix2)
    {
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                if (matrix1[i, j] != matrix2[i, j])
                {
                    return false; // если хотя бы один элемент не равен, то и матрицы не равны
                }
            }
        }
        return true; // все элементы равны
    }

    // метод для вывода матриц с индикацией равных элементов
    static void PrintMatricesWithHighlight(char[,] matrix1, char[,] matrix2)
    {
        Console.WriteLine("Матрица 1:");
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                // проверяем, равны ли элементы
                if (matrix1[i, j] == matrix2[i, j])
                {
                    // если равны, выводим с тёмно-красным цветом
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else
                {
                    // если не равны, то выводим с серым цветом
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write(matrix1[i, j] + " ");
                Console.ResetColor(); // сброс цвета
            }
            Console.WriteLine();
        }

        Console.WriteLine("Матрица 2:");
        for (int i = 0; i < matrix2.GetLength(0); i++)
        {
            for (int j = 0; j < matrix2.GetLength(1); j++)
            {
                // проверяем, равны ли элементы
                if (matrix1[i, j] == matrix2[i, j])
                {
                    // если равны, то выводим с жёлтым цветом
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    // если не равны, выводим с синим цветом
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write(matrix2[i, j] + " ");
                Console.ResetColor(); // сброс цвета
            }
            Console.WriteLine();
        }
    }
}
