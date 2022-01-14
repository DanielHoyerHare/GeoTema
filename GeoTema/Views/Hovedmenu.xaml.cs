using GeoTema.Models;
using GeoTema.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace GeoTema.Views
{
    /// <summary>
    /// Interaction logic for Hovedmenu.xaml
    /// </summary>
    public partial class Hovedmenu : Window
    {
        private string Status { get; set; }
        private int SelectedID { get; set; }
        List<DataGridModel> Data = new List<DataGridModel>();
        DataGridViewModel datalist = new DataGridViewModel();
        public Hovedmenu(string status)
        {
            InitializeComponent();
            Refresh_Tabel(null);
            Status = status;
            if (Status != "Administrator")
            {
                BrugerKnapOff.Visibility = Visibility.Visible;
                if (Status == "Bruger")
                {
                    TilføjDataKnapOff.Visibility = Visibility.Visible;
                    RedigerDataKnapOff.Visibility = Visibility.Visible;
                }
            }
        }
        private void Refresh_Tabel(string input)
        {
            Searchbar.Text = null;
            Data = datalist.GetDataTable(input);
            Tabel.ItemsSource = Data;
        }
        private void Tabel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridModel selecteddata = (DataGridModel)Tabel.SelectedItem;
            if (selecteddata != null)
            {
                SelectedID = Convert.ToInt32(selecteddata.ID.ToString());
            }
        }
        private void KeyHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Refresh_Tabel(Searchbar.Text);
            }
        }
        private void Søg_Click(object sender, RoutedEventArgs e)
        {
            Refresh_Tabel(Searchbar.Text);
        }

        private void Log_Ud(object sender, RoutedEventArgs e)
        {
            Login p = new Login();
            p.Show();
            this.Close();
        }
        private void Reload(object sender, RoutedEventArgs e)
        {
            Refresh_Tabel(null);
        }

        private void BrugerKnap_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TilføjData_Click(object sender, RoutedEventArgs e)
        {
            AddData p = new AddData();
            p.Show();
        }
        private void RedigerData_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch
            {
                MessageBoxes.NoSelectedID();
            }
        }
    }
}
