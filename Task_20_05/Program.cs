namespace Task_20_05
{
    using System;

    namespace AuthorizationSystem
    {
        // перечисление уровней доступа
        public enum AccessLevel
        {
            Guest,      // только чтение
            User,       // чтение + комментарии
            Moderator,  // удаление контента
            Admin       // полный доступ
        }

        class Program
        {
            static void Main(string[] args)
            {
                // работы системы

                // проверка разрешения для разных уровней доступа
                CheckPermission(AccessLevel.Guest, "удалить пост");
                CheckPermission(AccessLevel.User, "оставить комментарий");
                CheckPermission(AccessLevel.Moderator, "удалить пост");
                CheckPermission(AccessLevel.Admin, "изменить настройки системы");

                // пример с вводом от пользователя
                Console.WriteLine("\nПроверьте свой уровень доступа:");
                Console.WriteLine("0 - Guest, 1 - User, 2 - Moderator, 3 - Admin");
                Console.Write("Введите ваш уровень доступа: ");

                if (int.TryParse(Console.ReadLine(), out int level))
                
                {
                    if (Enum.IsDefined(typeof(AccessLevel), level))
                    {
                        AccessLevel userLevel = (AccessLevel)level;
                        Console.Write("Какое действие хотите выполнить? ");
                        string action = Console.ReadLine();
                        CheckPermission(userLevel, action);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Неверный уровень доступа!");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите число от 0 до 3!");
                }
            }

            // метод для проверки прав доступа
            static void CheckPermission(AccessLevel level, string action)
            {
                Console.Write($"Пользователь с уровнем {level} пытается {action}: ");

                switch (level)
                {
                    case AccessLevel.Guest:
                        if (action == "читать")
                            Console.WriteLine("Разрешено!");
                        else
                            Console.WriteLine("Ошибка: Недостаточно прав! Доступно только чтение.");
                        break;

                    case AccessLevel.User:
                        if (action == "читать" || action == "оставить комментарий")
                            Console.WriteLine("Разрешено!");
                        else
                            Console.WriteLine("Ошибка: Недостаточно прав! Доступно чтение и комментарии.");
                        break;

                    case AccessLevel.Moderator:
                        if (action == "удалить пост" || action == "читать" || action == "оставить комментарий")
                            Console.WriteLine("Разрешено!");
                        else
                            Console.WriteLine("Ошибка: Недостаточно прав! Доступно управление контентом.");
                        break;

                    case AccessLevel.Admin:
                        Console.WriteLine("Разрешено! Полный доступ.");
                        break;
                }
            }
        }
    }
}
