using SystemSzpitala.ViewModels;
using SystemSzpitala.Views;
using MahApps.Metro.Controls;
using System.Windows;

namespace SystemSzpitala
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SerializacjaXml.Deserializacja();

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
