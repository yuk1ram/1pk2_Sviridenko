using System;
using System.Collections.Generic;

class Program
{ // Дан массив, содержащий последовательность 50 случайных чисел.
  // Найти количество пар элементов, значения которых равны.
    static void Main()
    {
        // создаём массив из 50 случайных чисел
        Random random = new Random();
        int[] numbers = new int[50];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 101); // случайные числа от 1 до 100 включительно 
        }

        // вывод массива на экран
        Console.WriteLine("Сгенерированный массив:");
        Console.WriteLine(string.Join(", ", numbers));

        // словарь для хранения количества вхождений каждого числа
        Dictionary<int, int> counts = new Dictionary<int, int>();

        // теперь подсчитываем количество вхождений каждого числа
        foreach (int number in numbers)
        {
            if (counts.ContainsKey(number))
            {
                counts[number]++;
            }
            else
            {
                counts[number] = 1;
            }
        }

        // переменная для хранения количества пар
        int pairCount = 0;

        // вычисляем количество пар для каждого числа
        foreach (var count in counts.Values)
        {
            if (count > 1)
            {
                // количество пар можно вычисляем по формуле: C(n, 2) = n * (n - 1) / 2
                pairCount += count * (count - 1) / 2;
            }
        }

        // выводим результат
        Console.WriteLine($"Количество пар элементов, значения которых равны: {pairCount}");
    }
}