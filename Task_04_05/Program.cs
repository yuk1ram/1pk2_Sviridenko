using System;

class Program
{ // В массиве хранятся сведения о количестве осадков за месяц (30 дней). Необходимо определить общее количество
  // осадков, выпавших за каждую декаду месяца, вывести день с самыми сильными осадками за месяц, отдельно
  // вывести дни без осадков.Массив с осадками заполнятся с помощью рандома в диапазоне от 0 – нет осадков,
  // до 300 мм выпавших осадков.
    static void Main(string[] args)
    {
        // создаём массив для хранения осадков за 30 дней
        int[] precipitation = new int[30];
        Random rand = new Random();

        // заполняем массиваслучайными значениями осадков от 0 до 300 мм
        for (int i = 0; i < precipitation.Length; i++)
        {
            precipitation[i] = rand.Next(0, 301); // выбор случайных осадков
        }

        // вызов функции для вычисления и вывода результатов
        AnalyzePrecipitation(precipitation);
    }

    static void AnalyzePrecipitation(int[] precipitation)
    {
        // массив для хранения общего количества осадков за каждую декаду
        int[] decadalPrecipitation = new int[3];

        // переменная, предназначенная для нахождения самого сильного дня осадков
        int maxPrecipitation = 0;
        int dayWithMaxPrecipitation = 0;

        // теперь перебираем каждый день и вычисляем данные
        for (int i = 0; i < precipitation.Length; i++)
        {
            // определяем, в какую декаду попадает день
            if (i < 10) // с 1 по 10 дни
            {
                decadalPrecipitation[0] += precipitation[i];
            }
            else if (i < 20) // с 11 по 20 дни
            {
                decadalPrecipitation[1] += precipitation[i];
            }
            else // с 21 по 30 дни
            {
                decadalPrecipitation[2] += precipitation[i];
            }

            // находим день с максимальными осадками
            if (precipitation[i] > maxPrecipitation)
            {
                maxPrecipitation = precipitation[i];
                dayWithMaxPrecipitation = i + 1; // +1 для того, чтобы день начинался с 1
            }
        }

        // выводим общее количество осадков за каждую декаду
        Console.WriteLine("Общее количество осадков за декады:");
        Console.WriteLine($"1-я декада (1-10 дни): {decadalPrecipitation[0]} мм");
        Console.WriteLine($"2-я декада (11-20 дни): {decadalPrecipitation[1]} мм");
        Console.WriteLine($"3-я декада (21-30 дни): {decadalPrecipitation[2]} мм");

        // выводим информацию о дне с максимальными осадками
        Console.WriteLine($"День с самыми сильными осадками: {dayWithMaxPrecipitation} день, {maxPrecipitation} мм");

        // вывод дней без осадков
        Console.WriteLine("Дни без осадков:");
        for (int i = 0; i < precipitation.Length; i++)
        {
            if (precipitation[i] == 0)
            {
                Console.WriteLine($"{i + 1} день");
            }
        }
    }
}
