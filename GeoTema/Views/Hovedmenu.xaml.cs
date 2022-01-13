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
        private DataRowView SelectedData { get; set; }
        List<Models.LandModel> Data = new List<Models.LandModel>();
        ViewModels.LandViewModel datalist = new ViewModels.LandViewModel();
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
            Data = datalist.GetDataTable(input);
            var TableData = (from item in Data select new { ID = item.ID, Land = item.Land, Verdensdel = item.Verdensdel + "   " + item.Verdensdel2, Rang = item.Rang, Fødselsrate = item.Fødselsrate }).ToList();
            Tabel.ItemsSource = TableData;
        }
        private void Tabel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedData = (DataRowView)Tabel.SelectedItem;
            if (SelectedData != null)
            {
                SelectedID = Convert.ToInt32(SelectedData.Row[0].ToString());
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
    }
}
