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
    /// Логика взаимодействия для CreateBuilding_FromDeveloper.xaml
    /// </summary>
    static class Transfer10
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

        public static string ValueString22 { get; set; }

        public static string ValueString23 { get; set; }
        
        public static string ValueString24 { get; set; }

        public static bool CloseWindowToken { get; set; } = false;

        public static bool CloseWindowChangeRowToken { get; set; } = false;

        public static string CheckChange { get; set; } = "";
    }

    public partial class CreateBuilding_FromDeveloper : Window
    {
        public CreateBuilding_FromDeveloper()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewLocation_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer10.CheckChange == "Create")
            {
                if (TB4.Text.Length != 0 & TB2.Text.Length != 0 & TB3.Text.Length != 0 & (float)Convert.ToDouble(TB1.Text.Length) != 0)
                {
                    // kadastr
                    Transfer10.ValueFloat = (float)Convert.ToDouble(TB1.Text);
                    //Transfer.ValueFloat = TB4.Text;
                    
                    //Запоминаем Район города
                    Transfer10.ValueString = TB2.Text;
                    
                    // Запоминаем улицу
                    Transfer10.ValueString2 = TB3.Text;

                    // building_material
                    Transfer10.ValueString3 = TB4.Text;

                    Transfer10.ValueString4 = TB5.Text;
                    Transfer10.ValueString5 = TB6.Text;
                    Transfer10.ValueString6 = TB7.Text;
                    Transfer10.ValueString7 = TB8.Text;
                    Transfer10.ValueString8 = TB9.Text;
                    Transfer10.ValueString9 = TB10.Text;
                    Transfer10.ValueString10 = TB11.Text;
                    Transfer10.ValueString11 = TB12.Text;
                    
                    //unique_order_number ПОРЯДКОЙВЫЙ НОМЕР В ДОКУМЕНТАХ
                    Transfer10.ValueString12 = TB13.Text;

                    Transfer10.ValueString22 = TB22.Text;
                    Transfer10.ValueString23 = TB23.Text;
                    Transfer10.ValueString24 = TB24.Text;

                    // Закрываем форму
                    Transfer10.CloseWindowToken = true;
                    this.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Transfer10.CheckChange == "Edit")
            {
                // Запоминаем расстояние до центра города
                Transfer10.ValueFloat = (float)Convert.ToDouble(TB1.Text);
                //Transfer.ValueFloat = TB4.Text;
                //Запоминаем Район города
                Transfer10.ValueString = TB2.Text;
                // Запоминаем улицу
                Transfer10.ValueString2 = TB3.Text;
                // Запоминаем Дом
                Transfer10.ValueString3 = TB4.Text;
                Transfer10.ValueString4 = TB5.Text;
                Transfer10.ValueString5 = TB6.Text;
                Transfer10.ValueString6 = TB7.Text;
                Transfer10.ValueString7 = TB8.Text;
                Transfer10.ValueString8 = TB9.Text;
                Transfer10.ValueString9 = TB10.Text;
                Transfer10.ValueString10 = TB11.Text;
                Transfer10.ValueString11 = TB12.Text;
                Transfer10.ValueString12 = TB13.Text;

                // Закрываем форму
                Transfer10.CloseWindowToken = true;
                Transfer10.CloseWindowChangeRowToken = true;
                this.Close();
            }
        }
    }
}
