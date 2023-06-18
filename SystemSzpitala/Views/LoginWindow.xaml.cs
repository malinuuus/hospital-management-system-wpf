using SystemSzpitala.ViewModels;
using BibliotekaKlas;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SystemSzpitala.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void ZalogujSie(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel loginViewModel && loginViewModel.SprobujZalogowac(out Uzytkownik zalogowanyUzytkownik))
            {
                // jeśli poprawno zalogowano otwórz główne okno i zamknij to okno
                HomeWindow homeWindow = new HomeWindow(zalogowanyUzytkownik);
                homeWindow.Show();
                this.Close();
            }
        }

        private void PasswordBox_ZmianaHasla(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel loginViewModel)
                loginViewModel.Haslo = ((PasswordBox)sender).Password;
        }
    }
}
