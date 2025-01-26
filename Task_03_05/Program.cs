using System;

class Program
{ // Написать программу, которая выводит на экран таблицу соответствия температуры в градусах Цельсия и
  // Фаренгейта(F = C * 1,8 + 32). Диапазон изменения температуры в градусах Цельсия и шаг должны вводиться во
  // время работы программы.
    static void Main(string[] args)
    {
        // у пользователя делаем запрос на нижнюю границу диапазона температур в Цельсиях
        Console.Write("Введите нижнюю границу температуры в °C: ");
        double lowerBound = Convert.ToDouble(Console.ReadLine());

        // запрашиваем у пользователя верхнюю границу диапазона температур тоже в Цельсиях
        Console.Write("Введите верхнюю границу температуры в °C: ");
        double upperBound = Convert.ToDouble(Console.ReadLine());

        // теперь у запрашиваем шаг для изменения температуры
        Console.Write("Введите шаг изменения температуры в °C: ");
        double step = Convert.ToDouble(Console.ReadLine());

        // проверка того, что верхняя граница больше нижней
        if (upperBound <= lowerBound)
        {
            Console.WriteLine("Ошибка: Верхняя граница должна быть больше нижней границы.");
            return; // завершение программы, если выйдет ошибка
        }

        // вывод заголовка таблицы
        Console.WriteLine("Температура в °C\tТемпература в °F");
        Console.WriteLine("-----------------------------------------");

        // проходим по диапазону от нижней до верхней границ с заданным шагом
        for (double celsius = lowerBound; celsius <= upperBound; celsius += step)
        {
            // вычисление температуры в Фаренгейте
            double fahrenheit = celsius * 1.8 + 32;
            // вывод текущей пары значений в таблице
            Console.WriteLine($"{celsius:F1}\t\t\t{fahrenheit:F1}");
        }
    }
}
