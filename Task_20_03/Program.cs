namespace Task_20_03
{
    using System;

    // возможные статусы заказа
        enum OrderStatus
        {
            New,        // новый заказ
            Processing, // заказ в обработке
            Shipped,    // заказ отправлен
            Delivered,  // заказ доставлен
            Cancelled   // заказ отменён
        }

        class Program
        {
            static void Main(string[] args)
            {
                // инициализация начального статуса заказа
                OrderStatus currentStatus = OrderStatus.New;
                Console.WriteLine($"Текущий статус заказа: {currentStatus}");

                // меню, чтобы изменить статус
                while (true)
                {
                    Console.WriteLine("\nВыберите действие:");
                    Console.WriteLine("1 - Перевести в статус 'Заказ в обработке'");
                    Console.WriteLine("2 - Перевести в статус 'Заказ отправлен'");
                    Console.WriteLine("3 - Перевести в статус 'Заказ доставлен'");
                    Console.WriteLine("4 - Перевести в статус 'Заказ отменён'");
                    Console.WriteLine("0 - Выход");

                    string input = Console.ReadLine();

                    if (input == "0") break;

                    try
                    {
                        OrderStatus newStatus = input switch
                        {
                            "1" => OrderStatus.Processing,
                            "2" => OrderStatus.Shipped,
                            "3" => OrderStatus.Delivered,
                            "4" => OrderStatus.Cancelled,
                            _ => throw new ArgumentException("Неверный выбор")
                        };

                        // попытка поменять статус
                        if (ChangeOrderStatus(ref currentStatus, newStatus))
                        {
                            Console.WriteLine($"Статус успешно изменён на: {currentStatus}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                }
            }

            // метод для изменения статуса заказа
            static bool ChangeOrderStatus(ref OrderStatus currentStatus, OrderStatus newStatus)
            {
                // проверка, возможно ли изменить текущий статус
                if (currentStatus == OrderStatus.Delivered || currentStatus == OrderStatus.Cancelled)
                {
                    Console.WriteLine($"Ошибка: Невозможно изменить статус. Текущий статус: {currentStatus}");
                    return false;
                }

                // проверка на переход статусов
                if (newStatus < currentStatus && newStatus != OrderStatus.Cancelled)
                {
                    Console.WriteLine($"Ошибка: Невозможно перевести заказ из {currentStatus} в {newStatus}");
                    return false;
                }

                currentStatus = newStatus;
                return true;
            }
        }
    }