using System;

public class AgeChecker
{ // *Пользователь вводит свою дату рождения построчно (сначала год, потом месяц и в конце дату)
  // произведите расчет является ли пользователь совершеннолетним на текущую
  // дату и выведите соответствующее сообщение об этом.
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите данные о рождении:");

        Console.Write("Год: ");
        int birthYear = int.Parse(Console.ReadLine());

        Console.Write("Месяц: ");
        int birthMonth = int.Parse(Console.ReadLine());

        Console.Write("День: ");
        int birthDay = int.Parse(Console.ReadLine());

        // Получаем текущую дату
        DateTime today = DateTime.Today;
        int currentYear = today.Year;
        int currentMonth = today.Month;
        int currentDay = today.Day;

        // Расчет возраста
        int age = currentYear - birthYear;

        if (birthMonth < currentMonth)
        {
            // Возраст точный
        }
        else if (birthMonth == currentMonth)
        {
            if (birthDay <= currentDay)
            {
                // Возраст точный
            }
            else
            {
                age--; // Еще не было дня рождения в этом году
            }
        }
        else
        {
            age--; // Еще не было дня рождения в этом году
        }

        // Проверка совершеннолетия и вывод результата
        if (age >= 18)
        {
            Console.WriteLine("Вы совершеннолетний");
        }
        else
        {
            Console.WriteLine("Вы несовершеннолетний");
        }
    }
}
