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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        private readonly string dataConnect = "server=localhost; user=root; database=mydb;port=3306;password=root";
        public RegWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BTN2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTN1_Click(object sender, RoutedEventArgs e)
        {
            if (TB1.Text.Length > 0 && TB2.Text.Length > 0 && TB3.Text.Length > 0 && TB4.Text.Length > 0)
            {
                // Получаем тексты из textbox
                string text1 = TB1.Text;
                string text2 = TB2.Text;
                string text3 = TB3.Text;
                string text4 = TB4.Text;

                // Создаем команду для вставки текстов в базу данных
                string SqlInstruction = "INSERT INTO Users (Login, Password, AccountType, PassportNumber)" +
                        "VALUES (@NewLogin, @NewPassword, @NewAccountType, @NewPassportNumber)";
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = dataConnect;
                MySqlCommand cmd = new MySqlCommand(SqlInstruction, conn);

                // Добавляем параметры для текстов
                cmd.Parameters.AddWithValue("@NewLogin", text1);
                cmd.Parameters.AddWithValue("@NewPassword", text2);
                cmd.Parameters.AddWithValue("@NewAccountType", text3);
                cmd.Parameters.AddWithValue("@NewPassportNumber", text4);

                // Открываем подключение к базе данных
                conn.Open();

                // Выполняем команду
                cmd.ExecuteNonQuery();

                // Закрываем подключение к базе данных
                conn.Close();

                MessageBox.Show("Ваш аккаунт успешно создан!");

                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля были заполнены");
            }

        }
    }
}
