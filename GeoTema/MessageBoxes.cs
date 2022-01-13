using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace GeoTema
{
    public static class MessageBoxes
    {
        public static void LoginError()
        {
            MessageBox.Show("Enten brugernavn eller kodeord var forkert!", "Login fejl", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void EmptyError()
        {
            MessageBox.Show("Alle felter skal udfyldes!", "Input fejl", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}