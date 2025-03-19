namespace Task_13_03
{
    using System;

    public class Car
    {
        // свойства:
        public string LicensePlate { get; set; } // номер 
        public string Brand { get; set; }       // марка 
        public string Color { get; set; }       // цвет 
        public double CurrentSpeed { get; set; } // текущая скорость ( в км/ч )

        // константа для допустимой скорости
        private const double MaxSpeed = 120.0;

        // конструкторы:

        // 1. конструктор по умолчанию
        public Car()
        {
            LicensePlate = "Неизвестно";
            Brand = "Неизвестно";
            Color = "Неизвестно";
            CurrentSpeed = 0.0;
        }

        // 2. конструктор: номер и марка
        public Car(string licensePlate, string brand)
        {
            LicensePlate = licensePlate;
            Brand = brand;
            Color = "Неизвестно";
            CurrentSpeed = 0.0;
        }

        // 3. конструктор: номер, марка и цвет
        public Car(string licensePlate, string brand, string color)
        {
            LicensePlate = licensePlate;
            Brand = brand;
            Color = color;
            CurrentSpeed = 0.0;
        }

        // 4. полный конструктор
        public Car(string licensePlate, string brand, string color, double currentSpeed)
        {
            LicensePlate = licensePlate;
            Brand = brand;
            Color = color;
            CurrentSpeed = currentSpeed;
        }

        // методы:

        // 1. езда 
        public void Accelerate(double acceleration, double time)
        {
            // acceleration - ускорение (км/ч/с)
            // time - время ускорения (в секундах)

            double newSpeed = CurrentSpeed + acceleration * time;

            if (newSpeed > MaxSpeed)
            {
                Console.WriteLine("Превышение допустимой скорости! Максимальная скорость: " + MaxSpeed + " км/ч");
                CurrentSpeed = MaxSpeed;
            }
            else
            {
                CurrentSpeed = newSpeed;
            }

            Console.WriteLine($"Автомобиль {Brand} {LicensePlate} ускоряется. Текущая скорость: {CurrentSpeed:F2} км/ч"); // :F2 — форматирование до 2 знаков после запятой
        }

        // 2. торможение
        public void Brake()
        {
            if (CurrentSpeed > MaxSpeed)
            {
                Console.WriteLine($"Автомобиль {Brand} {LicensePlate} превысил допустимую скорость и резко тормозит!");
                CurrentSpeed = 0.0; // полная остановка
            }
            else
            {
                Console.WriteLine($"Автомобиль {Brand} {LicensePlate} замедляется.");
                CurrentSpeed = 0.0; // останавливаем автомобиль 
            }

            Console.WriteLine($"Автомобиль {Brand} {LicensePlate} остановился. Текущая скорость: {CurrentSpeed} км/ч");
        }

        // метод для вывода информации о машине
        public void PrintInfo()
        {
            Console.WriteLine("Номер: " + LicensePlate);
            Console.WriteLine("Марка: " + Brand);
            Console.WriteLine("Цвет: " + Color);
            Console.WriteLine("Текущая скорость: " + CurrentSpeed + " км/ч");
            Console.WriteLine();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {


            Car car1 = new Car(); // конструктор по умолчанию
            car1.PrintInfo();

            Car car2 = new Car("А123BC77", "BMW"); // конструктор: номер и марка
            car2.Color = "Красный";
            car2.PrintInfo();

            Car car3 = new Car("X001YZ99", "Lada", "Белый", 50.0); // полный конструктор
            car3.PrintInfo();

            car3.Accelerate(5.0, 10.0); // ускорение машины на 5 км/ч в течение 10 секунд
            car3.PrintInfo();

            car3.Accelerate(15.0, 5.0); // превышение скорости
            car3.PrintInfo();

            car3.Brake(); // торможение
            car3.PrintInfo();
        }
    }
}
