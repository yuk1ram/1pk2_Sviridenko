using System;

class Program
{ // Дан квадратный массив размерность n*n. Произведите анализ данной матрицы и выясните является ли
  // данная матрица Z-матрицей (это матрица, где все недиагональные элементы меньше нуля) Если данное условие
  // выполняется то вывести данную матрицу с цветовой индикацией главной диагонали.Если не выполняется, то
  // вывести сообщение что данная матрица не является Z-матрицей
    static void Main()
    {
        Console.Write("Введите размер матрицы n: ");
        int n = int.Parse(Console.ReadLine());

        // создание и заполнение матрицы
        int[,] matrix = FillMatrix(n);

        // Проверяем Z-матрицу
        if (IsZMatrix(matrix))
        {
            Console.WriteLine("Данная матрица является Z-матрицей. Выводим матрицу с индикацией главной диагонали:");
            PrintMatrixWithDiagonalHighlight(matrix);
        }
        else
        {
            Console.WriteLine("Данная матрица не является Z-матрицей.");
        }
    }

    // метод для заполнения матрицы случайными числами от -9 до 9
    static int[,] FillMatrix(int size)
    {
        Random rand = new Random();
        int[,] matrix = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = rand.Next(-9, 10); // заполнение числами от -9 до 9
            }
        }

        return matrix;
    }

    // метод для проверки на Z-матрицу
    static bool IsZMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                // проверяем, что все недиагональные элементы меньше нуля
                if (i != j && matrix[i, j] >= 0)
                {
                    return false; // если недиагональный элемент не меньше 0, то не Z-матрица
                }
            }
        }
        return true; // если все условия выполнены, тогда это Z-матрица
    }

    // метод для вывода матрицы с индикацией главной диагонали
    static void PrintMatrixWithDiagonalHighlight(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                // если элемент на главной диагонали
                if (i == j)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // изменение цвета текста
                    Console.Write(matrix[i, j] + "\t");
                    Console.ResetColor(); // сброс цвета текста
                }
                else
                {
                    Console.Write(matrix[i, j] + "\t"); // вывод остальных элементыов
                }
            }
            Console.WriteLine(); // переход на новую строку после каждой строки матрицы
        }
    }
}
