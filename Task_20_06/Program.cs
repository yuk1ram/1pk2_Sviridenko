namespace Task_20_06
{
    using System;
    using System.Threading;

    namespace TrafficLightSimulator
    {
        // перечисление для цветов светофора
        enum TrafficLightColor
        {
            Red, // красный
            Yellow, // желтый
            Green // зеленый
        }

        class Program
        {
            static TrafficLightColor currentColor = TrafficLightColor.Red;
            static bool isRunning = true;

            static void Main(string[] args)
            {
                Console.WriteLine("Симулятор светофора");
                Console.WriteLine("Автоматический режим (переключение каждые 3 секунды)");
                Console.WriteLine("Нажмите любую клавишу для ручного переключения");
                Console.WriteLine("Нажмите 'Q' для выхода\n");

                // запуска автоматического переключения 
                Thread autoSwitchThread = new Thread(AutoSwitchColors);
                autoSwitchThread.Start();

                // обработка ручного ввода
                while (isRunning)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.Q)
                        {
                            isRunning = false;
                        }
                        else
                        {
                            ManualSwitchColor();
                        }
                    }
                }

                autoSwitchThread.Join();
                Console.WriteLine("Программа завершена.");
            }

            // метод для автоматического переключения цветов
            static void AutoSwitchColors()
            {
                while (isRunning)
                {
                    SwitchToNextColor();
                    Thread.Sleep(3000); // 3 секунды паузы
                }
            }

            // метод для ручного переключения цвета
            static void ManualSwitchColor()
            {
                Console.WriteLine("\nРучное переключение...");
                SwitchToNextColor();
            }

            // метод для переключения на следующий цвет
            static void SwitchToNextColor()
            {
                // определение следующего цвета по текущему
                currentColor = currentColor switch
                {
                    TrafficLightColor.Red => TrafficLightColor.Yellow,
                    TrafficLightColor.Yellow => TrafficLightColor.Green,
                    TrafficLightColor.Green => TrafficLightColor.Red,
                    _ => TrafficLightColor.Red
                };

                // вывод текущего цвета с соответствующим цветом текста в консоли
                Console.ForegroundColor = currentColor switch
                {
                    TrafficLightColor.Red => ConsoleColor.Red,
                    TrafficLightColor.Yellow => ConsoleColor.Yellow,
                    TrafficLightColor.Green => ConsoleColor.Green,
                    _ => ConsoleColor.White
                };

                Console.WriteLine($"Текущий цвет: {currentColor}");
                Console.ResetColor();
            }
        }
    }
}
