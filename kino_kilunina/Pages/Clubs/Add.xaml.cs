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

namespace kino_kilunina.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        Main Main;
        Models.Clubs Club;
        public Add(Main main, Models.Clubs club = null)
        {
            InitializeComponent();

            this.Main = main;
            if (club != null)
            {
                Club = club;
                Name.Text = Club.Name;
                Address.Text = Club.Address;
                WorkTime.Text = Club.WorkTime;
                BtnAdd.Content = "Изменить";
            }
        }

         private void AddClub(object sender, RoutedEventArgs e)
        {
            if (Club == null)
            {
                Models.Clubs newClib = new Models.Clubs()
                {
                    Name = Name.Text,
                    Address = Address.Text,
                    WorkTime = WorkTime.Text,
                };
                Main.AllClubs.Add(newClib);
            }
            else
            {
                Club.Name = Name.Text;
                Club.Address = Address.Text;
                Club.WorkTime = WorkTime.Text;
            }
            Main.AllClubs.SaveChanges();
            MainWindow.init.OpenPage(new Main());
        }
    }
}
