﻿using System;

class FreeFall
{ //Написать программу, которая выводит таблицу скорости (через каждые 0,5с)
  //свободно падающего тела v = g t ,
  //где 2 g = 9,8 м/с2 – ускорение свободного падения.
    static void Main()
    {
        // ускорение свободного падения в квадратных метрах
        const double g = 9.8;

        // время в секундах, с помощью которого вычислим скорость
        // начнём с 0 и будем увеличивать на 0.5 каждый раз, пока не дойдём до 5 секунд
        for (double t = 0; t <= 5; t += 0.5)
        {
            // рассчитываем скорость по формуле v = g * t
            double v = g * t;

            // выводим время и скорость
            Console.WriteLine($"Время: {t:F1} с, Скорость: {v:F2} м/с");
        }

        // завершение программы
        Console.WriteLine("Конец таблицы.");
    }
}
