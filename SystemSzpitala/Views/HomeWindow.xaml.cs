using SystemSzpitala.Models;
using SystemSzpitala.ViewModels;
using BibliotekaKlas;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SystemSzpitala.Views
{
    /// <summary>
    /// Logika interakcji dla klasy HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow(Uzytkownik zalogowanyUzytkownik)
        {
            IEnumerable<Uzytkownik> uzytkownicy = Uzytkownicy.ListaUzytkownikow;

            InitializeComponent();
            DataContext = new HomeViewModel(listaUzytkownikowDataGrid, listaDyzurowDataGrid, passwordBox);
            WelcomingLabel.Content = $"Witaj {zalogowanyUzytkownik}";

            // ukrycie administratorów i odpowiednich kontrolek dla pracowników
            if (!(zalogowanyUzytkownik is Administrator))
            {
                uzytkownicy = Uzytkownicy.ListaUzytkownikow.Where(u => u is Pracownik);

                kolumnaNazwa.Visibility = Visibility.Hidden;
                kolumnaPesel.Visibility = Visibility.Hidden;
                kolumnaPWZ.Visibility = Visibility.Hidden;
                kolumnaZmianaDanych.Visibility = Visibility.Hidden;

                posadaStkPanel.Visibility = Visibility.Hidden;
                nowyUzytkownikGrid.Visibility = Visibility.Hidden;
                dodajButton.Visibility = Visibility.Hidden;
                usuniecieDyzuruKolumna.Visibility = Visibility.Hidden;
                wyborDaty.Visibility = Visibility.Hidden;
                zapiszButton.Visibility = Visibility.Hidden;
            }

            listaUzytkownikowDataGrid.ItemsSource = uzytkownicy;
            listaDyzurowDataGrid.ItemsSource = new List<Dyzur>();
        }

        private void WylogujSie(object sender, RoutedEventArgs e)
        {
            // otwarcie nowego okna logowania po wylogowaniu
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void ZmienDodajUzytkownika(object sender, RoutedEventArgs e)
        {
            if (DataContext is HomeViewModel homeViewModel)
            {
                if (homeViewModel.CzyWTrybieEdycji)
                    homeViewModel.ZmienUzytkownika();

                else
                    homeViewModel.DodajUzytkownika();
            }
        }

        private void ZmienDane(object sender, RoutedEventArgs e)
        {
            if (DataContext is HomeViewModel homeViewModel)
                homeViewModel.EdytujUzytkownika();
        }

        private void PasswordBox_ZmianaHasla(object sender, RoutedEventArgs e)
        {
            if (DataContext is HomeViewModel homeViewModel)
                homeViewModel.Haslo = ((PasswordBox)sender).Password;
        }

        private void DodajDyzur(object sender, RoutedEventArgs e)
        {
            if (DataContext is HomeViewModel homeViewModel)
                homeViewModel.DodajDyzur();
        }

        private void UsunDyzur(object sender, RoutedEventArgs e)
        {
            if (DataContext is HomeViewModel homeViewModel)
                homeViewModel.UsunDyzur();
        }

        private void ZapiszDane(object sender, RoutedEventArgs e)
        {
            SerializacjaXml.Serializacja();
        }
    }
}
