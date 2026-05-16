using System.Windows;
using System.Windows.Controls;
using kino_kilunina.Classes;

namespace kino_kilunina.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public ClubsContext AllClubs = new ClubsContext();
        public Main()
        {
            InitializeComponent();
            foreach (Models.Clubs Club in AllClubs.Clubs)
                Parent.Children.Add(new Elements.Item(Club, this));
        }
        private void AddClub(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPage(new Add(this));
    }
}
