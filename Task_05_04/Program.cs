using System;

class Program
{ // Дан квадратный массив размерность n* n.Произведите анализ данной матрицы
  // и выясните является ли данная матрица диагональной (все элементы вне главной
  // диагонали равны нулю) Если матрица является диагональной, то вывести ее повторно
  // с цветовым выделением главной диагонали.Если нет, то вывеси сообщение что матрица
  // не является диагональной.
    static void Main()
    {
        // задаём размер матрицы n*n
        Console.Write("Введите размер матрицы n (целое число): ");
        int n = int.Parse(Console.ReadLine());

        // создаём и заполняем матрицу случайными числами от -10 до 10
        int[,] matrix = new int[n, n];
        FillMatrix(matrix);

        // проверяем, является ли матрица диагональной
        if (IsDiagonalMatrix(matrix))
        {
            Console.WriteLine("Матрица является диагональной. Вот ее содержимое:");
            PrintDiagonalMatrix(matrix);
        }
        else
        {
            Console.WriteLine("Матрица не является диагональной.");
        }
    }

    // метод для заполнения матрицы случайными числами
    static void FillMatrix(int[,] matrix)
    {
        Random random = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                // заполняем матрицу случайными числами от -10 до 10
                matrix[i, j] = random.Next(-10, 11);
            }
        }
    }

    // метод для проверки того, является ли матрица диагональной
    static bool IsDiagonalMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                // проверяем элементы вне диагонали
                if (i != j && matrix[i, j] != 0)
                {
                    return false; // если нашли ненулевой элемент вне главной диагонали
                }
            }
        }
        return true; // все элементы вне диагонали равны 0
    }

    // метод для вывода матрицы с выделением главной диагонали
    static void PrintDiagonalMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == j) // если элемент на главной диагонали
                {
                    Console.ForegroundColor = ConsoleColor.Red; // задаём цвет
                    Console.Write(matrix[i, j] + " "); // выводим элемент
                }
                else
                {
                    Console.ResetColor(); // сброс цвета
                    Console.Write(matrix[i, j] + " "); // вывод элемента
                }
            }
            Console.WriteLine(); // переход на новую строку
        }
        Console.ResetColor(); // сбро цвет после завершения вывода матрицы
    }
}
