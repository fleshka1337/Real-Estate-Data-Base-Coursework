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
    /// Логика взаимодействия для Building_Material.xaml
    /// </summary>

    static class Transfer3
    {
        public static string ValueString { get; set; }
        public static string ValueString2 { get; set; }

        public static bool CloseWindowToken { get; set; } = false;
        public static bool CloseWindowChangeRowToken { get; set; } = false;

        public static string CheckChange { get; set; } = "";
    }
    public partial class Building_Material : Window
    {
        public Building_Material()
        {
            InitializeComponent();
        }

        private void NewLocation_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer3.CheckChange == "Create")
            {
                if (TB1.Text.Length != 0)
                {
                    Transfer3.ValueString = TB1.Text;
                    // Запоминаем улицу
                    Transfer3.ValueString2 = TB2.Text;

                    // Закрываем форму
                    Transfer3.CloseWindowToken = true;
                    this.Close();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Transfer3.CheckChange == "Edit")
            {
                Transfer3.ValueString = TB1.Text;
                // Запоминаем улицу
                Transfer3.ValueString2 = TB2.Text;

                // Закрываем форму
                Transfer3.CloseWindowToken = true;
                Transfer3.CloseWindowChangeRowToken = true;
                this.Close();
            }
        }
    }
}
