using System;

class Program
{ // В массиве на 30 элементов содержатся данные по росту учеников в классе. Рост мальчиков условно задан отрицательными
  // значениями. Вычислить и вывести количество мальчиков и девочек в классе и средний рост для мальчиков и девочек.
  // При выводе избавиться от отрицательных значений. 
    static void Main()
    {
        // Инициализируем массив из 30 элементов
        int[] heights = { 160, -175, 150, -180, 165, 170, 155, -168, -170, 157,
                          145, 158, -165, 172, 169, -178, 162, 154, -160, 175,
                          170, -185, 159, -172, -155, 180, 172, 150, 165, -164 };

        // вводим переменные для подсчета количества мальчиков и девочек
        int boysCount = 0;
        int girlsCount = 0;

        // теперь переменные для суммирования роста мальчиков и девочек
        int boysHeightSum = 0;
        int girlsHeightSum = 0;

        // проходим по массиву и собираем статистику
        foreach (int height in heights)
        {
            if (height < 0) // у мальчиков есть отрицательные значения роста
            {
                boysCount++;
                boysHeightSum += -height; // далее добавляем к сумме рост, избавляясь от отрицательного знака
            }
            else // у девочек есть положительные значения роста
            {
                girlsCount++;
                girlsHeightSum += height; // складываем значения роста девочек
            }
        }

        // проверяем для того, чтобы избежать деления на ноль при вычислении среднего роста
        double averageBoysHeight = boysCount > 0 ? (double)boysHeightSum / boysCount : 0.0;
        double averageGirlsHeight = girlsCount > 0 ? (double)girlsHeightSum / girlsCount : 0.0;

        // выводим результаты на экран
        Console.WriteLine($"Количество мальчиков: {boysCount}");
        Console.WriteLine($"Средний рост мальчиков: {averageBoysHeight:F2} см");
        Console.WriteLine($"Количество девочек: {girlsCount}");
        Console.WriteLine($"Средний рост девочек: {averageGirlsHeight:F2} см");
    }
}
