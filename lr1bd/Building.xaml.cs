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
    /// Логика взаимодействия для Building.xaml
    /// </summary>
    static class Transfer2
    {
        public static float ValueFloat { get; set; }
        public static string ValueString { get; set; }
        public static string ValueString2 { get; set; }
        public static string ValueString3 { get; set; }
        public static string ValueString4 { get; set; }
        public static string ValueString5 { get; set; }
        public static string ValueString6 { get; set; }
        public static string ValueString7 { get; set; }
        public static string ValueString8 { get; set; }
        public static string ValueString9 { get; set; }
        public static string ValueString10 { get; set; }
        public static string ValueString11 { get; set; }
        public static string ValueString12 { get; set; }

        public static string ValueString13 { get; set; }
        public static string ValueString14 { get; set; }

        public static bool CloseWindowToken { get; set; } = false;

        public static bool CloseWindowChangeRowToken { get; set; } = false;

        public static string CheckChange { get; set; } = "";
    }

    public partial class Building : Window
    {
        public Building()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewLocation_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer2.CheckChange == "Create")
            {
                if (TB4.Text.Length != 0 & TB2.Text.Length != 0 & TB3.Text.Length != 0 & (float)Convert.ToDouble(TB1.Text.Length) != 0)
                {
                    // Запоминаем расстояние до центра города
                    Transfer2.ValueFloat = (float)Convert.ToDouble(TB1.Text);
                    //Transfer.ValueFloat = TB4.Text;
                    //Запоминаем Район города
                    Transfer2.ValueString = TB2.Text;
                    // Запоминаем улицу
                    Transfer2.ValueString2 = TB3.Text;
                    // Запоминаем Дом
                    Transfer2.ValueString3 = TB4.Text;
                    Transfer2.ValueString4 = TB5.Text;
                    Transfer2.ValueString5 = TB6.Text;
                    Transfer2.ValueString6 = TB7.Text;
                    Transfer2.ValueString7 = TB8.Text;
                    Transfer2.ValueString8 = TB9.Text;
                    Transfer2.ValueString9 = TB10.Text;
                    Transfer2.ValueString10 = TB11.Text;
                    Transfer2.ValueString11 = TB12.Text;
                    Transfer2.ValueString12 = TB13.Text;

                    // Закрываем форму
                    Transfer2.CloseWindowToken = true;
                    this.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Transfer2.CheckChange == "Edit")
            {
                // Запоминаем расстояние до центра города
                Transfer2.ValueFloat = (float)Convert.ToDouble(TB1.Text);
                //Transfer.ValueFloat = TB4.Text;
                //Запоминаем Район города
                Transfer2.ValueString = TB2.Text;
                // Запоминаем улицу
                Transfer2.ValueString2 = TB3.Text;
                // Запоминаем Дом
                Transfer2.ValueString3 = TB4.Text;
                Transfer2.ValueString4 = TB5.Text;
                Transfer2.ValueString5 = TB6.Text;
                Transfer2.ValueString6 = TB7.Text;
                Transfer2.ValueString7 = TB8.Text;
                Transfer2.ValueString8 = TB9.Text;
                Transfer2.ValueString9 = TB10.Text;
                Transfer2.ValueString10 = TB11.Text;
                Transfer2.ValueString11 = TB12.Text;
                Transfer2.ValueString12 = TB13.Text;

                // Закрываем форму
                Transfer2.CloseWindowToken = true;
                Transfer2.CloseWindowChangeRowToken = true;
                this.Close();
            }
        }
    }
}
