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
using kino_kilunina.Classes;

namespace kino_kilunina.Pages.Clubs.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        Models.Clubs Club;
        Main Main;

        public Item(Models.Clubs club, Main main)
        {
            InitializeComponent();
            Club = club;
            Main = main;

            Name.Text = Club.Name;
            Address.Text = Club.Address;
            WorkTime.Text = Club.WorkTime;
        }

        private void EditClub(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPage(new Add(Main, Club));
        
        private void DeleteClub(object sender, RoutedEventArgs e)
        {
            Main.AllClubs.Remove(Club);
            Main.AllClubs.SaveChanges();
            Main.Parent.Children.Remove(this);
        }
    }
}
