using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using tsl2ur.lib;


namespace TSLab2UniversalReportConverter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Trade> _tradeList;
        public MainWindow()
        {
            InitializeComponent();
        }        

        private void TsLabReaderButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog tslabDialog = new OpenFileDialog();
            tslabDialog.Filter = "Отчет TSLab (*.csv)|*.csv";
            tslabDialog.DefaultExt = ".csv";
            bool? result = tslabDialog.ShowDialog();
            if (result == true)
            {
                string filename = tslabDialog.FileName;
                TsLabReader reader = new TsLabReader(filename);
                this._tradeList = reader.GetTradeList();
                this.TsLabFileLabel.Content = filename;
            }
        }

        private void ReportWriterButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog reportDialog = new SaveFileDialog();
            reportDialog.Filter = "Файл Excel 97-2003 (*.xls)|*.xls";
            reportDialog.DefaultExt = ".xls";
            bool? result = reportDialog.ShowDialog();
            if (result == true)
            {
                string filename = reportDialog.FileName;
                ReportWriter writer = new ReportWriter(this._tradeList);
                writer.WriteReport(filename);
                this.ReportFileLabel.Content = filename;
                MessageBox.Show("Успешно");
            }
        }
    }
}
