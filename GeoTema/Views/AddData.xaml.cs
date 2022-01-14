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
using GeoTema.ViewModels;

namespace GeoTema.Views
{
    /// <summary>
    /// Interaction logic for AddData.xaml
    /// </summary>
    public partial class AddData : Window
    {
        public AddData()
        {
            InitializeComponent();
            ComboBoxLoad();
        }
        private void ComboBoxLoad()
        {
            IList<String> Kontinenter = new List<String>() { "Afrika","Antarktis","Asien","Europa","Nordamerika","Oceanien","Sydamerika" };
            Verdensdel.ItemsSource = Kontinenter;
            Verdensdel2.ItemsSource = Kontinenter;
        }
        private void Tilføj_Click(object sender, RoutedEventArgs e)
        {
            DataViewModel Upload = new DataViewModel();
            Upload.UploadData(Land.Text,Verdensdel.Text,Verdensdel2.Text,Rang.Text,Fødselsrate.Text);
        }
    }
}
