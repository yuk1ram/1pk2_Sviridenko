using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    { // В массиве найти элементы, которые в нем встречаются только один раз, и вывести их на экран. То есть найти и
      // вывести уникальные элементы массива. ( LINQ использовать нельзя )
        int[] array = { 1, 2, 3, 4, 2, 3, 5, 6, 7, 8, 1 };

        // словарь для подсчёта количества вхождений каждого элемента
        Dictionary<int, int> countDictionary = new Dictionary<int, int>();

        // проходим по каждому элементу массива
        foreach (int num in array)
        {
            // если элемент уже присутствует в словаре, то увеличиваем счётчик
            if (countDictionary.ContainsKey(num))
            {
                countDictionary[num]++;
            }
            else
            {
                // если элемента нет в словаре, тогда добавляем его с начальным значением в виде единицы
                countDictionary[num] = 1;
            }
        }

        // выводим элементы, встречающиеся только один раз
        Console.WriteLine("Уникальные элементы массива:");
        foreach (var pair in countDictionary)
        {
            if (pair.Value == 1)
            {
                Console.WriteLine(pair.Key);
            }
        }
    }
}

