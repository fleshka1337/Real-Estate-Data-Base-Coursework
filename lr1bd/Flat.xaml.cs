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
    /// Логика взаимодействия для Flat.xaml
    /// </summary>

    static class Transfer4
    {
        public static string ValueString { get; set; }
        public static string ValueString2 { get; set; }
        public static string ValueString3 { get; set; }
        public static string ValueString4 { get; set; }
        public static string ValueString5 { get; set; }
        public static string ValueString6 { get; set; }
        public static string ValueString7 { get; set; }


        public static bool CloseWindowToken { get; set; } = false;

        public static bool CloseWindowChangeRowToken { get; set; } = false;

        public static string CheckChange { get; set; } = "";
    }


    public partial class Flat : Window
    {

        

        public Flat()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewLocation_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer4.CheckChange == "Create")
            {
                if (TB1.Text.Length != 0)
                {
                    Transfer4.ValueString = TB1.Text;
                    // Запоминаем улицу
                    Transfer4.ValueString2 = TB2.Text;
                    Transfer4.ValueString3 = TB3.Text;
                    Transfer4.ValueString4 = TB4.Text;
                    Transfer4.ValueString5 = TB5.Text;
                    Transfer4.ValueString6 = TB6.Text;
                    Transfer4.ValueString7 = TB7.Text;
                    // Закрываем форму
                    Transfer4.CloseWindowToken = true;
                    this.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Transfer4.CheckChange == "Edit")
            {
                Transfer4.ValueString = TB1.Text;
                // Запоминаем улицу
                Transfer4.ValueString2 = TB2.Text;
                Transfer4.ValueString3 = TB3.Text;
                Transfer4.ValueString4 = TB4.Text;
                Transfer4.ValueString5 = TB5.Text;
                Transfer4.ValueString6 = TB6.Text;
                Transfer4.ValueString7 = TB7.Text;
                // Закрываем форму
                Transfer4.CloseWindowToken = true;
                Transfer4.CloseWindowChangeRowToken = true;
                this.Close();
            }
        }
    }
}
