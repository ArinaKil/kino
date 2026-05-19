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

namespace kino_kilunina.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public ClubsContext AllClubs = new ClubsContext();
        Main Main;
        Models.Users User;

        public Add(Main main, Models.Users user = null)
        {
            InitializeComponent();

            foreach (Models.Clubs Club in AllClubs.Clubs)
                Clubs.Items.Add(Club.Name);
            Clubs.Items.Add("Выберите...");

            this.Main = main;
            if (user != null) {
                FIO.Text = user.FIO;
                RentStart.Text = User.RentStart.ToString("yyyy-MM-dd");
                RentTime.Text = User.RentStart.ToString("HH:mm");
                Duration.Text = User.Duration.ToString();
                Clubs.SelectedItem = AllClubs.Clubs.Where(x => x.Id == User.IdClub).First().Name;
                this.User = user;
            }
        }
        private void AddUser(object sender, RoutedEventArgs e)
        {
            DateTime DTRentStart = new DateTime();
            DateTime.TryParse(RentStart.Text, out DTRentStart);
            DTRentStart = DTRentStart.Add(TimeSpan.Parse(this.RentTime.Text));

            if (User == null)
            {
                User = new Models.Users()
                {
                    FIO = FIO.Text,
                    RentStart = DTRentStart,
                    Duration = Convert.ToInt32(Duration.Text),
                    IdClub = AllClubs.Clubs.Where(x => x.Name == Clubs.SelectedItem).First().Id
                };
                Main.Users.Add(User);
            }
            else
            {
                User.FIO = FIO.Text;
                User.RentStart = DTRentStart;
                User.Duration = Convert.ToInt32(Duration.Text);
                User.IdClub = AllClubs.Clubs.Where(x => x.Name == Clubs.SelectedItem).First().Id;
            }

            Main.Users.SaveChanges();
            MainWindow.init.OpenPage(new Main());
        }
    }
}
