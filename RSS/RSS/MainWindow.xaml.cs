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

namespace RSS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Media.Brush col1 = OuterGlow.BorderBrush;
            DropShadowEffect.Color = ((SolidColorBrush)col1).Color;
            DataBase db = new DataBase();
            News wojna = new News(1, "wojna w rosji","<img src=/>- Jestem gotów poprzeć rząd mniejszościowy PiS, żeby nie destabilizować państwa - mówi w Kontrwywiadzie RMF FM szef ruchu Kukiz&#8217;15 Paweł Kukiz. - Chcę być potężnym językiem u wagi, który zmieni ustrój Polski, zmieni konstytucję, doprowadzi do tego, że Sejm zacznie pracować. Nie chcę rządzić po tych wyborach. Ja się nie nadaję na wicepremiera - dodaje. - Sondaże? Jakie sondaże, proszę pana. Patrzę na wyniki Petru i jestem przekonany, że on jest symulowany przez te sondaże - komentuje Kukiz. <a href=>wiadomosci.wp.pl</a>","dsadsa", "Mon, 12 Oct 2015 08:45:00 +0200");
            Category swiat = new Category(1, "swiat");
            swiat.AddNews(wojna);
            db.Categories.Add(swiat);
            db.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
