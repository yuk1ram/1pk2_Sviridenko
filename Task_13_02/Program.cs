namespace Task_13_02
{
    using System;

    public class Pet
    {
        // свойства
        public string Name { get; set; }      // кличка животного
        public string AnimalType { get; set; } // вид животного
        public int Age { get; set; }           // возраст питомца
        public double Weight { get; set; }        // вес животного
        public bool IsHealthy { get; set; }      // состояние здоровья 

        // конструкторы

        // 1. конструктор по умолчанию — инициализирует значениями по умолчанию
        public Pet()
        {
            Name = "Безымянный";
            AnimalType = "Неизвестно";
            Age = 0;
            Weight = 0.0;
            IsHealthy = true;
        }

        // 2. конструктор: кличка и вид
        public Pet(string name, string animalType)
        {
            Name = name;
            AnimalType = animalType;
            Age = 0;
            Weight = 0.0;
            IsHealthy = true;
        }

        // 3. конструктор: кличка, вид и возраст
        public Pet(string name, string animalType, int age)
        {
            Name = name;
            AnimalType = animalType;
            Age = age;
            Weight = 0.0;
            IsHealthy = true;
        }

        // 4. весь конструктор: все свойства
        public Pet(string name, string animalType, int age, double weight, bool isHealthy)
        {
            Name = name;
            AnimalType = animalType;
            Age = age;
            Weight = weight;
            IsHealthy = isHealthy;
        }

        // методы

        // 1. вывод информации об объекте
        public void PrintInfo()
        {
            Console.WriteLine("Кличка: " + Name);
            Console.WriteLine("Вид животного: " + AnimalType);
            Console.WriteLine("Возраст: " + Age + " лет");
            Console.WriteLine("Вес: " + Weight + " кг");
            Console.WriteLine("Состояние здоровья: " + (IsHealthy ? "Здоров" : "Нездоров")); // Тернарный оператор для красивого вывода
            Console.WriteLine(); // Пустая строка для разделения
        }

        // 2. изменение веса животного
        public void SetWeight(double newWeight)
        {
            if (newWeight >= 0) // проверка на правильность написания веса 
            {
                Weight = newWeight;
                Console.WriteLine($"Вес {Name} изменен на {newWeight} кг");
            }
            else
            {
                Console.WriteLine("Ошибка: Вес не может быть отрицательным.");
            }
        }

        // 3. изменение отметки о здоровье животного
        public void SetHealthStatus(bool healthy)
        {
            IsHealthy = healthy;
            Console.WriteLine($"Состояние здоровья {Name} изменено на: {(IsHealthy ? "Здоров" : "Нездоров")}");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {

            Pet pet1 = new Pet();
            pet1.PrintInfo();

            Pet pet2 = new Pet("Ляля", "Кошка"); // использование конструктора с кличкой и видом животного
            pet2.Age = 2;   // возраст
            pet2.Weight = 3.26; // вес
            pet2.PrintInfo();

            Pet pet3 = new Pet("Тимурчик", "Собака", 1, 6.5, true); // Использование полного конструктора
            pet3.PrintInfo();

            // изменяем вес
            pet3.SetWeight(8.0);
            // изменение состояния здоровья
            pet3.SetHealthStatus(false);
            pet3.PrintInfo();
        }
    }
}
