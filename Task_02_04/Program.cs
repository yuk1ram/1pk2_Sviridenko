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

        // получение текущей даты
        DateTime today = DateTime.Today;
        int currentYear = today.Year;
        int currentMonth = today.Month;
        int currentDay = today.Day;

        // расчёт возраста
        int age = currentYear - birthYear;

        if (birthMonth < currentMonth)
        {
            // возраст точный
        }
        else if (birthMonth == currentMonth)
        {
            if (birthDay <= currentDay)
            {
                // возраст точный
            }
            else
            {
                age--; // ещё не было дня рождения в этом году
            }
        }
        else
        {
            age--; // ещё не было дня рождения в этом году
        }

        // проверка совершеннолетия и вывод результата
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
