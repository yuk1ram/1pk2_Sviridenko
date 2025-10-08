using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace VetClinicApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Client> Clients { get; set; }
        public ObservableCollection<Pet> Pets { get; set; }
        public ObservableCollection<Service> Services { get; set; }
        public ObservableCollection<Appointment> Appointments { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация коллекций
            Clients = new ObservableCollection<Client>();
            Pets = new ObservableCollection<Pet>();
            Services = new ObservableCollection<Service>();
            Appointments = new ObservableCollection<Appointment>();
            Employees = new ObservableCollection<Employee>();

            // Привязка данных
            clientsGrid.ItemsSource = Clients;
            petsGrid.ItemsSource = Pets;
            cmbClients.ItemsSource = Clients;
            cmbAppointmentClient.ItemsSource = Clients;
            cmbAppointmentService.ItemsSource = Services;
            servicesGrid.ItemsSource = Services;
            appointmentsGrid.ItemsSource = Appointments;
            employeesGrid.ItemsSource = Employees;

            // Загрузка тестовых данных
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // клиенты (для примера)
            Clients.Add(new Client { Id = 1, FullName = "Иванов Иван Иванович", Phone = "+7-912-345-67-89", Email = "ivanov@mail.ru" });
            Clients.Add(new Client { Id = 2, FullName = "Петрова Мария Сергеевна", Phone = "+7-923-456-78-90", Email = "petrova@mail.ru" });

            // услуги (для примера)
            Services.Add(new Service { Id = 1, Name = "Консультация", Price = 500, Duration = TimeSpan.FromMinutes(30) });
            Services.Add(new Service { Id = 2, Name = "Вакцинация", Price = 1000, Duration = TimeSpan.FromMinutes(15) });

            // сотрудники (для примера)
            Employees.Add(new Employee { Id = 1, FullName = "Иванов Петр Сидорович", Position = "Ветеринар", AccessLevel = "Vet" });
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                var client = new Client
                {
                    Id = Clients.Any() ? Clients.Max(c => c.Id) + 1 : 1,
                    FullName = txtClientName.Text,
                    Phone = txtClientPhone.Text,
                    Email = txtClientEmail.Text,
                    Address = txtClientAddress.Text
                };

                Clients.Add(client);

                // очистка полей
                txtClientName.Clear();
                txtClientPhone.Clear();
                txtClientEmail.Clear();
                txtClientAddress.Clear();
            }
        }

        private void AddPet_Click(object sender, RoutedEventArgs e)
        {
            if (cmbClients.SelectedItem is Client selectedClient &&
                !string.IsNullOrWhiteSpace(txtPetName.Text))
            {
                var pet = new Pet
                {
                    Id = Pets.Any() ? Pets.Max(p => p.Id) + 1 : 1,
                    Name = txtPetName.Text,
                    Species = txtPetSpecies.Text,
                    Breed = txtPetBreed.Text,
                    Age = int.TryParse(txtPetAge.Text, out int age) ? age : 0,
                    MedicalHistory = txtPetMedicalHistory.Text,
                    Vaccinations = txtPetVaccinations.Text,
                    Owner = selectedClient
                };

                Pets.Add(pet);

                // очистка полей
                txtPetName.Clear();
                txtPetSpecies.Clear();
                txtPetBreed.Clear();
                txtPetAge.Clear();
                txtPetMedicalHistory.Clear();
                txtPetVaccinations.Clear();
            }
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAppointmentClient.SelectedItem is Client client &&
                cmbAppointmentPet.SelectedItem is Pet pet &&
                cmbAppointmentService.SelectedItem is Service service &&
                dpAppointmentDate.SelectedDate.HasValue &&
                cmbAppointmentTime.SelectedItem is ComboBoxItem timeItem)
            {
                var time = TimeSpan.Parse(timeItem.Content.ToString());
                var dateTime = dpAppointmentDate.SelectedDate.Value.Add(time);

                var appointment = new Appointment
                {
                    Id = Appointments.Any() ? Appointments.Max(a => a.Id) + 1 : 1,
                    DateTime = dateTime,
                    Client = client,
                    Pet = pet,
                    Service = service,
                    Notes = txtAppointmentNotes.Text,
                    Status = "Запланирован"
                };

                Appointments.Add(appointment);

                // очистка полей
                txtAppointmentNotes.Clear();
            }
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtServiceName.Text) &&
                decimal.TryParse(txtServicePrice.Text, out decimal price))
            {
                var service = new Service
                {
                    Id = Services.Any() ? Services.Max(s => s.Id) + 1 : 1,
                    Name = txtServiceName.Text,
                    Description = txtServiceDescription.Text,
                    Price = price,
                    Duration = TimeSpan.FromMinutes(30)
                };

                Services.Add(service);

                // очистка полей
                txtServiceName.Clear();
                txtServiceDescription.Clear();
                txtServicePrice.Clear();
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmployeeName.Text) &&
                cmbEmployeePosition.SelectedItem is ComboBoxItem positionItem)
            {
                var position = positionItem.Content.ToString();
                var accessLevel = position == "Ветеринар" ? "Vet" : "Admin";

                var employee = new Employee
                {
                    Id = Employees.Any() ? Employees.Max(em => em.Id) + 1 : 1,
                    FullName = txtEmployeeName.Text,
                    Position = position,
                    Phone = txtEmployeePhone.Text,
                    Email = txtEmployeeEmail.Text,
                    Login = txtEmployeeLogin.Text,
                    Password = txtEmployeePassword.Password,
                    AccessLevel = accessLevel
                };

                Employees.Add(employee);

                // очистка полей
                txtEmployeeName.Clear();
                txtEmployeePhone.Clear();
                txtEmployeeEmail.Clear();
                txtEmployeeLogin.Clear();
                txtEmployeePassword.Clear();
            }
        }

        private void ClientsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clientsGrid.SelectedItem is Client selectedClient)
            {
                // обновляем список питомцев для клиента
                var clientPets = Pets.Where(p => p.Owner?.Id == selectedClient.Id).ToList();
                petsGrid.ItemsSource = clientPets;
            }
        }

        private void cmbAppointmentClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAppointmentClient.SelectedItem is Client selectedClient)
            {
                // обновление списка питомцев для клиента
                var clientPets = Pets.Where(p => p.Owner?.Id == selectedClient.Id).ToList();
                cmbAppointmentPet.ItemsSource = clientPets;

                if (clientPets.Any())
                {
                    cmbAppointmentPet.SelectedItem = clientPets.First();
                }
            }
        }
    }

    // классы моделей (должны быть в отдельных файлах, но для простоты здесь)
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string MedicalHistory { get; set; }
        public string Vaccinations { get; set; }
        public Client Owner { get; set; }
    }

    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public Client Client { get; set; }
        public Pet Pet { get; set; }
        public Service Service { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string AccessLevel { get; set; }
    }
}