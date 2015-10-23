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

namespace RSS
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            //-----niebieski cien---------
            System.Windows.Media.Brush col2 = OuterGlow.BorderBrush;
            DropShadowEffect2.Color = ((SolidColorBrush)col2).Color;
            //-------------------
            List<string>lista = new List<string>();
            lista.Add("Pingwiny z Madagaskaru");
            lista.Add("Ratatuj sie kto moze");
            lista.Add("Krol Julian");
            News wojna = new News(1, "Wojna w rosji", "Jestem gotów poprzeć rząd mniejszościowy PiS, żeby nie destabilizować państwa - mówi w Kontrwywiadzie RMF FM szef ruchu Kukiz&#8217;15 Paweł Kukiz. - Chcę być potężnym językiem u wagi, który zmieni ustrój Polski, zmieni konstytucję, doprowadzi do tego, że Sejm zacznie pracować. Nie chcę rządzić po tych wyborach. Ja się nie nadaję na wicepremiera - dodaje. - Sondaże? Jakie sondaże, proszę pana. Patrzę na wyniki Petru i jestem przekonany, że on jest symulowany przez te sondaże - komentuje Kukiz.", "www.bleble.pl", "Mon, 12 Oct 2015 08:45:00 +0200");
            Category swiat = new Category(1, "swiat");
            swiat.AddNews(wojna);
            TextBlock1Win2.Text = wojna.DescriptionOfNews.Text;
            string link1 = "http://i.wp.pl/a/f/film/001/12/12/0431212.jpg";
            image1win2.Source = new BitmapImage(new Uri(link1));
            //MainWindow okno1 = new MainWindow();
            //if (okno1.zmienna==0)
            //{
                TextBlock2Win2.Text = lista[0];
            //}
            
            TextBlock3Win2.Text = wojna.LinkToWebsite;
            TextBlock4Win2.Text = wojna.DateOfPublication.ToString();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Rectangle_PreviewMouseLeftButtonDown2(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        
    }
}
