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
    /// Логика взаимодействия для CreateApartment_FromDeveloper.xaml
    /// </summary>
    /// 

    static class Transfer11
    {
        public static string ValueString { get; set; }
        public static string ValueString2 { get; set; }
        public static string ValueString3 { get; set; }
        public static string ValueString4 { get; set; }
        public static string ValueString5 { get; set; }
        public static string ValueString6 { get; set; }
        public static string ValueString7 { get; set; }

        public static string ValueString10 { get; set; }
        public static string ValueString11 { get; set; }
        public static string ValueString12 { get; set; }


        public static string ValueStringKadastr { get; set; }
        public static string ValueStringFlatOrder { get; set; }


        public static bool CloseWindowToken { get; set; } = false;

        public static bool CloseWindowChangeRowToken { get; set; } = false;

        public static string CheckChange { get; set; } = "";
    }

    public partial class CreateApartment_FromDeveloper : Window
    {
        public CreateApartment_FromDeveloper()
        {
            InitializeComponent();

            TB7.Text = Transfer11.ValueStringKadastr;
            TB1.Text = Transfer11.ValueStringFlatOrder;
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
            if (Transfer11.CheckChange == "Create")
            {
                if (TB1.Text.Length != 0)
                {
                    Transfer11.ValueString = TB1.Text;
                    // Запоминаем улицу
                    Transfer11.ValueString2 = TB2.Text;
                    Transfer11.ValueString3 = TB3.Text;
                    
                    // Общая площадь
                    Transfer11.ValueString4 = TB4.Text;

                    Transfer11.ValueString5 = TB5.Text;
                    Transfer11.ValueString6 = TB6.Text;
                    
                    // Кадастр
                    Transfer11.ValueString7 = TB7.Text;

                    Transfer11.ValueString10 = TB10.Text;
                    Transfer11.ValueString11 = TB11.Text;
                    Transfer11.ValueString12 = TB12.Text;

                    // Закрываем форму
                    Transfer11.CloseWindowToken = true;
                    this.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Transfer11.CheckChange == "Edit")
            {
                Transfer11.ValueString = TB1.Text;
                // Запоминаем улицу
                Transfer11.ValueString2 = TB2.Text;
                Transfer11.ValueString3 = TB3.Text;
                Transfer11.ValueString4 = TB4.Text;
                Transfer11.ValueString5 = TB5.Text;
                Transfer11.ValueString6 = TB6.Text;
                Transfer11.ValueString7 = TB7.Text;
                // Закрываем форму
                Transfer11.CloseWindowToken = true;
                Transfer11.CloseWindowChangeRowToken = true;
                this.Close();
            }
        }
    }
}
