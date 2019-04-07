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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace komis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelWidoku Model;
        public MainWindow()
        {
            Model = new ModelWidoku();

            InitializeComponent();
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            Model.SaveChanges(this);
        }

        private void LoadMarka(object sender, RoutedEventArgs e)
        {

            Data.ItemsSource = Model.GetData("select * from [Markas]").DefaultView;
        }
        private void LoadModel(object sender, RoutedEventArgs e)
        {
            Data.ItemsSource = Model.GetData("select * from [Model_pojazdu]").DefaultView;
          //  Data.ItemsSource = Model.GetData("select Nazwa_Marki.Marka, nazwa_Modelu.Model_pojazdu from [Model_pojazdu] left join  ").DefaultView;
        }
        private void LoadRodzaj(object sender, RoutedEventArgs e)
        {
            
            Data.ItemsSource = Model.GetData("select * from [Rodzajs]").DefaultView;
        }
        private void LoadPojazd(object sender, RoutedEventArgs e)
        {
           
            Data.ItemsSource = Model.GetData("select * from [Pojazds]").DefaultView;
        }
        private void LoadOsoba(object sender, RoutedEventArgs e)
        {
           
            Data.ItemsSource = Model.GetData("select * from [Osobas]").DefaultView;
        }
        private void LoadKlient(object sender, RoutedEventArgs e)
        {
          
            Data.ItemsSource = Model.GetData("select * from [Klients]").DefaultView;
        }
        private void LoadSprzedawca(object sender, RoutedEventArgs e)
        {
           
            Data.ItemsSource = Model.GetData("select * from [Sprzedawcas]").DefaultView;
        }
        private void LoadTransakcje(object sender, RoutedEventArgs e)
        {
         
            Data.ItemsSource = Model.GetData("select * from [Tranzakcjas]").DefaultView;
        }
        private void WindowClosed(object sender, EventArgs e)
        {
            Model.On_Closed(this);
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            Model.SaveChanges(this);
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

    }
}
