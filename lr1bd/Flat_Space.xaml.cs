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
    /// Логика взаимодействия для Flat_Space.xaml
    /// </summary>

    static class Transfer5
    {
        public static string ValueString { get; set; }
        public static string ValueString2 { get; set; }
        public static string ValueString3 { get; set; }
        public static string ValueString4 { get; set; }

        public static int ValueInt { get; set; }   


        public static bool CloseWindowToken { get; set; } = false;

        public static bool CloseWindowChangeRowToken { get; set; } = false;

        public static string CheckChange { get; set; } = "";
    }

    public partial class Flat_Space : Window
    {
        public Flat_Space()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewLocation_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer5.CheckChange == "Create")
            {
                if (TB1.Text.Length != 0)
                {
                    Transfer5.ValueString = TB1.Text;
                    //Transfer5.ValueInt = Convert.ToInt32(TB1.Text);
                    // Запоминаем улицу
                    Transfer5.ValueString2 = TB2.Text;
                    Transfer5.ValueString3 = TB3.Text;
                    Transfer5.ValueString4 = TB4.Text;

                    // Закрываем форму
                    Transfer5.CloseWindowToken = true;
                    this.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Transfer5.CheckChange == "Edit")
            {
                Transfer5.ValueString = TB1.Text;
                Transfer5.ValueString2 = TB2.Text;
                Transfer5.ValueString3 = TB3.Text;
                Transfer5.ValueString4 = TB4.Text;

                // Закрываем форму
                Transfer5.CloseWindowChangeRowToken = true;
                this.Close();
            }
        }
    }
}
