class Program
{ //У пользователя в консоли запрашивается число n, генерируется квадратный массив
  //целых числе [n*n]. Заполнение случайными числами в диапазоне от 10 до 99 включительно.
  //Найти и вывести отдельно минимальный элемент в матрице (LINQ под запретом) Осуществить
  //умножение матрицы на ее минимальный элемент, при выводе цветом выделить пять максимальных значений в массиве 
    static void Main()
    {
        // запрашиваем у пользователя на ввод размера массива
        Console.Write("Введите размер массива n: ");
        int n = int.Parse(Console.ReadLine()); // Читаем размер и преобразуем в целое число

        // создаём квадратный массив размером n*n
        int[,] array = new int[n, n];

        // заполняем массив случайными числами от 10 до 99
        FillArray(array);

        // выводим оригинальный массив
        Console.WriteLine("Оригинальный массив:");
        PrintArray(array);

        // находим минимальный элемент
        int minElement = FindMinElement(array);
        Console.WriteLine($"Минимальный элемент: {minElement}");

        // умножение всех элементов на минимальный элемент
        MultiplyByMinElement(array, minElement);

        // выводим обновлённый массив с выделением максимальных значений
        Console.WriteLine("Масштабированный массив (умноженный на минимальный элемент):");
        PrintHighlightedMaxElements(array);
    }

    // метод для заполнения массива случайными числами
    static void FillArray(int[,] array)
    {
        Random random = new Random(); // инициализация генератора случайных чисел
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(10, 100); // заполнение случайным числом от 10 до 99
            }
        }
    }

    // метод для вывода массива
    static void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                // выводим элемент массива с табуляцией
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine(); // переход на новую строку
        }
    }

    // метод для поиска минимального элемента в массиве
    static int FindMinElement(int[,] array)
    {
        int min = array[0, 0]; // начинаем с первого элемента
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] < min) // если текущий элемент меньше минимального
                {
                    min = array[i, j]; // обновляем минимальный элемент
                }
            }
        }
        return min; // возвращаем найденный минимальный элемент
    }

    // метод для умножения элементов массива на минимальный элемент
    static void MultiplyByMinElement(int[,] array, int minElement)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] *= minElement; // умножаем каждый элемент на минимальный элемент
            }
        }
    }

    // метод для вывода массива с выделением пяти максимальных значений
    static void PrintHighlightedMaxElements(int[,] array)
    {
        int[] maxValues = new int[5]; // массив для хранения максимальных значений
        int count = 0;
        // находим пять максимальных значений
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (count < 5)
                {
                    maxValues[count] = array[i, j];
                    count++;
                    Array.Sort(maxValues, 0, count); // теперь сортируем найденные максимальные значения
                }
                else if (array[i, j] > maxValues[0]) // если больше минимального из максимумов
                {
                    maxValues[0] = array[i, j];
                    Array.Sort(maxValues); // сортируем массив максимальных значений
                }
            }
        }
    }
}
