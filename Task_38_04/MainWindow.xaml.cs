using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace StudentRegistrationApp
{
    // перечисление пола 
    public enum Gender
    {
        Male,
        Female
    }

    // класс с информацией о студенте
    public class Student
    {
        public string SurName { get; set; } // фамилия студента
        public string Name { get; set; } // имя студента
        public string Patronymic { get; set; } // отчество
        public string Group { get; set; } // группа
        public Gender Gender { get; set; } // пол
        public DateTime BirthDate { get; set; }  // дата рождения

        public override string ToString()
        {
            return $"{SurName} {Name} {Patronymic}, {Group}, {Gender}, {BirthDate:dd.MM.yyyy}";
        }
    }

    public partial class MainWindow : Window
    {
        private List<Student> students = new List<Student>(); // список студентов
        private const string DataFilePath = "students.json";  // файл для сохранения данных

        public MainWindow()
        {
            InitializeComponent();
            LoadStudents(); // загружение списка студентов во время запуска приложения
        }

        // загрузка данных файла при запуске
        private void LoadStudents()
        {
            if (File.Exists(DataFilePath))
            {
                try
                {
                    string json = File.ReadAllText(DataFilePath);
                    students = JsonSerializer.Deserialize<List<Student>>(json);
                    studentsListBox.ItemsSource = students;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                }
            }
        }

        // сохранение данных при закрытии приложения
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(students, options);
                File.WriteAllText(DataFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        // обработчик для кнопки "Сохранить"
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(groupTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните обязательные поля (Фамилия, Имя, Группа)");
                return;
            }

            // Создаем нового студента
            Student student = new Student
            {
                SurName = lastNameTextBox.Text,
                Name = firstNameTextBox.Text,
                Patronymic = middleNameTextBox.Text,
                Group = groupTextBox.Text,
                Gender = (Gender)genderComboBox.SelectedIndex,
                BirthDate = birthDatePicker.SelectedDate ?? DateTime.Now
            };

            // добавляем студента 
            students.Add(student);

            // после обновляем ListBox
            studentsListBox.ItemsSource = null;
            studentsListBox.ItemsSource = students;

            // очищаем поля ввода
            ClearInputFields();

            MessageBox.Show("Студент успешно сохранен!");
        }

        // очистка полей ввода
        private void ClearInputFields()
        {
            lastNameTextBox.Text = "";
            firstNameTextBox.Text = "";
            middleNameTextBox.Text = "";
            groupTextBox.Text = "";
            genderComboBox.SelectedIndex = 0;
            birthDatePicker.SelectedDate = DateTime.Now;
        }
    }
}