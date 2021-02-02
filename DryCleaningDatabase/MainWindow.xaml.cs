using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DryCleaningDatabase
{
    public partial class MainWindow : Window
    {
        string login;
        string password;
        bool loginIsNotEmpty;
        bool passwordIsNotEmpty;

        public MainWindow()
        {
            InitializeComponent();

            Label1.Content = "Авторизация";
            Button1.Content = "Войти";
            Label2.Content = "Логин";
            Label3.Content = "Пароль";

            loginIsNotEmpty = false;
            passwordIsNotEmpty = false;
            Button1.IsEnabled = false;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            login = InputLogin.Text;
            password = InputPassword.Password;

            bool isRegistrated = false;

            DryCleaningDBContext database = new DryCleaningDBContext();

            if (database.Database.CanConnect())
            {
                using (database)
                {
                    var employees = database.Employees.ToList();
                    var accessRulesList = database.AccessRules.ToList();

                    Employee registredEmployee = new Employee();

                    foreach (Employee employee in employees)
                    {
                        if ((employee.Login == login) && (employee.Password == password))
                        {
                            isRegistrated = true;
                            registredEmployee = employee;
                        }
                    }

                    if (isRegistrated)
                    {
                        MessageBox.Show("Вход выполнен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (registredEmployee.Role == accessRulesList[0])
                        {
                            WindowAdmin windowAdmin = new WindowAdmin();
                            windowAdmin.Show();
                            Close();
                        }
                        else
                        {
                            WindowUser windowUser = new WindowUser();
                            windowUser.Show();
                            Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }


            }
            else
            {
                MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InputLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputLogin.Text != "")
            {
                loginIsNotEmpty = true;
            }
            else
            {
                loginIsNotEmpty = false;
            }

            if (loginIsNotEmpty && passwordIsNotEmpty)
            {
                Button1.IsEnabled = true;
            }
            else
            {
                Button1.IsEnabled = false;
            }
        }

        private void InputPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (InputPassword.Password != "")
            {
                passwordIsNotEmpty = true;
            }
            else
            {
                passwordIsNotEmpty = false;
            }

            if (loginIsNotEmpty && passwordIsNotEmpty)
            {
                Button1.IsEnabled = true;
            }
            else
            {
                Button1.IsEnabled = false;
            }
        }
    }
}
