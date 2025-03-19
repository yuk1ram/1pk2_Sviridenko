namespace Task_10_08
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {

            int[] myArray = { 5, 10, 15, 20, 25, 30 };
            int searchNumber = 15;

            int index = FindElementIndex(myArray, searchNumber);

            if (index != -1)
            {
                Console.WriteLine($"Элемент {searchNumber} найден по индексу: {index}");
            }
            else
            {
                Console.WriteLine($"Элемент {searchNumber} не найден в массиве.");
            }

            searchNumber = 42; // поиск числа, которого нет в массиве
            index = FindElementIndex(myArray, searchNumber);

            if (index != -1)
            {
                Console.WriteLine($"Элемент {searchNumber} найден по индексу: {index}");
            }
            else
            {
                Console.WriteLine($"Элемент {searchNumber} не найден в массиве.");
            }
        }


        public static int FindElementIndex(int[] array, int searchNumber)
        {
            // проходимся по каждому элементу массива
            for (int i = 0; i < array.Length; i++)
            {
                // если нашли искомый элемент, то возвращаем его индекс
                if (array[i] == searchNumber)
                {
                    return i;
                }
            }

            // если элемент не найден, то возвращаем -1
            return -1;
        }
    }
}
