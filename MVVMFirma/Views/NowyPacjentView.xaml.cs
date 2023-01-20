using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMFirma.Views
//namespace MVVMFirma.ViewModels
{
    /// <summary>
    /// Logika interakcji dla klasy NowyPacjentView.xaml
    /// </summary>
    public partial class NowyPacjentView : UserControl
    {
        public NowyPacjentView()
        {
            InitializeComponent();
        }

        //private void ButtonClicked(object sender, RoutedEventArgs e)
        //{
        //    NowyAdresView p = new NowyAdresView();
        //    p.Show();
        //}

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
