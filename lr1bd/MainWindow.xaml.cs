using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Windows.Data;
using MySqlX.XDevAPI.Relational;

namespace lr1bd
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private readonly string dataConnect = "server=localhost; user=root; database=mydb;port=3306;password=root";

        int MyRowCount;
        DataTable HelpTable;

        int columnNumber = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            rbEqual.IsChecked = true;
        }

        private void MakeColumnNameList(DataTable HelpTable)
        {
            TableList.Items.Clear();
            foreach (DataColumn HelpColumn in HelpTable.Columns)
                TableList.Items.Add(HelpColumn.ColumnName);
        }

        //Метод, записывающий в массив типы данных столбцов отображаемой таблицы
        private void GetColumnDataType(DataTable HelpTable, ref string[] HelpColumnType)
        {
            // Переменная счетчик
            int j;
            //Цикл по столбцам загруженной таблицы
            foreach (DataColumn HelpColumn in HelpTable.Columns)
            {
                // Получение номера столбца(начиная с нуля)
                j = HelpColumn.Ordinal;
                // Заполнение массива названиями типов данных столбцов таблицы
                HelpColumnType[j] = HelpColumn.DataType.ToString();
            }
        }

        private void WhatsRB_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton item)
            {
                Transfer.ValueString = item.Name;
            }
        }

        private void Search(string FiltrColumnName, string FiltrValue)
        {
            DataTable FiltrTable;
            string Filtr = "";

                switch (Transfer.ValueString) 
                {
                    case "rbEqual":
                        Filtr = FiltrColumnName + "='" + FiltrValue + "'";
                        break;
                    case "rbContain":
                        Filtr = FiltrColumnName + " LIKE '%" + FiltrValue + "%'";
                        break;
                    case "rbBegin":
                        Filtr = FiltrColumnName + " LIKE '" + FiltrValue + "%'";
                        break;
                    case "rbMore":
                        Filtr = FiltrColumnName + ">'" + FiltrValue + "'";
                        break;
                    case "rbMoreEqual":
                        Filtr = FiltrColumnName + ">='" + FiltrValue + "'";
                        break;
                    case "rbLess":
                        Filtr = FiltrColumnName + "<'" + FiltrValue + "'";
                        break;
                    case "rbLessEqual":
                        Filtr = FiltrColumnName + "<='" + FiltrValue + "'";
                        break;
                }

                switch (Transfer2.ValueString)
                {
                    case "rbEqual":
                        Filtr = FiltrColumnName + "='" + FiltrValue + "'";
                        break;
                    case "rbContain":
                        Filtr = FiltrColumnName + " LIKE '%" + FiltrValue + "%'";
                        break;
                    case "rbBegin":
                        Filtr = FiltrColumnName + " LIKE '" + FiltrValue + "%'";
                        break;
                    case "rbMore":
                        Filtr = FiltrColumnName + ">'" + FiltrValue + "'";
                        break;
                    case "rbMoreEqual":
                        Filtr = FiltrColumnName + ">='" + FiltrValue + "'";
                        break;
                    case "rbLess":
                        Filtr = FiltrColumnName + "<'" + FiltrValue + "'";
                        break;
                    case "rbLessEqual":
                        Filtr = FiltrColumnName + "<='" + FiltrValue + "'";
                        break;
                }

                switch (Transfer3.ValueString)
                {
                    case "rbEqual":
                        Filtr = FiltrColumnName + "='" + FiltrValue + "'";
                        break;
                    case "rbContain":
                        Filtr = FiltrColumnName + " LIKE '%" + FiltrValue + "%'";
                        break;
                    case "rbBegin":
                        Filtr = FiltrColumnName + " LIKE '" + FiltrValue + "%'";
                        break;
                    case "rbMore":
                        Filtr = FiltrColumnName + ">'" + FiltrValue + "'";
                        break;
                    case "rbMoreEqual":
                        Filtr = FiltrColumnName + ">='" + FiltrValue + "'";
                        break;
                    case "rbLess":
                        Filtr = FiltrColumnName + "<'" + FiltrValue + "'";
                        break;
                    case "rbLessEqual":
                        Filtr = FiltrColumnName + "<='" + FiltrValue + "'";
                        break;
                }

                switch (Transfer4.ValueString)
                {
                    case "rbEqual":
                        Filtr = FiltrColumnName + "='" + FiltrValue + "'";
                        break;
                    case "rbContain":
                        Filtr = FiltrColumnName + " LIKE '%" + FiltrValue + "%'";
                        break;
                    case "rbBegin":
                        Filtr = FiltrColumnName + " LIKE '" + FiltrValue + "%'";
                        break;
                    case "rbMore":
                        Filtr = FiltrColumnName + ">'" + FiltrValue + "'";
                        break;
                    case "rbMoreEqual":
                        Filtr = FiltrColumnName + ">='" + FiltrValue + "'";
                        break;
                    case "rbLess":
                        Filtr = FiltrColumnName + "<'" + FiltrValue + "'";
                        break;
                    case "rbLessEqual":
                        Filtr = FiltrColumnName + "<='" + FiltrValue + "'";
                        break;
                }

                switch (Transfer5.ValueString)
                {
                    case "rbEqual":
                        Filtr = FiltrColumnName + "='" + FiltrValue + "'";
                        break;
                    case "rbContain":
                        Filtr = FiltrColumnName + " LIKE '%" + FiltrValue + "%'";
                        break;
                    case "rbBegin":
                        Filtr = FiltrColumnName + " LIKE '" + FiltrValue + "%'";
                        break;
                    case "rbMore":
                        Filtr = FiltrColumnName + ">'" + FiltrValue + "'";
                        break;
                    case "rbMoreEqual":
                        Filtr = FiltrColumnName + ">='" + FiltrValue + "'";
                        break;
                    case "rbLess":
                        Filtr = FiltrColumnName + "<'" + FiltrValue + "'";
                        break;
                    case "rbLessEqual":
                        Filtr = FiltrColumnName + "<='" + FiltrValue + "'";
                        break;
                }

                switch (Transfer6.ValueString)
                {
                    case "rbEqual":
                        Filtr = FiltrColumnName + "='" + FiltrValue + "'";
                        break;
                    case "rbContain":
                        Filtr = FiltrColumnName + " LIKE '%" + FiltrValue + "%'";
                        break;
                    case "rbBegin":
                        Filtr = FiltrColumnName + " LIKE '" + FiltrValue + "%'";
                        break;
                    case "rbMore":
                        Filtr = FiltrColumnName + ">'" + FiltrValue + "'";
                        break;
                    case "rbMoreEqual":
                        Filtr = FiltrColumnName + ">='" + FiltrValue + "'";
                        break;
                    case "rbLess":
                        Filtr = FiltrColumnName + "<'" + FiltrValue + "'";
                        break;
                    case "rbLessEqual":
                        Filtr = FiltrColumnName + "<='" + FiltrValue + "'";
                        break;
                }

            DataRow[] HelpDataRows = HelpTable.Select(Filtr);
            FiltrTable = HelpTable.Clone();
            for (int i = 0; i < HelpDataRows.Length; i++)
            {
                FiltrTable.ImportRow(HelpDataRows[i]);
                DG1.DataContext = FiltrTable;
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DG1.DataContext = null;
                // Выбираем таблицу building_location
                string SqlQwery = "Select * from building_location";
                //Создаем объект MySqlDataAdapter
                MySqlDataAdapter adapter = new MySqlDataAdapter(SqlQwery, dataConnect);
                // Создаем объект Dataset
                DataSet ds = new DataSet("NameOfDB");
                // Заполняем созданный объект Dataset новой таблицей
                adapter.Fill(ds);
                // Выводим данные в элемент DataGrid
                DG1.DataContext = ds.Tables[0];

                MakeColumnNameList(ds.Tables[0]);
                HelpTable = ds.Tables[0];
                columnNumber = 1;
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                DG1.DataContext = null;
                // Выбираем таблицу building_location
                string SqlQwery = "Select * from building";
                //Создаем объект MySqlDataAdapter
                MySqlDataAdapter adapter = new MySqlDataAdapter(SqlQwery, dataConnect);
                // Создаем объект Dataset
                DataSet ds = new DataSet("NameOfDB");
                // Заполняем созданный объект Dataset новой таблицей
                adapter.Fill(ds);
                // Выводим данные в элемент DataGrid
                DG1.DataContext = ds.Tables[0];

                MakeColumnNameList(ds.Tables[0]);
                HelpTable = ds.Tables[0];

                columnNumber = 2;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                DG1.DataContext = null;
                // Выбираем таблицу building_location
                string SqlQwery = "Select * from Building_material";
                //Создаем объект MySqlDataAdapter
                MySqlDataAdapter adapter = new MySqlDataAdapter(SqlQwery, dataConnect);
                // Создаем объект Dataset
                DataSet ds = new DataSet("NameOfDB");
                // Заполняем созданный объект Dataset новой таблицей
                adapter.Fill(ds);
                // Выводим данные в элемент DataGrid
                DG1.DataContext = ds.Tables[0];

                MakeColumnNameList(ds.Tables[0]);
                HelpTable = ds.Tables[0];

                columnNumber = 3;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                DG1.DataContext = null;
                // Выбираем таблицу building_location
                string SqlQwery = "Select * from Flat";
                //Создаем объект MySqlDataAdapter
                MySqlDataAdapter adapter = new MySqlDataAdapter(SqlQwery, dataConnect);
                // Создаем объект Dataset
                DataSet ds = new DataSet("NameOfDB");
                // Заполняем созданный объект Dataset новой таблицей
                adapter.Fill(ds);
                // Выводим данные в элемент DataGrid
                DG1.DataContext = ds.Tables[0];

                MakeColumnNameList(ds.Tables[0]);
                HelpTable = ds.Tables[0];

                columnNumber = 4;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                DG1.DataContext = null;
                // Выбираем таблицу building_location
                string SqlQwery = "Select * from Flat_spcae";
                //Создаем объект MySqlDataAdapter
                MySqlDataAdapter adapter = new MySqlDataAdapter(SqlQwery, dataConnect);
                // Создаем объект Dataset
                DataSet ds = new DataSet("NameOfDB");
                // Заполняем созданный объект Dataset новой таблицей
                adapter.Fill(ds);
                // Выводим данные в элемент DataGrid
                DG1.DataContext = ds.Tables[0];

                MakeColumnNameList(ds.Tables[0]);
                HelpTable = ds.Tables[0];

                columnNumber = 5;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                DG1.DataContext = null;
                // Выбираем таблицу building_location
                string SqlQwery = "Select * from Room";
                //Создаем объект MySqlDataAdapter
                MySqlDataAdapter adapter = new MySqlDataAdapter(SqlQwery, dataConnect);
                // Создаем объект Dataset
                DataSet ds = new DataSet("NameOfDB");
                // Заполняем созданный объект Dataset новой таблицей
                adapter.Fill(ds);
                // Выводим данные в элемент DataGrid
                DG1.DataContext = ds.Tables[0];


                MakeColumnNameList(ds.Tables[0]);
                HelpTable = ds.Tables[0];

                columnNumber = 6;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        { 
                // Создание экземпляра класса BuildingLocation 
                BuildingLocation buildingLocation = new BuildingLocation();
                // Отображение созданного окна
                Transfer.CheckChange = "Create";
                buildingLocation.ShowDialog();

                if (Transfer.CloseWindowToken == true) {

                String sql = "Select * from building_location";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                DataSet ds = new DataSet("NameOfDB");
                adapter.Fill(ds);  

                // Создание новой пустой строки в единственной таблице объекта ds типа DataSet с той же схемой, что сама таблица
                var MyNewRow = ds.Tables[0].NewRow();

                MyNewRow[0] = Transfer.ValueString;
                MyNewRow[1] = Transfer.ValueString2;
                MyNewRow[2] = Transfer.ValueString3;
                MyNewRow[3] = Transfer.ValueFloat;
                MyNewRow[4] = Transfer.ValueString4;

                ds.Tables[0].Rows.Add(MyNewRow);

                DG1.DataContext = ds.Tables[0];

                //Создание объекта My типа MySqlCommandBuilder
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                //Задание свойства InsertCommand с помощью метода GetInsertCommand()
                adapter.InsertCommand = My.GetInsertCommand();
                //Вызов метода Update для вставки новой строки в базу данных 
                adapter.Update(ds.Tables[0]);
            }

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра класса BuildingLocation 
            Room room = new Room();
            Transfer6.CheckChange = "Create";
            // Отображение созданного окна
            room.ShowDialog();

            if (Transfer6.CloseWindowToken == true)
            {

                String sql = "Select * from Room";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                DataSet ds = new DataSet("NameOfDB");
                adapter.Fill(ds);

                // Создание новой пустой строки в единственной таблице объекта ds типа DataSet с той же схемой, что сама таблица
                var MyNewRow = ds.Tables[0].NewRow();

                MyNewRow[0] = Transfer6.ValueString;
                MyNewRow[1] = Transfer6.ValueString2;
                MyNewRow[2] = Transfer6.ValueString3;
                MyNewRow[3] = Transfer6.ValueString4;
                MyNewRow[4] = Transfer6.ValueString5;
                MyNewRow[5] = Transfer6.ValueString6;
                MyNewRow[6] = Transfer6.ValueString7;
                MyNewRow[7] = Transfer6.ValueString8;
                MyNewRow[8] = Transfer6.ValueString9;

                ds.Tables[0].Rows.Add(MyNewRow);

                DG1.DataContext = ds.Tables[0];

                //Создание объекта My типа MySqlCommandBuilder
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                //Задание свойства InsertCommand с помощью метода GetInsertCommand()
                adapter.InsertCommand = My.GetInsertCommand();
                //Вызов метода Update для вставки новой строки в базу данных 
                adapter.Update(ds.Tables[0]);
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра класса BuildingLocation 
            Building building = new Building();
            Transfer2.CheckChange = "Create";
            // Отображение созданного окна
            building.ShowDialog();

            if (Transfer2.CloseWindowToken == true)
            {

                String sql = "Select * from building";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                DataSet ds = new DataSet("NameOfDB");
                adapter.Fill(ds);

                // Создание новой пустой строки в единственной таблице объекта ds типа DataSet с той же схемой, что сама таблица
                var MyNewRow = ds.Tables[0].NewRow();

                MyNewRow[0] = Transfer2.ValueFloat;
                MyNewRow[1] = Transfer2.ValueString;
                MyNewRow[2] = Transfer2.ValueString2;
                MyNewRow[3] = Transfer2.ValueString3;
                MyNewRow[4] = Transfer2.ValueString4;
                MyNewRow[5] = Transfer2.ValueString5;
                MyNewRow[6] = Transfer2.ValueString6;
                MyNewRow[7] = Transfer2.ValueString7;
                MyNewRow[8] = Transfer2.ValueString8;
                MyNewRow[9] = Transfer2.ValueString9;
                MyNewRow[10] = Transfer2.ValueString10;
                MyNewRow[11] = Transfer2.ValueString11;
                MyNewRow[12] = Transfer2.ValueString12;

                ds.Tables[0].Rows.Add(MyNewRow);

                DG1.DataContext = ds.Tables[0];

                //Создание объекта My типа MySqlCommandBuilder
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                //Задание свойства InsertCommand с помощью метода GetInsertCommand()
                adapter.InsertCommand = My.GetInsertCommand();
                //Вызов метода Update для вставки новой строки в базу данных 
                adapter.Update(ds.Tables[0]);
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра класса BuildingLocation 
            Building_Material building_material = new Building_Material();
            // Отображение созданного окна
            Transfer3.CheckChange = "Create";
            building_material.ShowDialog();
            if (Transfer3.CloseWindowToken == true)
            {

                String sql = "Select * from Building_material";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                DataSet ds = new DataSet("NameOfDB");
                adapter.Fill(ds);

                // Создание новой пустой строки в единственной таблице объекта ds типа DataSet с той же схемой, что сама таблица
                var MyNewRow = ds.Tables[0].NewRow();

                MyNewRow[0] = Transfer3.ValueString;
                MyNewRow[1] = Transfer3.ValueString2;


                ds.Tables[0].Rows.Add(MyNewRow);

                DG1.DataContext = ds.Tables[0];

                //Создание объекта My типа MySqlCommandBuilder
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                //Задание свойства InsertCommand с помощью метода GetInsertCommand()
                adapter.InsertCommand = My.GetInsertCommand();
                //Вызов метода Update для вставки новой строки в базу данных 
                adapter.Update(ds.Tables[0]);
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра класса BuildingLocation 
            Flat flat = new Flat();
            // Отображение созданного окна
            Transfer4.CheckChange = "Create";
            flat.ShowDialog();
            if (Transfer4.CloseWindowToken == true)
            {

                String sql = "Select * from Flat";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                DataSet ds = new DataSet("NameOfDB");
                adapter.Fill(ds);

                // Создание новой пустой строки в единственной таблице объекта ds типа DataSet с той же схемой, что сама таблица
                var MyNewRow = ds.Tables[0].NewRow();

                MyNewRow[0] = Transfer4.ValueString;
                MyNewRow[1] = Transfer4.ValueString2;
                MyNewRow[2] = Transfer4.ValueString3;
                MyNewRow[3] = Transfer4.ValueString4;
                MyNewRow[4] = Transfer4.ValueString5;
                MyNewRow[5] = Transfer4.ValueString6;
                MyNewRow[6] = Transfer4.ValueString7;


                ds.Tables[0].Rows.Add(MyNewRow);

                DG1.DataContext = ds.Tables[0];

                //Создание объекта My типа MySqlCommandBuilder
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                //Задание свойства InsertCommand с помощью метода GetInsertCommand()
                adapter.InsertCommand = My.GetInsertCommand();
                //Вызов метода Update для вставки новой строки в базу данных 
                adapter.Update(ds.Tables[0]);
            }
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра класса BuildingLocation 
            Flat_Space flat_space = new Flat_Space();
            // Отображение созданного окна
            Transfer5.CheckChange = "Create";
            flat_space.ShowDialog();
            if (Transfer5.CloseWindowToken == true)
            {

                String sql = "Select * from Flat_spcae";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                DataSet ds = new DataSet("NameOfDB");
                adapter.Fill(ds);

                // Создание новой пустой строки в единственной таблице объекта ds типа DataSet с той же схемой, что сама таблица
                var MyNewRow = ds.Tables[0].NewRow();

                MyNewRow[0] = Transfer5.ValueString;
                //MyNewRow[0] = Transfer5.ValueInt;
                MyNewRow[1] = Transfer5.ValueString2;
                MyNewRow[2] = Transfer5.ValueString3;
                MyNewRow[3] = Transfer5.ValueString4;


                ds.Tables[0].Rows.Add(MyNewRow);

                DG1.DataContext = ds.Tables[0];

                //Создание объекта My типа MySqlCommandBuilder
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                //Задание свойства InsertCommand с помощью метода GetInsertCommand()
                adapter.InsertCommand = My.GetInsertCommand();
                //Вызов метода Update для вставки новой строки в базу данных 
                adapter.Update(ds.Tables[0]);
            }
        }

        private void Delete_Row1_Click(object sender, RoutedEventArgs e)
        {
            int index;
            String sql = "select * from building_location";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
            DataSet ds = new DataSet("NameOfDB");
            adapter.Fill(ds);
            index = DG1.SelectedIndex;
            if (DG1.SelectedCells.Count>0) { 
                ds.Tables[0].Rows[index].Delete();
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                adapter.DeleteCommand = My.GetDeleteCommand();
                adapter.Update(ds.Tables[0]);
                ds.Tables[0].AcceptChanges();
                DG1.DataContext = ds.Tables[0];
            }
        }

        private void Delete_Row2_Click(object sender, RoutedEventArgs e)
        {
            int index;
            String sql = "select * from building";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
            DataSet ds = new DataSet("NameOfDB");
            adapter.Fill(ds);
            index = DG1.SelectedIndex;
            if (DG1.SelectedCells.Count > 0)
            {
                ds.Tables[0].Rows[index].Delete();
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                adapter.DeleteCommand = My.GetDeleteCommand();
                adapter.Update(ds.Tables[0]);
                ds.Tables[0].AcceptChanges();
                DG1.DataContext = ds.Tables[0];
            }
        }

        private void Delete_Row3_Click(object sender, RoutedEventArgs e)
        {
            int index;
            String sql = "select * from Building_material";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
            DataSet ds = new DataSet("NameOfDB");
            adapter.Fill(ds);
            index = DG1.SelectedIndex;
            if (DG1.SelectedCells.Count > 0)
            {
                ds.Tables[0].Rows[index].Delete();
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                adapter.DeleteCommand = My.GetDeleteCommand();
                adapter.Update(ds.Tables[0]);
                ds.Tables[0].AcceptChanges();
                DG1.DataContext = ds.Tables[0];
            }
        }

        private void Delete_Row4_Click(object sender, RoutedEventArgs e)
        {
            int index;
            String sql = "select * from Flat";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
            DataSet ds = new DataSet("NameOfDB");
            adapter.Fill(ds);
            index = DG1.SelectedIndex;
            if (DG1.SelectedCells.Count > 0)
            {
                ds.Tables[0].Rows[index].Delete();
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                adapter.DeleteCommand = My.GetDeleteCommand();
                adapter.Update(ds.Tables[0]);
                ds.Tables[0].AcceptChanges();
                DG1.DataContext = ds.Tables[0];
            }
        }

        private void Delete_Row5_Click(object sender, RoutedEventArgs e)
        {
            int index;
            String sql = "Select * from Flat_spcae";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
            DataSet ds = new DataSet("NameOfDB");
            adapter.Fill(ds);
            index = DG1.SelectedIndex;
            if (DG1.SelectedCells.Count > 0)
            {
                ds.Tables[0].Rows[index].Delete();
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                adapter.DeleteCommand = My.GetDeleteCommand();
                adapter.Update(ds.Tables[0]);
                ds.Tables[0].AcceptChanges();
                DG1.DataContext = ds.Tables[0];
            }
        }

        private void Delete_Row6_Click(object sender, RoutedEventArgs e)
        {
            int index;
            String sql = "select * from Room";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);
            DataSet ds = new DataSet("NameOfDB");
            adapter.Fill(ds);
            index = DG1.SelectedIndex;
            if (DG1.SelectedCells.Count > 0)
            {
                ds.Tables[0].Rows[index].Delete();
                MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                adapter.DeleteCommand = My.GetDeleteCommand();
                adapter.Update(ds.Tables[0]);
                ds.Tables[0].AcceptChanges();
                DG1.DataContext = ds.Tables[0];
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DataTable FiltrTable;
            string FiltrValue;
            string FiltrColumnName;
            string Filtr;

            string[] ColumnType = new string[TableList.Items.Count];

            if (SearchCondition.Text == string.Empty)
            {
                FiltrValue = string.Empty;
                MessageBox.Show("Не введено условие для поиска!");
            }
            else
            {
                FiltrValue = SearchCondition.Text;
                if (TableList.SelectedItems.Count == 0)
                {
                    FiltrColumnName = null;
                    MessageBox.Show("Не выбрано имя столбца для поиска!");
                }
                else
                {
                    FiltrColumnName = TableList.SelectedItem.ToString();
                    GetColumnDataType(HelpTable, ref ColumnType);


                    /*                    Filtr = FiltrColumnName + "='" + FiltrValue + "'";
                                        DataRow[] HelpDataRows = HelpTable.Select(Filtr);
                                        FiltrTable = HelpTable.Clone();
                                        for (int i = 0; i < HelpDataRows.Length; i++)
                                        {
                                            FiltrTable.ImportRow(HelpDataRows[i]);
                                        }
                                        DG1.DataContext = FiltrTable;*/

                    switch(ColumnType[TableList.SelectedIndex])
                    {
                        case "System.Date":
                            DateTime result_date;
                            bool success_data = DateTime.TryParse(FiltrValue, out result_date);

                            if (success_data)
                            {
                                Search(FiltrColumnName, FiltrValue);
                            }
                            else
                            {
                                MessageBox.Show("Введенное вами значение не является датой!");
                            }

                            break;

                        case "System.UInt16":
                            Int16 result_int;
                            bool success_int = Int16.TryParse(FiltrValue, out result_int);

                            if (success_int)
                            {
                                Search(FiltrColumnName, FiltrValue);
                            }
                            else
                            {
                                MessageBox.Show("Введенное вами значение не является числом!");
                            }

                            break;

                        case "System.UInt32":
                            Int32 result_int32;
                            bool success_int32 = Int32.TryParse(FiltrValue, out result_int32);

                            if (success_int32)
                            {
                                Search(FiltrColumnName, FiltrValue);
                            }
                            else
                            {
                                MessageBox.Show("Введенное вами значение не является числом!");
                            }

                            break;

                        case "System.UInt64":
                            Int64 result_int64;
                            bool success_int64 = Int64.TryParse(FiltrValue, out result_int64);

                            if (success_int64)
                            {
                                Search(FiltrColumnName, FiltrValue);
                            }
                            else
                            {
                                MessageBox.Show("Введенное вами значение не является числом!");
                            }

                            break;

                        case "System.Int64":
                            Int64 result_1int64;
                            bool success_1int64 = Int64.TryParse(FiltrValue, out result_1int64);

                            if (success_1int64)
                            {
                                Search(FiltrColumnName, FiltrValue);
                            }
                            else
                            {
                                MessageBox.Show("Введенное вами значение не является числом!");
                            }

                            break;

                        case "System.Int32":
                            Int32 result_1int32;
                            bool success_1int32 = Int32.TryParse(FiltrValue, out result_1int32);

                            if (success_1int32)
                            {
                                Search(FiltrColumnName, FiltrValue);
                            }
                            else
                            {
                                MessageBox.Show("Введенное вами значение не является числом!");
                            }

                            break;

                        case "System.Int16":
                            Int16 result_1int;
                            bool success_1int = Int16.TryParse(FiltrValue, out result_1int);

                            if (success_1int)
                            {
                                Search(FiltrColumnName, FiltrValue);
                            }
                            else
                            {
                                MessageBox.Show("Введенное вами значение не является числом!");
                            }

                            break;

                        case "System.Double":
                            Double result_double;
                            bool success_double = Double.TryParse(FiltrValue, out result_double);

                            if (success_double)
                            {
                                Search(FiltrColumnName, FiltrValue);
                            }
                            else
                            {
                                MessageBox.Show("Введенное вами значение не является числом!");
                            }

                            break;

                        case "System.String":
                            Search(FiltrColumnName, FiltrValue);
                            break;
                    }

                }
            }
        }

        private void SearchReset_Click(object sender, RoutedEventArgs e)
        {
            DG1.DataContext = HelpTable;
        }

        private void update_Button5_Click(object sender, RoutedEventArgs e)
        {
            if (DG1.SelectedCells.Count > 0)
            {
                // Создание экземпляра класса Flat_Space
                Flat_Space flat_space = new Flat_Space();
                // Отображение созданного окна
                Transfer5.CheckChange = "Edit";
                flat_space.ShowDialog();
                if (Transfer5.CloseWindowChangeRowToken == true)
                {

                    String sql = "Select * from Flat_spcae";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    //DataSet ds = new DataSet("NameOfDB");
                    DataTable table = new DataTable();
                    //adapter.Fill(ds);
                    adapter.Fill(table);
                    //DG1.ItemsSource = table.DefaultView;

                    DataRowView rowView = DG1.SelectedItem as DataRowView;

                    // Задаем индекс строки, которую хотим обновить
                    int index = DG1.SelectedIndex;

                    // Получаем новое значение Name из строки
                    //string newName = (string)rowView["Name"];

                    // Находим соответствующую строку в таблице по индексу
                    DataRow row = table.Rows[index];

                    row["total_space"] = Transfer5.ValueString;
                    row["living_space"] = Transfer5.ValueString2;
                    row["help_square"] = Transfer5.ValueString3;
                    row["balcony_square"] = Transfer5.ValueString4;

                    // Сохраняем изменения в базе данных с помощью адаптера
                    //adapter.Update(table);
                    //DG1.DataContext = ds.Tables[0];
                    
                    //MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                    //adapter.DeleteCommand = My.GetDeleteCommand();
                    adapter.Update(table);
                    table.AcceptChanges();
                    DG1.DataContext = table;

                    //adapter.Update(ds.Tables[0]);
                    //ds.Tables[0].AcceptChanges();
                    //DG1.DataContext = ds.Tables[0];

                }
            } 
            else
            {
                MessageBox.Show("Не выделена строка!");
            }
        }

        private void update_Button1_Click(object sender, RoutedEventArgs e)
        {
            if (DG1.SelectedCells.Count > 0)
            {
                // Создание экземпляра класса Flat_Space
                Flat_Space flat_space = new Flat_Space();
                // Отображение созданного окна
                Transfer.CheckChange = "Edit";
                flat_space.ShowDialog();
                if (Transfer.CloseWindowChangeRowToken == true)
                {

                    String sql = "Select * from building_location";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    //DataSet ds = new DataSet("NameOfDB");
                    DataTable table = new DataTable();
                    //adapter.Fill(ds);
                    adapter.Fill(table);
                    //DG1.ItemsSource = table.DefaultView;

                    DataRowView rowView = DG1.SelectedItem as DataRowView;

                    // Задаем индекс строки, которую хотим обновить
                    int index = DG1.SelectedIndex;

                    // Получаем новое значение Name из строки
                    //string newName = (string)rowView["Name"];

                    // Находим соответствующую строку в таблице по индексу
                    DataRow row = table.Rows[index];

                    row["city_district"] = Transfer.ValueString;
                    row["street"] = Transfer.ValueString2;
                    row["house"] = Transfer.ValueString3;
                    row["distance_to_city_center"] = Transfer.ValueFloat;
                    row["order_number"] = Transfer.ValueString4;

                    // Сохраняем изменения в базе данных с помощью адаптера
                    //adapter.Update(table);
                    //DG1.DataContext = ds.Tables[0];

                    //MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                    //adapter.DeleteCommand = My.GetDeleteCommand();
                    adapter.Update(table);
                    table.AcceptChanges();
                    DG1.DataContext = table;

                    //adapter.Update(ds.Tables[0]);
                    //ds.Tables[0].AcceptChanges();
                    //DG1.DataContext = ds.Tables[0];

                }
            }
            else
            {
                MessageBox.Show("Не выделена строка!");
            }
        }

        private void update_Button2_Click(object sender, RoutedEventArgs e)
        {
            if (DG1.SelectedCells.Count > 0)
            {
                // Создание экземпляра класса Flat_Space
                Building building = new Building();
                // Отображение созданного окна
                Transfer2.CheckChange = "Edit";
                building.ShowDialog();
                if (Transfer2.CloseWindowChangeRowToken == true)
                {

                    String sql = "Select * from building";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    //DataSet ds = new DataSet("NameOfDB");
                    DataTable table = new DataTable();
                    //adapter.Fill(ds);
                    adapter.Fill(table);
                    //DG1.ItemsSource = table.DefaultView;

                    DataRowView rowView = DG1.SelectedItem as DataRowView;

                    // Задаем индекс строки, которую хотим обновить
                    int index = DG1.SelectedIndex;

                    // Получаем новое значение Name из строки
                    //string newName = (string)rowView["Name"];

                    // Находим соответствующую строку в таблице по индексу
                    DataRow row = table.Rows[index];

                    row["kadastr"] = Transfer2.ValueFloat;
                    row["city_area"] = Transfer2.ValueString;
                    row["building_year"] = Transfer2.ValueString2;
                    row["building_material"] = Transfer2.ValueString3;
                    row["fundament_year"] = Transfer2.ValueString4;
                    row["house_brokeness"] = Transfer2.ValueString5;
                    row["floor_quantity"] = Transfer2.ValueString6;
                    row["apartments_square"] = Transfer2.ValueString7;
                    row["land_square"] = Transfer2.ValueString8;
                    row["picture"] = Transfer2.ValueString9;
                    row["apartments_quantity"] = Transfer2.ValueString10;
                    row["elevator_boolean"] = Transfer2.ValueString11;
                    row["unique_order_number"] = Transfer2.ValueString12;

                    // Сохраняем изменения в базе данных с помощью адаптера
                    //adapter.Update(table);
                    //DG1.DataContext = ds.Tables[0];

                    //MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                    //adapter.DeleteCommand = My.GetDeleteCommand();
                    adapter.Update(table);
                    table.AcceptChanges();
                    DG1.DataContext = table;

                    //adapter.Update(ds.Tables[0]);
                    //ds.Tables[0].AcceptChanges();
                    //DG1.DataContext = ds.Tables[0];

                }
            }
            else
            {
                MessageBox.Show("Не выделена строка!");
            }
        }

        private void update_Button3_Click(object sender, RoutedEventArgs e)
        {
            if (DG1.SelectedCells.Count > 0)
            {
                // Создание экземпляра класса Flat_Space
                Building_Material building_material = new Building_Material();
                // Отображение созданного окна
                Transfer3.CheckChange = "Edit";
                building_material.ShowDialog();
                if (Transfer3.CloseWindowChangeRowToken == true)
                {

                    String sql = "Select * from Building_material";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    //DataSet ds = new DataSet("NameOfDB");
                    DataTable table = new DataTable();
                    //adapter.Fill(ds);
                    adapter.Fill(table);
                    //DG1.ItemsSource = table.DefaultView;

                    DataRowView rowView = DG1.SelectedItem as DataRowView;

                    // Задаем индекс строки, которую хотим обновить
                    int index = DG1.SelectedIndex;

                    // Получаем новое значение Name из строки
                    //string newName = (string)rowView["Name"];

                    // Находим соответствующую строку в таблице по индексу
                    DataRow row = table.Rows[index];

                    row["building_material"] = Transfer3.ValueString;
                    row["material"] = Transfer3.ValueString2;

                    // Сохраняем изменения в базе данных с помощью адаптера
                    //adapter.Update(table);
                    //DG1.DataContext = ds.Tables[0];

                    //MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                    //adapter.DeleteCommand = My.GetDeleteCommand();
                    adapter.Update(table);
                    table.AcceptChanges();
                    DG1.DataContext = table;

                    //adapter.Update(ds.Tables[0]);
                    //ds.Tables[0].AcceptChanges();
                    //DG1.DataContext = ds.Tables[0];

                }
            }
            else
            {
                MessageBox.Show("Не выделена строка!");
            }
        }

        private void update_Button4_Click(object sender, RoutedEventArgs e)
        {
            if (DG1.SelectedCells.Count > 0)
            {
                // Создание экземпляра класса Flat_Space
                Flat flat = new Flat();
                // Отображение созданного окна
                Transfer4.CheckChange = "Edit";
                flat.ShowDialog();
                if (Transfer4.CloseWindowChangeRowToken == true)
                {

                    String sql = "Select * from Flat";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    //DataSet ds = new DataSet("NameOfDB");
                    DataTable table = new DataTable();
                    //adapter.Fill(ds);
                    adapter.Fill(table);
                    //DG1.ItemsSource = table.DefaultView;

                    DataRowView rowView = DG1.SelectedItem as DataRowView;

                    // Задаем индекс строки, которую хотим обновить
                    int index = DG1.SelectedIndex;

                    // Получаем новое значение Name из строки
                    //string newName = (string)rowView["Name"];

                    // Находим соответствующую строку в таблице по индексу
                    DataRow row = table.Rows[index];

                    row["number"] = Transfer4.ValueString;
                    row["Floor"] = Transfer4.ValueString2;
                    row["Rooms_quantity"] = Transfer4.ValueString3;
                    row["total_space"] = Transfer4.ValueString4;
                    row["wall_height"] = Transfer4.ValueString5;
                    row["two_flor_apartment"] = Transfer4.ValueString6;
                    row["Kadastr"] = Transfer4.ValueString7;

                    // Сохраняем изменения в базе данных с помощью адаптера
                    //adapter.Update(table);
                    //DG1.DataContext = ds.Tables[0];

                    //MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                    //adapter.DeleteCommand = My.GetDeleteCommand();
                    adapter.Update(table);
                    table.AcceptChanges();
                    DG1.DataContext = table;

                    //adapter.Update(ds.Tables[0]);
                    //ds.Tables[0].AcceptChanges();
                    //DG1.DataContext = ds.Tables[0];

                }
            }
            else
            {
                MessageBox.Show("Не выделена строка!");
            }
        }

        private void update_Button6_Click(object sender, RoutedEventArgs e)
        {
            if (DG1.SelectedCells.Count > 0)
            {
                // Создание экземпляра класса Flat_Space
                Room room = new Room();
                // Отображение созданного окна
                Transfer6.CheckChange = "Edit";
                room.ShowDialog();
                if (Transfer6.CloseWindowChangeRowToken == true)
                {

                    String sql = "Select * from Room";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, dataConnect);

                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    //DataSet ds = new DataSet("NameOfDB");
                    DataTable table = new DataTable();
                    //adapter.Fill(ds);
                    adapter.Fill(table);
                    //DG1.ItemsSource = table.DefaultView;

                    DataRowView rowView = DG1.SelectedItem as DataRowView;

                    // Задаем индекс строки, которую хотим обновить
                    int index = DG1.SelectedIndex;

                    // Получаем новое значение Name из строки
                    //string newName = (string)rowView["Name"];

                    // Находим соответствующую строку в таблице по индексу
                    DataRow row = table.Rows[index];

                    row["number"] = Transfer6.ValueString;
                    row["square"] = Transfer6.ValueString2;
                    row["razmery"] = Transfer6.ValueString3;
                    row["room_type"] = Transfer6.ValueString4;
                    row["room_material"] = Transfer6.ValueString5;
                    row["room_height"] = Transfer6.ValueString6;
                    row["socket_number"] = Transfer6.ValueString7;
                    row["battery_number"] = Transfer6.ValueString8;
                    row["apartment_number"] = Transfer6.ValueString9;

                    // Сохраняем изменения в базе данных с помощью адаптера
                    //adapter.Update(table);
                    //DG1.DataContext = ds.Tables[0];

                    //MySqlCommandBuilder My = new MySqlCommandBuilder(adapter);
                    //adapter.DeleteCommand = My.GetDeleteCommand();
                    adapter.Update(table);
                    table.AcceptChanges();
                    DG1.DataContext = table;

                    //adapter.Update(ds.Tables[0]);
                    //ds.Tables[0].AcceptChanges();
                    //DG1.DataContext = ds.Tables[0];

                }
            }
            else
            {
                MessageBox.Show("Не выделена строка!");
            }
        }
    }
}
