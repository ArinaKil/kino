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

namespace kino_kilunina.Pages.Users.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public ClubsContext AllClubs = new ClubsContext();

        Main Main;
        Models.Users User;
        public Item(Models.Users user, Main main)
        {
            InitializeComponent();

            this.User = user;
            this.Main = main;

            FIO.Text = user.FIO;
            RentStart.Text = User.RentStart.ToString("yyyy-MM-dd");
            RentTime.Text = User.RentStart.ToString("HH:mm");
            Duration.Text = User.Duration.ToString();
            Club.Text = AllClubs.Clubs.Where(x => x.Id == User.IdClub).First().Name;
        }

        private void EditUser(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPage(new Add(Main, User));

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            Main.Users.Remove(User);
            Main.Users.SaveChanges();
            Main.Parent.Children.Remove(this);
        }
    }
}
