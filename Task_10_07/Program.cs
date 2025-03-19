namespace Task_10_07
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int rows = 5;   // кол-во строк в массиве
            int cols = 7;   // кол-во столбцов 

            // генерируем символьный массив
            char[,] charArray = GenerateCharArray(rows, cols);

            // вывод массива на консоль
            PrintCharArray(charArray);
        }


        public static char[,] GenerateCharArray(int rows, int cols)
        {
            char[,] array = new char[rows, cols];
            Random random = new Random();

            // русский алфавит 
            string alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            // заполнение массива случайными буквами алфавита
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int randomIndex = random.Next(0, alphabet.Length);  // рандомный индекс в алфавите
                    array[i, j] = alphabet[randomIndex];                 // присваиваем букву из алфавита элементу массива
                }
            }

            return array;
        }


        public static void PrintCharArray(char[,] array)
        {
            Console.WriteLine("Сгенерированный массив:");

            // перебираем строки массива
            for (int i = 0; i < array.GetLength(0); i++)
            {
                // перебираем столбцы массива
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");  // вывод символа с пробелом
                }
                Console.WriteLine();  // переход на новую строку после каждой строки массива
            }
        }
    }
}