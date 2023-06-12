﻿using MySql.Data.MySqlClient;
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
using System.Xml;

using System.Data;
using System.Windows.Navigation;
using MySqlX.XDevAPI.Relational;
using System.Data.SqlClient;
using System.Security.Cryptography;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Windows.Controls.Primitives;

//using Microsoft.Office.Interop.Word;

using Word = Microsoft.Office.Interop.Word;



namespace lr1bd
{

    /// <summary>
    /// Логика взаимодействия для Realtor.xaml
    /// </summary>
    
    public partial class Realtor : Window
    {
        
        private readonly string dataConnect = "server=localhost; user=root; database=mydb;port=3306;password=root";

        private MySqlConnection connection;
        private string connectionString = "server=localhost; user=root; database=mydb;port=3306;password=root";


        public string nameOfTable = "";

        int MyRowCount;
        DataTable HelpTable;

        DataTable HelpBuildingTable, HelpFlatTable, HelpRoomTable;

        int columnNumber = 0;

        string buildingPK = "";
        string flatPK = "";
        int intflatPK = 0;
        string roomPK = "";

        int tableCounter = 0;

        public Realtor()
        {
            InitializeComponent();

            // Создаем подключение к базе данных
            connection = new MySqlConnection(connectionString);
            connection.Open();

            // Загружаем данные для DataGrid buildingDataGrid
            LoadBuildings();

            Table_BTN.SelectedIndex = 0;
            ReportSelection_ComboBox.SelectedIndex = 0;

            TB_Report.Text = "";
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

        private void LoadBuildings()
        {
            /*            string query = "SELECT * FROM building";

                        MySqlCommand command = new MySqlCommand(query, connection);

                        // Создаем адаптер данных для выполнения запроса и заполнения DataGrid
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        // Создаем DataSet для хранения данных
                        DataSet dataSet = new DataSet();

                        // Заполняем DataSet данными из адаптера
                        adapter.Fill(dataSet, "building");

                        // Устанавливаем источник данных для buildingDataGrid
                        //DG1.ItemsSource = dataSet.Tables["building"].DefaultView;*/

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
            HelpBuildingTable = ds.Tables[0];

            columnNumber = 2;

            nameOfTable = "building";
        }

        private void LoadFlats(string kadastr)
        {
            string query = $"SELECT * FROM Flat WHERE Kadastr = '{kadastr}'";

            MySqlCommand command = new MySqlCommand(query, connection);

            // Создаем адаптер данных для выполнения запроса и заполнения DataGrid
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            // Создаем DataSet для хранения данных
            DataSet dataSet = new DataSet();

            // Заполняем DataSet данными из адаптера
            adapter.Fill(dataSet, "Flat");

            // Устанавливаем источник данных для flatDataGrid
            //DG2.ItemsSource = dataSet.Tables["Flat"].DefaultView;

            DG2.DataContext = dataSet.Tables[0];
            HelpFlatTable = dataSet.Tables[0];
        }
        private void LoadRooms(int apartmentNumber)
        {
            string query = $"SELECT * FROM Room WHERE apartment_number = {apartmentNumber}";

            MySqlCommand command = new MySqlCommand(query, connection);

            // Создаем адаптер данных для выполнения запроса и заполнения DataGrid таблицы Room
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            // Создаем DataSet для хранения данных
            DataSet dataSet = new DataSet();

            // Заполняем DataSet данными из адаптера
            adapter.Fill(dataSet, "Room");

            // Устанавливаем источник данных для DataGrid таблицы Room
            //DG3.ItemsSource = dataSet.Tables["Room"].DefaultView;

            DG3.DataContext = dataSet.Tables[0];
            HelpRoomTable = dataSet.Tables[0];
        }

        private void MakeColumnNameList(DataTable HelpTable)
        {
            TableList.Items.Clear();
            foreach (DataColumn HelpColumn in HelpTable.Columns)
                TableList.Items.Add(HelpColumn.ColumnName);
        }

        private void WhatsRB_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.RadioButton item)
            {
                Transfer.ValueString = item.Name;
            }
        }



        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы успешно закончили сеанс под аккаунтом риелтора\nВы будете перенаправлены в меню авторизации");
            this.Hide();
            // Создание экземпляра класса LoginWindow 
            LoginWindow loginWindow = new LoginWindow();
            // Отображение созданного окна
            loginWindow.ShowDialog();
            this.Close();
        }

        private void BTN1_Click(object sender, RoutedEventArgs e)
        {
            //LoadBuildings();

            SaveToExcel();
        }

        private void SearchReset_Click(object sender, RoutedEventArgs e)
        {
            //DG1.DataContext = HelpTable;
            //LoadBuildings();

            // Получаем выбранный элемент ComboBox
            ComboBoxItem selectedComboBoxItem = Table_BTN.SelectedItem as ComboBoxItem;

            if (selectedComboBoxItem != null)
            {
                // Получаем текст выбранного элемента ComboBox
                string selectedText = (selectedComboBoxItem.Content as StackPanel).Children.OfType<TextBlock>().FirstOrDefault()?.Text;

                // Выводим MessageBox с текстом в зависимости от выбранного элемента ComboBox
                switch (selectedText)
                {
                    case "Building":
                        LoadBuildings();
                        break;
                    case "Flat":
                        LoadFlats(buildingPK);
                        break;
                    case "Room":
                        if (intflatPK != 0)
                        {
                            LoadRooms(intflatPK);
                        }
                        break;
                }
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

                    switch (ColumnType[TableList.SelectedIndex])
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            saveToWord();
        }

        private void saveToWord()
        {
            //ClearDataGrid1AndKeepSelectedRow(DG1);

            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Add();

            AddHeader(doc, "Дома из таблицы Building");
            AddDataGridContents(doc, DG1);

            AddHeader(doc, "Квартиры из таблицы Flat");
            AddDataGridContents(doc, DG2);

            AddHeader(doc, "Комнаты из таблицы Room");
            AddDataGridContents(doc, DG3);

            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Риелтор_Word_Отчет_СТРОКИ.docx");
            doc.SaveAs2(filePath);
            doc.Close();
            wordApp.Quit();

            MessageBox.Show("Отчет сохранен в файл." + "Риелтор_Word_Отчет_СТРОКИ.docx");

            System.Diagnostics.Process.Start(filePath);
        }

        private void BuildingDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранную строку из buildingDataGrid
            DataRowView selectedBuilding = DG1.SelectedItem as DataRowView;

            if (selectedBuilding != null)
            {
                // Получаем значение первичного ключа kadastr из выбранной строки
                string kadastr = selectedBuilding["kadastr"].ToString();
                buildingPK = selectedBuilding["kadastr"].ToString();

                // Загружаем данные по квартирам для выбранного здания
                LoadFlats(kadastr);
                DG3.DataContext = null;
                intflatPK = 0;

                TB_Report.Text = "";
            }
        }

        private void FlatDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранную строку из DataGrid таблицы Flat
            DataRowView selectedFlat = DG2.SelectedItem as DataRowView;

            if (selectedFlat != null)
            {
                // Получаем значение первичного ключа number из выбранной строки
                int number = int.Parse(selectedFlat["number"].ToString());
                //flatPK = number.ToString();
                intflatPK = int.Parse(selectedFlat["number"].ToString());

                // Загружаем данные по комнатам для выбранной квартиры
                LoadRooms(number);

                TB_Report.Text = "";
            }
        }

        private void RoomDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void Table_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранный элемент ComboBox
            ComboBoxItem selectedComboBoxItem = Table_BTN.SelectedItem as ComboBoxItem;

            if (selectedComboBoxItem != null)
            {
                // Получаем текст выбранного элемента ComboBox
                string selectedText = (selectedComboBoxItem.Content as StackPanel).Children.OfType<TextBlock>().FirstOrDefault()?.Text;

                // Выводим MessageBox с текстом в зависимости от выбранного элемента ComboBox
                switch (selectedText)
                {
                    case "Building":
                        //MessageBox.Show("Выбрана таблица Building");

                        // Выбираем таблицу building_location
                        string SqlQwery = "Select * from building";
                        //Создаем объект MySqlDataAdapter
                        MySqlDataAdapter adapter = new MySqlDataAdapter(SqlQwery, dataConnect);
                        // Создаем объект Dataset
                        DataSet ds = new DataSet("NameOfDB");
                        // Заполняем созданный объект Dataset новой таблицей
                        adapter.Fill(ds);
                        // Выводим данные в элемент DataGrid
                        MakeColumnNameList(ds.Tables[0]);
                        HelpTable = ds.Tables[0];

                        tableCounter = 1;

                        break;
                    case "Flat":
                        //MessageBox.Show("Выбрана таблица Flat");

                        // Выбираем таблицу building_location
                        string SqlQwery2 = "Select * from Flat";
                        //Создаем объект MySqlDataAdapter
                        MySqlDataAdapter adapter2 = new MySqlDataAdapter(SqlQwery2, dataConnect);
                        // Создаем объект Dataset
                        DataSet ds2 = new DataSet("NameOfDB");
                        // Заполняем созданный объект Dataset новой таблицей
                        adapter2.Fill(ds2);
                        // Выводим данные в элемент DataGrid
                        MakeColumnNameList(ds2.Tables[0]);
                        HelpTable = ds2.Tables[0];

                        tableCounter = 2;

                        break;
                    case "Room":
                        //MessageBox.Show("Выбрана таблица Room");

                        // Выбираем таблицу building_location
                        string SqlQwery3 = "Select * from Room";
                        //Создаем объект MySqlDataAdapter
                        MySqlDataAdapter adapter3 = new MySqlDataAdapter(SqlQwery3, dataConnect);
                        // Создаем объект Dataset
                        DataSet ds3 = new DataSet("NameOfDB");
                        // Заполняем созданный объект Dataset новой таблицей
                        adapter3.Fill(ds3);
                        // Выводим данные в элемент DataGrid
                        MakeColumnNameList(ds3.Tables[0]);
                        HelpTable = ds3.Tables[0];

                        tableCounter = 3;

                        break;
                    default:
                        MessageBox.Show("Выбран неизвестный элемент");
                        break;
                }
            }
        }

        private void Search(string FiltrColumnName, string FiltrValue)
        {
            DataTable FiltrTable;
            string Filtr = "";

            ComboBoxItem selectedComboBoxItem = Table_BTN.SelectedItem as ComboBoxItem;
            string selectedText = (selectedComboBoxItem.Content as StackPanel).Children.OfType<TextBlock>().FirstOrDefault()?.Text;


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

            //Building
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

            //Flat
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

            //Room
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

            //DataRow[] HelpDataRows = HelpTable.Select(Filtr);

            if (selectedComboBoxItem != null)
            {
                // Выводим MessageBox с текстом в зависимости от выбранного элемента ComboBox
                switch (selectedText)
                {
                    case "Building":
                        HelpTable = HelpBuildingTable;
                        break;
                    case "Flat":
                        HelpTable = HelpFlatTable;
                        break;
                    case "Room":
                        HelpTable = HelpRoomTable;
                        break;

                }
            } 

            DataRow[] HelpDataRows = HelpTable.Select(Filtr);

            FiltrTable = HelpTable.Clone();
            for (int i = 0; i < HelpDataRows.Length; i++)
            {
                FiltrTable.ImportRow(HelpDataRows[i]);
                
                // Получаем выбранный элемент ComboBox
                
                //ComboBoxItem selectedComboBoxItem = Table_BTN.SelectedItem as ComboBoxItem;

                if (selectedComboBoxItem != null)
                {
                    // Получаем текст выбранного элемента ComboBox
                    //string selectedText = (selectedComboBoxItem.Content as StackPanel).Children.OfType<TextBlock>().FirstOrDefault()?.Text;

                    // Выводим MessageBox с текстом в зависимости от выбранного элемента ComboBox
                    switch (selectedText)
                    {
                        case "Building":
                            DG1.DataContext = FiltrTable;
                            break;
                        case "Flat":
                            DG2.DataContext = FiltrTable;
                            break;
                        case "Room":
                            DG3.DataContext = FiltrTable;
                            break;

                    }
                }
            }
        }

        private void SaveToExcel()
        {
            // Создаем новый пакет Excel
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();

            // Создаем листы в Excel-файле
            ExcelWorksheet worksheet1 = excelPackage.Workbook.Worksheets.Add("Дом");
            ExcelWorksheet worksheet2 = excelPackage.Workbook.Worksheets.Add("Квартиры");
            ExcelWorksheet worksheet3 = excelPackage.Workbook.Worksheets.Add("Комнаты");

            // Заполняем данные для первой таблицы (DG1)
            FillWorksheetFromDataGrid(DG1, worksheet1);

            // Заполняем данные для второй таблицы (DG2)
            FillWorksheetFromDataGrid(DG2, worksheet2);

            // Заполняем данные для третьей таблицы (DG3)
            FillWorksheetFromDataGrid(DG3, worksheet3);

            // Сохраняем Excel-файл
            string fileName = "Риелтор_Excel_Отчет.xlsx";
            FileInfo excelFile = new FileInfo(fileName);
            excelPackage.SaveAs(excelFile);

            MessageBox.Show("Отчет сохранен в файле: " + fileName);

            System.Diagnostics.Process.Start(fileName);
        }

        private void FillWorksheetFromDataGrid(DataGrid dataGrid, ExcelWorksheet worksheet)
        {
            int startRow = 1;
            int startColumn = 1;

            // Заполняем заголовки столбцов
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                worksheet.Cells[startRow, startColumn + i].Value = dataGrid.Columns[i].Header;
                worksheet.Cells[startRow, startColumn + i].Style.Font.Bold = true;
                worksheet.Cells[startRow, startColumn + i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            // Заполняем данные из таблицы
            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    DataGridCell cell = GetCell(dataGrid, i, j);
                    if (cell != null && cell.Content is TextBlock textBlock)
                    {
                        string cellValue = textBlock.Text;
                        worksheet.Cells[startRow + i + 1, startColumn + j].Value = cellValue;
                    }
                }
            }
        }

        private void SaveDataGridToExcel(DataGrid dataGrid, ExcelWorksheet worksheet, string headerText, int startRow, int startColumn)
        {
            // Запись заголовка
            worksheet.Cells[startRow, startColumn].Value = headerText;
            worksheet.Cells[startRow, startColumn, startRow, startColumn + dataGrid.Columns.Count - 1].Merge = true;
            worksheet.Cells[startRow, startColumn, startRow, startColumn + dataGrid.Columns.Count - 1].Style.Font.Bold = true;
            worksheet.Cells[startRow, startColumn, startRow, startColumn + dataGrid.Columns.Count - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            // Запись данных
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                worksheet.Cells[startRow + 1, startColumn + i].Value = dataGrid.Columns[i].Header;
                worksheet.Cells[startRow + 1, startColumn + i].Style.Font.Bold = true;
                worksheet.Cells[startRow + 1, startColumn + i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                for (int j = 0; j < dataGrid.Items.Count; j++)
                {
                    var cell = GetCell(dataGrid, j, i);
                    var cellValue = cell.Content as string;
                    worksheet.Cells[startRow + j + 2, startColumn + i].Value = cellValue;
                }
            }
        }

        private DataGridCell GetCell(DataGrid dataGrid, int row, int column)
        {
            DataGridRow gridRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(row);
            if (gridRow != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(gridRow);
                if (presenter != null)
                {
                    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                    if (cell != null)
                        return cell;
                }
            }
            return null;
        }

        private static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                    child = GetVisualChild<T>(v);
                if (child != null)
                    break;
            }
            return child;
        }

        private void AddHeader(Word.Document doc, string headerText)
        {
            Word.Paragraph headerParagraph = doc.Content.Paragraphs.Add();
            Word.Range headerRange = headerParagraph.Range;
            headerRange.Text = headerText;
            headerRange.Font.Bold = 1;
            headerRange.InsertParagraphAfter();
        }

        private void AddDataGridContents(Word.Document doc, DataGrid dataGrid)
        {
            for (int rowIndex = 0; rowIndex < dataGrid.Items.Count - 1; rowIndex++)
            {
                var item = dataGrid.Items[rowIndex];
                string rowData = string.Empty;

                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    string cellValue = string.Empty;
                    if (dataGrid.Columns[i].GetCellContent(item) is TextBlock cellContent)
                    {
                        cellValue = cellContent.Text;
                    }

                    rowData += $"{dataGrid.Columns[i].Header}: {cellValue}\n";
                }

                if (!string.IsNullOrEmpty(rowData.Trim())) // Проверка на пустую строку
                {
                    AddRow(doc, rowData);
                }
            }
        }


        private void AddRow(Word.Document doc, string rowData)
        {
            Word.Paragraph rowParagraph = doc.Content.Paragraphs.Add();
            Word.Range rowRange = rowParagraph.Range;
            rowRange.Text = rowData;
            rowRange.InsertParagraphAfter();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Add();

            AddHeaderUNREADABLE(doc, "Дома из таблицы Building");
            AddDataGridContentsUNREADABLE(doc, DG1);

            AddHeaderUNREADABLE(doc, "Квартиры из таблицы Flat");
            AddDataGridContents(doc, DG2);

            AddHeaderUNREADABLE(doc, "Комнаты из таблицы Room");
            AddDataGridContentsUNREADABLE(doc, DG3);

            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Риелтор_Word_Отчет_ТАБЛИЦА.docx");
            doc.SaveAs2(filePath);
            doc.Close();
            wordApp.Quit();

            MessageBox.Show("Отчет сохранен в файл.");
        }

        private void AddHeaderUNREADABLE(Word.Document doc, string headerText)
        {
            Word.Paragraph paragraph = doc.Content.Paragraphs.Add();
            paragraph.Range.Text = headerText;
            paragraph.Range.Font.Bold = 1;
            paragraph.Range.InsertParagraphAfter();
        }

        private void AddDataGridContentsUNREADABLE(Word.Document doc, DataGrid dataGrid)
        {
            Word.Table table = doc.Tables.Add(doc.Content.Paragraphs.Add().Range, dataGrid.Items.Count + 1, dataGrid.Columns.Count);

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                table.Cell(1, i + 1).Range.Text = dataGrid.Columns[i].Header.ToString();
                table.Cell(1, i + 1).Range.Font.Bold = 1;
            }

            for (int i = 0; i < dataGrid.Items.Count; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    string cellValue = string.Empty;
                    if (dataGrid.Columns[j].GetCellContent(dataGrid.Items[i]) is TextBlock cellContent)
                    {
                        cellValue = cellContent.Text;
                    }

                    table.Cell(i + 2, j + 1).Range.Text = cellValue;
                }
            }
        }


        // Метод, который возвращает текст из DataGrid
        private string GetDataGridText(DataGrid dataGrid)
        {
            // Создаем пустую строку для текста
            string text = "";
            // Добавляем в нее название DataGrid
            
            switch (dataGrid.Name.ToString())
            {
                case "DG1":
                    text += "Таблица со зданиями (Building)" + "\n";
                    break;
                case "DG2":
                    text += "Таблица с квартирами в здании (Flat)" + "\n";
                    break;
                case "DG3":
                    text += "Таблица с комнатами в квартире (Room)" + "\n";
                    break;
            }
            
            //text += dataGrid.Name + "\n";

            // Добавляем в нее данные из каждой строки
            foreach (DataRowView row in dataGrid.ItemsSource)
            {
                // Добавляем в нее названия и значения столбцов
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    text += dataGrid.Columns[i].Header + ": " + row.Row.ItemArray[i] + "\n";
                }
                // Добавляем пустую строку для разделения строк
                text += "\n";
            }
            // Возвращаем текст
            return text;
        }

        private void CreateReport_BTN_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный элемент ComboBox
            ComboBoxItem selectedComboBoxItem = ReportSelection_ComboBox.SelectedItem as ComboBoxItem;

            if (selectedComboBoxItem != null)
            {
                // Получаем текст выбранного элемента ComboBox
                string selectedText = (selectedComboBoxItem.Content as StackPanel).Children.OfType<TextBlock>().FirstOrDefault()?.Text;

                // Выводим MessageBox с текстом в зависимости от выбранного элемента ComboBox
                switch (selectedText)
                {
                    case "Создать":
                        createReportTB();

                        MessageBox.Show("Отчет успешно создан!");

                        // Создаем MessageBox с вопросом
                        MessageBoxResult result = MessageBox.Show("Напечатать полученный отчет?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        // Обрабатываем результат
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                // Действия при нажатии на "Да"
                                printCreatedReportFromTB();
                                //MessageBox.Show("Вы выбрали Да.");
                                break;

                            case MessageBoxResult.No:
                                // Действия при нажатии на "Нет"
                                //MessageBox.Show("Вы выбрали Нет.");
                                break;
                        }
                        break;
                    case "Печать":
                        //MessageBox.Show("Выбрана таблица Flat");
                        if (string.IsNullOrEmpty(TB_Report.Text))
                        {
                            // Создаем MessageBox с вопросом
                            MessageBoxResult results = MessageBox.Show("Отчет пустой. Создать отчет по выбранному зданию?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

                            // Обрабатываем результат
                            switch (results)
                            {
                                case MessageBoxResult.Yes:
                                    // Действия при нажатии на "Да"
                                    createReportTB();
                                    printCreatedReportFromTB();
                                    //MessageBox.Show("Вы выбрали Да.");
                                    break;

                                case MessageBoxResult.No:
                                    // Действия при нажатии на "Нет"
                                    //MessageBox.Show("Вы выбрали Нет.");
                                    break;
                            }
                        }
                        else
                        {
                            printCreatedReportFromTB();
                        }
                        break;
                    case "Excel":
                        SaveToExcel();
                        break;
                    case "Word":
                        saveToWord();
                        break;
                    case "Word Таблицы":
                        CreateWordReport_withTables();
                        break;
                    case "Выйти из аккаунта":
                        MessageBox.Show("Вы успешно закончили сеанс под аккаунтом риелтора\nВы будете перенаправлены в меню авторизации");
                        this.Hide();
                        // Создание экземпляра класса LoginWindow 
                        LoginWindow loginWindow = new LoginWindow();
                        // Отображение созданного окна
                        loginWindow.ShowDialog();
                        this.Close();
                        break;
                    default:
                        MessageBox.Show("Выбран неизвестный элемент");
                        break;
                }
            }
        }

        private void createReportTB()
        {
            // Создаем пустую строку для отчета
            string reportText = "";
            // Добавляем в нее текст из каждого DataGrid

            reportText += GetDataGridTextChanged(DG1);

            // Создаем MessageBox с вопросом
            MessageBoxResult result = MessageBox.Show("Добавить в отчет квартиры и комнаты?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Обрабатываем результат
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // Действия при нажатии на "Да"
                    reportText += GetDataGridTextChanged(DG2);
                    reportText += GetDataGridTextChanged(DG3);
                    //MessageBox.Show("Вы выбрали Да.");
                    break;

                case MessageBoxResult.No:
                    // Действия при нажатии на "Нет"
                    //MessageBox.Show("Вы выбрали Нет.");
                    break;
            }

            // Отображаем отчет в TextBlock
            TB_Report.Text = reportText;
        }

        private string GetDataGridTextChanged(DataGrid dataGrid)
        {
            string text = "";

            switch (dataGrid.Name.ToString())
            {
                case "DG1":
                    text += "Таблица со зданиями (Building)" + "\n";
                    break;
                case "DG2":
                    text += "Таблица с квартирами в здании (Flat)" + "\n";
                    break;
                case "DG3":
                    text += "Таблица с комнатами в квартире (Room)" + "\n";
                    break;
                case "DG5":
                    text += "Таблица с местоположением здания (Building_location)" + "\n";
                    break;
            }

            switch (dataGrid.Name.ToString())
            {
                case "DG1":
                    if (dataGrid.SelectedItems.Count > 0)
                    {
                        DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
                        for (int i = 0; i < dataGrid.Columns.Count; i++)
                        {
                            text += dataGrid.Columns[i].Header + ": " + selectedRow.Row.ItemArray[i] + "\n";
                        }
                        text += "\n";
                    }
                    break;
                case "DG2":
                case "DG3":
                case "DG5":
                    foreach (DataRowView row in dataGrid.ItemsSource)
                    {
                        for (int i = 0; i < dataGrid.Columns.Count; i++)
                        {
                            text += dataGrid.Columns[i].Header + ": " + row.Row.ItemArray[i] + "\n";
                        }
                        text += "\n";
                    }
                    break;
            }

            return text;
        }

        private void printCreatedReportFromTB()
        {
            // Создаем объект PrintDialog
            PrintDialog printDialog = new PrintDialog();
            // Отображаем диалоговое окно печати
            if (printDialog.ShowDialog() == true)
            {
                // Получаем текст из TextBox
                string text = TB_Report.Text;
                // Создаем объект FlowDocument для форматирования текста
                FlowDocument document = new FlowDocument(new Paragraph(new Run(text)));
                // Устанавливаем размер страницы и ориентацию в соответствии с параметрами печати
                document.PageHeight = printDialog.PrintableAreaHeight;
                document.PageWidth = printDialog.PrintableAreaWidth;
                document.PagePadding = new Thickness(50);
                document.ColumnGap = 0;
                document.ColumnWidth = printDialog.PrintableAreaWidth;
                // Печатаем документ
                printDialog.PrintDocument(((IDocumentPaginatorSource)document).DocumentPaginator, "Printing TextBox");
            }
        }

        private void CreateWordReport_withTables()
        {
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Add();

            AddHeaderUNREADABLE(doc, "Дома из таблицы Building");
            AddDataGridContentsUNREADABLE(doc, DG1);

            AddHeaderUNREADABLE(doc, "Квартиры из таблицы Flat");
            AddDataGridContents(doc, DG2);

            AddHeaderUNREADABLE(doc, "Комнаты из таблицы Room");
            AddDataGridContentsUNREADABLE(doc, DG3);

            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Риелтор_Word_Отчет_ТАБЛИЦА.docx");
            doc.SaveAs2(filePath);
            doc.Close();
            wordApp.Quit();

            MessageBox.Show("Отчет сохранен в файл.");
        }

        private void ReportSelection_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранный элемент ComboBox
            ComboBoxItem selectedComboBoxItem = ReportSelection_ComboBox.SelectedItem as ComboBoxItem;

            if (selectedComboBoxItem != null)
            {
                // Получаем текст выбранного элемента ComboBox
                string selectedText = (selectedComboBoxItem.Content as StackPanel).Children.OfType<TextBlock>().FirstOrDefault()?.Text;

                // Выводим MessageBox с текстом в зависимости от выбранного элемента ComboBox
                switch (selectedText)
                {
                    case "Выйти из аккаунта":

                        break;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Создаем пустую строку для отчета
            string reportText = "";
            // Добавляем в нее текст из каждого DataGrid
            reportText += GetDataGridText(DG1);
            reportText += GetDataGridText(DG2);
            reportText += GetDataGridText(DG3);
            // Отображаем отчет в TextBlock
            TB_Report.Text = reportText;
        }

        private void buttonPrint_Click(object sender, RoutedEventArgs e)
        {
            // Создаем объект PrintDialog
            PrintDialog printDialog = new PrintDialog();
            // Отображаем диалоговое окно печати
            if (printDialog.ShowDialog() == true)
            {
                // Получаем текст из TextBox
                string text = TB_Report.Text;
                // Создаем объект FlowDocument для форматирования текста
                FlowDocument document = new FlowDocument(new Paragraph(new Run(text)));
                // Устанавливаем размер страницы и ориентацию в соответствии с параметрами печати
                document.PageHeight = printDialog.PrintableAreaHeight;
                document.PageWidth = printDialog.PrintableAreaWidth;
                document.PagePadding = new Thickness(50);
                document.ColumnGap = 0;
                document.ColumnWidth = printDialog.PrintableAreaWidth;
                // Печатаем документ
                printDialog.PrintDocument(((IDocumentPaginatorSource)document).DocumentPaginator, "Printing TextBox");
            }
        }


    }


}
