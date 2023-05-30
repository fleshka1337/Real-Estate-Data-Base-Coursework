using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace lr1bd
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly string dataConnect = "server=localhost; user=root; database=mydb;port=3306;password=root";
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра класса RegWindow 
            RegWindow regWindow = new RegWindow();
            // Отображение созданного окна
            regWindow.ShowDialog();

        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем логин и пароль из textbox
            string login = TB1.Text;
            string password = TB2.Text;

            // Проверяем, что логин и пароль не пустые
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                // Показываем сообщение об ошибке
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            // Создаем команду для проверки логина и пароля в базе данных
            //SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Login = @login AND Password = @password", connection);

            string SqlInstruction = "SELECT AccountType FROM Users WHERE Login=@login AND Password=@password";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = dataConnect;
            MySqlCommand cmd = new MySqlCommand(SqlInstruction, conn);

            // Добавляем параметры для логина и пароля
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", password);

            // Открываем подключение к базе данных
            conn.Open();

            // Выполняем команду и получаем количество совпадающих записей
            //int count = (int)cmd.ExecuteScalar();
            //object result = cmd.ExecuteScalar();

            // Выполняем команду и получаем результат
            object result = cmd.ExecuteScalar();

            // Если результат не равен null, то пользователь найден и авторизован
            if (result != null)
            {
                // Преобразуем результат в строку
                string accountType = result.ToString();
                // Выводим сообщение в зависимости от типа аккаунта
                switch (accountType)
                {
                    case "Администратор":
                        MessageBox.Show("Вы успешно авторизовались как администратор!");
                        this.Hide();
                        // Создание экземпляра класса MainWindow 
                        MainWindow mainWindow = new MainWindow();
                        // Отображение созданного окна
                        mainWindow.ShowDialog();
                        this.Close();
                        break;
                    case "Риелтор":
                        MessageBox.Show("Вы успешно авторизовались как Риелтор!");
                        this.Hide();
                        // Создание экземпляра класса MainWindow 
                        Realtor realtor = new Realtor();
                        // Отображение созданного окна
                        realtor.ShowDialog();
                        this.Close();
                        break;
                    case "Застройщик":
                        MessageBox.Show("Вы успешно авторизовались как Застройщик!");
                        this.Hide();
                        // Создание экземпляра класса MainWindow 
                        BuildingDeveloper buildingDeveloper = new BuildingDeveloper();
                        // Отображение созданного окна
                        buildingDeveloper.ShowDialog();
                        this.Close();
                        break;
                    default:
                        MessageBox.Show("Вы успешно авторизовались, но ваш тип аккаунта неизвестен! \nВ доступе отказано!");
                        break;
                }
            }
            // Иначе пользователь не найден или ввел неверные данные
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }

            // Закрываем соединение с базой данных
            conn.Close();


            /*            this.Hide();
                        // Создание экземпляра класса MainWindow 
                        MainWindow mainWindow = new MainWindow();
                        // Отображение созданного окна
                        mainWindow.ShowDialog();
                        this.Close();*/

        }
    }
}
