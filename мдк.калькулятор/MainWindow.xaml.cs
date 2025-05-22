using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string operation = "";
        private bool isOperationClicked = false;
        private bool isEqualsClicked = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        // обработчик цифр от 0 до 9 (включительно)
        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (Display.Text == "0" || isOperationClicked || isEqualsClicked)
            {
                Display.Text = "";
                isOperationClicked = false;
                isEqualsClicked = false;
            }

            Display.Text += button.Content.ToString();
        }

        // обработчик операций (+, -, *, /, ^)
        private void BtnOperation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (double.TryParse(Display.Text, out firstNumber))
            {
                operation = button.Content.ToString();
                isOperationClicked = true;
            }
        }

        // обработчик кнопки "="
        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text, out secondNumber))
            {
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                            result = firstNumber / secondNumber;
                        else
                            MessageBox.Show("На ноль делить нельзя", "Ошибка!");
                        break;
                    case "^":
                        result = Math.Pow(firstNumber, secondNumber);
                        break;
                }

                Display.Text = result.ToString();
                isEqualsClicked = true;
            }
        }

        // обработчик квадратного корня
        private void BtnSqrt_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text, out double number) && number >= 0)
            {
                Display.Text = Math.Sqrt(number).ToString();
            }
            else
            {
                MessageBox.Show("Невозможно извлечь корень из отрицательного числа", "Ошибка!");
            }
        }

        // обработчик для очистки всей строки
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
            operation = "";
        }

       // обработчик удаления последнего символа
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text.Length > 1)
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            }
            else
            {
                Display.Text = "0";
            }
        }

        // обработчик десятичной запятой
        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            if (!Display.Text.Contains(","))
            {
                Display.Text += ",";
            }
        }
    }
}