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

namespace GeoTema.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        List<Models.BrugerModel> BrugerListe = new List<Models.BrugerModel>();
        public Login()
        {
            InitializeComponent();
        }
        private void KeyHandler1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoginKode.Focus();
            }
        }
        private void KeyHandler2(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Log_Ind();
            }
        }
        private void Log_Ind()
        {
            ViewModels.BrugerViewModel brugerliste = new ViewModels.BrugerViewModel();

            BrugerListe = brugerliste.Login(LoginBrugernavn.Text);
            try
            {
                if (LoginKode.Text == BrugerListe[0].kode)
                {
                    Hovedmenu p = new Hovedmenu(BrugerListe[0].status);
                    p.Show();
                    this.Close();
                }
                else
                {
                    MessageBoxes.LoginError();
                }
            }
            catch
            {
                if (LoginBrugernavn.Text.Length == 0 || LoginKode.Text.Length == 0) MessageBoxes.EmptyError();
                else MessageBoxes.LoginError();
            }
        }
        private void Log_Ind_Click(object sender, RoutedEventArgs e)
        {
            Log_Ind();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
