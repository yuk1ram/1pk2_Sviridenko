using System;

class Program
{// Заполнить массив из 10 элементов случайными числами в интервале [-10..10]
 // и сделать реверс элементов отдельно для 1-ой и 2-ой половин массива. Реверс реализовать
 // через цикл. Стандартные методы класса Array использовать нельзя. 
    static void Main()
    {
        // создаём объект Random для выбора случайных чисел
        Random random = new Random();

        // инициализируем массив из 10 элементов
        int[] array = new int[10];

        // теперь заполняем массив случайными числами в интервале [-10..10]
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-10, 11); // выбираем случайное число от -10 до 10
        }

        // выводим исходный массив
        Console.WriteLine("Исходный массив: [" + string.Join(", ", array) + "]");

        // ищем середину массива
        int mid = array.Length / 2;

        // реверсируем первую половину массива
        for (int i = 0; i < mid / 2; i++)
        {
            // Меняем местами элементы
            int temp = array[i];
            array[i] = array[mid - 1 - i];
            array[mid - 1 - i] = temp;
        }

        // теперь вторую половину массива
        for (int i = mid; i < mid + (array.Length - mid) / 2; i++)
        {
            // меняем местами элементы
            int temp = array[i];
            array[i] = array[array.Length - 1 - (i - mid)];
            array[array.Length - 1 - (i - mid)] = temp;
        }

        // выводим результат
        Console.WriteLine("Результат: [" + string.Join(", ", array) + "]");
    }
}
