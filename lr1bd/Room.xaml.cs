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
    /// Логика взаимодействия для Room.xaml
    /// </summary>

    static class Transfer6
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



        public static bool CloseWindowToken { get; set; } = false;

        public static bool CloseWindowChangeRowToken { get; set; } = false;

        public static string CheckChange { get; set; } = "";
    }

    public partial class Room : Window
    {
        public Room()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewLocation_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer6.CheckChange == "Create")
            {
                if (TB1.Text.Length != 0)
                {
                    Transfer6.ValueString = TB1.Text;
                    // Запоминаем улицу
                    Transfer6.ValueString2 = TB2.Text;
                    Transfer6.ValueString3 = TB3.Text;
                    Transfer6.ValueString4 = TB4.Text;
                    Transfer6.ValueString5 = TB5.Text;
                    Transfer6.ValueString6 = TB6.Text;
                    Transfer6.ValueString7 = TB7.Text;
                    Transfer6.ValueString8 = TB8.Text;
                    Transfer6.ValueString9 = TB9.Text;
                    // Закрываем форму
                    Transfer6.CloseWindowToken = true;
                    this.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Transfer6.CheckChange == "Edit")
            {
                Transfer6.ValueString = TB1.Text;
                // Запоминаем улицу
                Transfer6.ValueString2 = TB2.Text;
                Transfer6.ValueString3 = TB3.Text;
                Transfer6.ValueString4 = TB4.Text;
                Transfer6.ValueString5 = TB5.Text;
                Transfer6.ValueString6 = TB6.Text;
                Transfer6.ValueString7 = TB7.Text;
                Transfer6.ValueString8 = TB8.Text;
                Transfer6.ValueString9 = TB9.Text;
                // Закрываем форму
                Transfer6.CloseWindowToken = true;
                Transfer6.CloseWindowChangeRowToken = true;
                this.Close();
            }
        }
    }
}
