namespace Task_20_04
{

    using System;
    using System.Collections.Generic;

    namespace VehicleManagement
    {
        //  типы транспортных средств
        enum VehicleType
        {
            Car,        // легковой автомобиль
            Bike,       // велосипед
            Bus,        // ввтобус
            Truck,      // грузовик
            Motorcycle  // мотоцикл
        }

        class Program
        {
            static void Main(string[] args)
            {
                // создание списка хранения транспортных средств
                List<VehicleType> vehicles = new List<VehicleType>();

                // Добавляем несколько транспортных средств в список
                vehicles.Add(VehicleType.Truck);
                vehicles.Add(VehicleType.Car);
                vehicles.Add(VehicleType.Bike);
                vehicles.Add(VehicleType.Bus);
                vehicles.Add(VehicleType.Motorcycle);
                vehicles.Add(VehicleType.Truck);
               
                // вывод их общего количества 
                Console.WriteLine($"Всего транспортных средств: {vehicles.Count}");

                // количество транспорта каждого типа
                Console.WriteLine("\nКоличество по типам:");
                foreach (VehicleType type in Enum.GetValues(typeof(VehicleType)))
                {
                    int count = CountVehiclesByType(vehicles, type);
                    Console.WriteLine($"{type}: {count}");
                }

                // поиск определенного транспорта
                Console.WriteLine("\nПоиск транспорта по типу:");
                Console.Write("Введите тип транспорта (Car, Bike, Bus, Truck, Motorcycle): ");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out VehicleType searchType))
                {
                    List<VehicleType> foundVehicles = FindVehiclesByType(vehicles, searchType);

                    Console.WriteLine($"\nНайдено {foundVehicles.Count} транспортных средств типа {searchType}:");
                    foreach (var vehicle in foundVehicles)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
                else
                {
                    Console.WriteLine("Неверный тип транспорта!");
                }
            }

            // метод для подсчета определенных транспортных средств
            static int CountVehiclesByType(List<VehicleType> vehicles, VehicleType type)
            {
                int count = 0;
                foreach (var vehicle in vehicles)
                {
                    if (vehicle == type)
                    {
                        count++;
                    }
                }
                return count;
            }

            // метод для поиска определенных транспортных средств
            static List<VehicleType> FindVehiclesByType(List<VehicleType> vehicles, VehicleType type)
            {
                List<VehicleType> result = new List<VehicleType>();
                foreach (var vehicle in vehicles)
                {
                    if (vehicle == type)
                    {
                        result.Add(vehicle);
                    }
                }
                return result;
            }
        }
    }
}