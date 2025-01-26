using System;
using System.Collections.Generic;

class Program
{ // Заполнить массив случайными положительными и отрицательными числами таким образом, чтобы все числа по модулю
  // были разными.Это значит, что в массиве не может быть ни только двух равных чисел, но не может быть двух
  // равных по модулю.В полученном массиве найти наибольшее по модулю число.
    static void Main()
    {
        // определяем размерность массива
        int size = 10;
        // создаём массив для хранения чисел
        int[] numbers = new int[size];

        // множество для отслеживания использованных модулей
        HashSet<int> usedModules = new HashSet<int>();

        Random random = new Random();

        // теперь заполняем массив случайными числами
        for (int i = 0; i < size; i++)
        {
            int num;
            do
            {
                // генерируем случайное число от -size до size, кроме 0
                num = random.Next(-size, size + 1);
            } while (num == 0 || usedModules.Contains(Math.Abs(num)));

            // добавляем модуль числа в множество
            usedModules.Add(Math.Abs(num));
            // записываем сгенерированное число в массив
            numbers[i] = num;
        }

        // вывод полученного массива
        Console.WriteLine("Сгенерированный массив:");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }

        // поиск наибольшего по модулю числа
        int maxByAbs = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (Math.Abs(numbers[i]) > Math.Abs(maxByAbs))
            {
                maxByAbs = numbers[i];
            }
        }

        // вывод результата
        Console.WriteLine($"Наибольшее по модулю число: {maxByAbs} (модуль: {Math.Abs(maxByAbs)})");
    }
}
