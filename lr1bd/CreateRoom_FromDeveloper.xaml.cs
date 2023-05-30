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
using System.Windows.Shapes;

namespace lr1bd
{
    /// <summary>
    /// Логика взаимодействия для CreateRoom_FromDeveloper.xaml
    /// </summary>

    static class Transfer12
    {
        public static string ValueString { get; set; }
        public static string ValueString2 { get; set; }
        public static string ValueString3 { get; set; }
        public static string ValueString4 { get; set; }
        public static string ValueString5 { get; set; }
        public static string ValueString6 { get; set; }
        public static string ValueString7 { get; set; }
        public static string ValueString8 { get; set; }
        public static string ValueString9 { get; set; }

        public static string ValueStringAPTNumber { get; set; }
        public static string ValueStringROOMNumber { get; set; }

        public static bool CloseWindowToken { get; set; } = false;

        public static bool CloseWindowChangeRowToken { get; set; } = false;

        public static string CheckChange { get; set; } = "";
    }

    public partial class CreateRoom_FromDeveloper : Window
    {
        public CreateRoom_FromDeveloper()
        {
            InitializeComponent();

            TB9.Text = Transfer12.ValueStringAPTNumber;
            TB1.Text = Transfer12.ValueStringROOMNumber;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewLocation_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer12.CheckChange == "Create")
            {
                if (TB1.Text.Length != 0)
                {
                    Transfer12.ValueString = TB1.Text;
                    // Запоминаем улицу
                    Transfer12.ValueString2 = TB2.Text;
                    Transfer12.ValueString3 = TB3.Text;
                    Transfer12.ValueString4 = TB4.Text;
                    Transfer12.ValueString5 = TB5.Text;
                    Transfer12.ValueString6 = TB6.Text;
                    Transfer12.ValueString7 = TB7.Text;
                    Transfer12.ValueString8 = TB8.Text;
                    Transfer12.ValueString9 = TB9.Text;
                    // Закрываем форму
                    Transfer12.CloseWindowToken = true;
                    this.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Transfer12.CheckChange == "Edit")
            {
                Transfer12.ValueString = TB1.Text;
                // Запоминаем улицу
                Transfer12.ValueString2 = TB2.Text;
                Transfer12.ValueString3 = TB3.Text;
                Transfer12.ValueString4 = TB4.Text;
                Transfer12.ValueString5 = TB5.Text;
                Transfer12.ValueString6 = TB6.Text;
                Transfer12.ValueString7 = TB7.Text;
                Transfer12.ValueString8 = TB8.Text;
                Transfer12.ValueString9 = TB9.Text;
                // Закрываем форму
                Transfer12.CloseWindowToken = true;
                Transfer12.CloseWindowChangeRowToken = true;
                this.Close();
            }
        }
    }
}
