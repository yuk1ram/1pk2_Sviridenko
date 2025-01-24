using System;

public class MathCalculations
{ 
    public static void Main(string[] args)
    {
        // Задача 1
        double a1 = 0;
        double b1 = -6;
        double c1 = -2;
        double result1 = CalculateExpression1(a1, b1, c1);
        Console.WriteLine($"Результат выражения 1: {result1}");

        // Задача 2
        double a2 = 8;
        double b2 = 14;
        double c2 = Math.PI / 4;
        double result2 = CalculateExpression2(a2, b2, c2);
        Console.WriteLine($"Результат выражения 2: {result2}");

        //Задача 3
        EmulateRegistration();
    }


    // Метод для вычисления выражения 1
    public static double CalculateExpression1(double a, double b, double c)
    {
        double arctgA = Math.Atan(a);
        double cosA = Math.Cos(a);
        double absA_minus_B = Math.Abs(a - b);
        double aSquared = a * a;

        return (5 * arctgA - cosA) / (4 * absA_minus_B * c + aSquared);

    }


    // Метод для вычисления выражения 2
    public static double CalculateExpression2(double a, double b, double c)
    {
        double sqrtB = Math.Sqrt(b);
        double cuberootA = Math.Pow(a, 1.0 / 3.0);
        double sinSquaredC = Math.Pow(Math.Sin(c), 2);
        double tanC = Math.Tan(c);
        double absA_minus_B = Math.Abs(a - b);

        double numerator = Math.Sqrt(Math.Sqrt(b) + Math.Pow(a, 1.0 / 3.0) - 1);
        double denominator = absA_minus_B * (sinSquaredC + tanC);

        if (denominator == 0)
        {
            Console.WriteLine("Division by zero detected");
            return double.NaN;
        }

        return numerator / denominator;
    }

    // Метод для эмуляции регистрации
    public static void EmulateRegistration()
    {
        Console.WriteLine("Выберите действие:");
        Console.WriteLine("1. Зарегистрироваться");
        Console.WriteLine("2. Выйти");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Имитация регистрации...");
                Console.WriteLine("Пользователь зарегистрирован");
                break;
            case "2":
                Console.WriteLine("Выход из системы");
                break;
            default:
                Console.WriteLine("Некорректный выбор");
                break;
        }
    }
}
