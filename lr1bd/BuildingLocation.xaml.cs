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
    /// Логика взаимодействия для BuildingLocation.xaml
    /// </summary>
    
    static class Transfer
    {
        public static float ValueFloat { get; set; }
        public static string ValueString { get; set; }
        public static string ValueString2 { get; set; }
        public static string ValueString3 { get; set; }
        public static string ValueString4 { get; set; }
        public static bool CloseWindowToken { get; set; } = false;

        public static bool CloseWindowChangeRowToken { get; set; } = false;

        public static string CheckChange { get; set; } = "";
    }

    public partial class BuildingLocation : Window
    {
        public BuildingLocation()
        {
            InitializeComponent();
        }

        private void NewLocation_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer.CheckChange == "Create")
            {
                if (TB1.Text.Length != 0 & TB2.Text.Length != 0 & TB3.Text.Length != 0 & (float)Convert.ToDouble(TB4.Text.Length) != 0)
                {
                    // Запоминаем расстояние до центра города
                    Transfer.ValueFloat = (float)Convert.ToDouble(TB4.Text);
                    //Transfer.ValueFloat = TB4.Text;
                    //Запоминаем Район города
                    Transfer.ValueString = TB1.Text;
                    // Запоминаем улицу
                    Transfer.ValueString2 = TB2.Text;
                    // Запоминаем Дом
                    Transfer.ValueString3 = TB3.Text;
                    Transfer.ValueString4 = TB5.Text;
                    // Закрываем форму
                    Transfer.CloseWindowToken = true;
                    this.Close();
                }
            }
        }

        private void TB4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TB3_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Transfer.CheckChange == "Edit")
            {
                // Запоминаем расстояние до центра города
                Transfer.ValueFloat = (float)Convert.ToDouble(TB4.Text);
                //Transfer.ValueFloat = TB4.Text;
                //Запоминаем Район города
                Transfer.ValueString = TB1.Text;
                // Запоминаем улицу
                Transfer.ValueString2 = TB2.Text;
                // Запоминаем Дом
                Transfer.ValueString3 = TB3.Text;
                Transfer.ValueString4 = TB5.Text;

                // Закрываем форму
                Transfer.CloseWindowChangeRowToken = true;
                this.Close();
            }
        }
    }
}
