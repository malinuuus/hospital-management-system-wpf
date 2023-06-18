using SystemSzpitala.Models;
using BibliotekaKlas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace SystemSzpitala.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private Uzytkownik _wybranyUzytkownik;
        private Dyzur _wybranyDyzur;
        private readonly DataGrid _listaUzytkownikowDataGrid;
        private readonly DataGrid _listaDyzurowDataGrid;
        private readonly PasswordBox _passwordBox;
        private bool _czyWTrybieEdycji;
        private string _tytulPolaEdycji;
        private string _tytulPrzyciskuEdycji;
        private DateTime _dataDyzuru;

        // właściwości nowego użytkownika
        private string _nazwaUzytkownika;
        private string _haslo;
        private string _imie;
        private string _nazwisko;
        private string _pesel;
        private Specjalnosc _specjalnosc;
        private string _numerPWZ;
        private bool _czyAdministrator;
        private bool _czyLekarz;
        private bool _czyPielegniarka;

        public HomeViewModel(DataGrid listaUzytkownikowDataGrid, DataGrid listaDyzurowDataGrid, PasswordBox passwordBox)
        {
            CzyAdministrator = true;
            CzyWTrybieEdycji = false;
            DataDyzuru = DateTime.Now.Date;
            _listaUzytkownikowDataGrid = listaUzytkownikowDataGrid;
            _listaDyzurowDataGrid = listaDyzurowDataGrid;
            _passwordBox = passwordBox;
        }

        public Uzytkownik WybranyUzytkownik
        {
            get { return _wybranyUzytkownik; }
            set
            {
                _wybranyUzytkownik = value;
                OnPropertyChanged();
                WybierzGrafik();
            }
        }
        public Dyzur WybranyDyzur
        {
            get { return _wybranyDyzur; }
            set
            {
                _wybranyDyzur = value;
                OnPropertyChanged();
            }
        }
        public DateTime DataDyzuru
        {
            get { return _dataDyzuru; }
            set
            {
                _dataDyzuru = value;
                OnPropertyChanged();
            }
        }
        public bool CzyAdministrator
        {
            get { return _czyAdministrator; }
            set
            {
                _czyAdministrator = value;
                OnPropertyChanged();
            }
        }
        public bool CzyLekarz
        {
            get { return _czyLekarz; }
            set
            {
                _czyLekarz = value;
                OnPropertyChanged();
            }
        }
        public bool CzyPielegniarka
        {
            get { return _czyPielegniarka; }
            set
            {
                _czyPielegniarka = value;
                OnPropertyChanged();
            }
        }
        public string NazwaUzytkownika
        {
            get { return _nazwaUzytkownika; }
            set
            {
                _nazwaUzytkownika = value;
                OnPropertyChanged();
            }
        }
        public string Haslo
        {
            get { return _haslo; }
            set
            {
                _haslo = value;
                OnPropertyChanged();
            }
        }
        public string Imie
        {
            get { return _imie; }
            set
            {
                _imie = value;
                OnPropertyChanged();
            }
        }
        public string Nazwisko
        {
            get { return _nazwisko; }
            set
            {
                _nazwisko = value;
                OnPropertyChanged();
            }
        }
        public string Pesel
        {
            get { return _pesel; }
            set
            {
                _pesel = value;
                OnPropertyChanged();
            }
        }
        public Specjalnosc Specjalnosc
        {
            get { return _specjalnosc; }
            set
            {
                _specjalnosc = value;
                OnPropertyChanged();
            }
        }
        public string NumerPWZ
        {
            get { return _numerPWZ; }
            set
            {
                _numerPWZ = value;
                OnPropertyChanged();
            }
        }
        public bool CzyWTrybieEdycji
        {
            get { return _czyWTrybieEdycji; }
            set
            {
                _czyWTrybieEdycji = value;
                
                if (_czyWTrybieEdycji)
                {
                    TytulPolaEdycji = "Edytuj użytkownika";
                    TytulPrzyciskuEdycji = "Zmień";
                }
                else
                {
                    TytulPolaEdycji = "Dodaj użytkownika";
                    TytulPrzyciskuEdycji = "Dodaj";
                }
            }
        }
        public string TytulPolaEdycji
        {
            get { return _tytulPolaEdycji; }
            set
            {
                _tytulPolaEdycji = value;
                OnPropertyChanged();
            }
        }
        public string TytulPrzyciskuEdycji
        {
            get { return _tytulPrzyciskuEdycji; }
            set
            {
                _tytulPrzyciskuEdycji = value;
                OnPropertyChanged();
            }
        }
        
        private void WybierzGrafik()
        {
            if (_wybranyUzytkownik is Pracownik zaznaczonyPracownik)
            {
                IEnumerable<Dyzur> dyzuryZaznaczonegoPracownika = zaznaczonyPracownik.ListaDyzurow;
                _listaDyzurowDataGrid.ItemsSource = dyzuryZaznaczonegoPracownika;
            }
            else
                _listaDyzurowDataGrid.ItemsSource = null;
        }

        private void WyczyscInputy()
        {
            NazwaUzytkownika = "";
            Haslo = "";
            _passwordBox.Password = "";
            Imie = "";
            Nazwisko = "";
            Pesel = "";
            Specjalnosc = 0;
            NumerPWZ = "";
        }

        private bool CzyJakiesPolePuste()
        {
            return string.IsNullOrEmpty(_imie) ||
                string.IsNullOrEmpty(_nazwisko) ||
                string.IsNullOrEmpty(_pesel) ||
                string.IsNullOrEmpty(_nazwaUzytkownika) ||
                string.IsNullOrEmpty(_haslo) ||
                (CzyLekarz && _specjalnosc == 0) ||
                (CzyLekarz && string.IsNullOrEmpty(_numerPWZ));
        }

        public void DodajUzytkownika()
        {
            if (CzyJakiesPolePuste())
            {
                MessageBox.Show("Wypełnij wszystkie pola!", "Niedodano użytkownika", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Uzytkownik nowyUzytkownik;

            if (CzyAdministrator)
                nowyUzytkownik = new Administrator(_imie, _nazwisko, _pesel, _nazwaUzytkownika, _haslo);

            else if (CzyLekarz)
                nowyUzytkownik = new Lekarz(_imie, _nazwisko, _pesel, _nazwaUzytkownika, _haslo, _specjalnosc, _numerPWZ);

            else
                nowyUzytkownik = new Pielegniarka(_imie, _nazwisko, _pesel, _nazwaUzytkownika, _haslo);

            // sprawdzenie czy istnieje już użytkownik o takiej nazwie użytkownika (powinna być unikatowa)
            bool czyIstniejeDuplikat = Uzytkownicy.ListaUzytkownikow.Any(u => u.NazwaUzytkownika == _nazwaUzytkownika);

            if (czyIstniejeDuplikat)
                MessageBox.Show($"Użytkownik o nazwie użytkownika {_nazwaUzytkownika} już istnieje!", "Niedodano użytkownika", MessageBoxButton.OK, MessageBoxImage.Information);
            
            else
            {
                Uzytkownicy.ListaUzytkownikow.Add(nowyUzytkownik);
                _listaUzytkownikowDataGrid.Items.Refresh();
                WyczyscInputy();
            }
        }

        // metoda dla przycisku zmień dane (w datagridzie)
        public void EdytujUzytkownika()
        {
            CzyWTrybieEdycji = true;
            WyczyscInputy();

            // jeśli jakiś użytkownik jest zaznaczony
            if (_wybranyUzytkownik != null)
            {
                NazwaUzytkownika = _wybranyUzytkownik.NazwaUzytkownika;
                Haslo = _wybranyUzytkownik.Haslo;
                _passwordBox.Password = _wybranyUzytkownik.Haslo;
                Imie = _wybranyUzytkownik.Imie;
                Nazwisko = _wybranyUzytkownik.Nazwisko;
                Pesel = _wybranyUzytkownik.Pesel;
                CzyPielegniarka = true;

                if (_wybranyUzytkownik is Lekarz lekarz)
                {
                    Specjalnosc = lekarz.Specjalnosc;
                    NumerPWZ = lekarz.NumerPWZ;
                    CzyLekarz = true;
                }
                else
                {
                    if (_wybranyUzytkownik is Administrator)
                        CzyAdministrator = true;
                }
            }
        }

        // przycisk zmień po edycji danych
        public void ZmienUzytkownika()
        {
            if (CzyJakiesPolePuste())
            {
                MessageBox.Show("Wypełnij wszystkie pola!", "Niezmieniono danych", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // sprawdzenie czy istnieje już użytkownik o takiej nazwie użytkownika (powinna być unikatowa)
            bool czyIstniejeDuplikat = Uzytkownicy.ListaUzytkownikow.Any(u => u.NazwaUzytkownika == _nazwaUzytkownika && u.NazwaUzytkownika != _wybranyUzytkownik.NazwaUzytkownika);

            if (czyIstniejeDuplikat)
            {
                MessageBox.Show($"Użytkownik o nazwie użytkownika {_nazwaUzytkownika} już istnieje!", "Niezmieniono danych", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // indeks wybranego użytkownika
            int i = Uzytkownicy.ListaUzytkownikow.FindIndex(u => u.NazwaUzytkownika == _wybranyUzytkownik.NazwaUzytkownika);
            Uzytkownik edytowanyUzytkownik;

            if (CzyAdministrator)
                edytowanyUzytkownik = new Administrator(_imie, _nazwisko, _pesel, _nazwaUzytkownika, _haslo);

            else
            {
                if (CzyLekarz)
                    edytowanyUzytkownik = new Lekarz(_imie, _nazwisko, _pesel, _nazwaUzytkownika, _haslo, _specjalnosc, _numerPWZ);

                else
                    edytowanyUzytkownik = new Pielegniarka(_imie, _nazwisko, _pesel, _nazwaUzytkownika, _haslo);

                if (_wybranyUzytkownik is Pracownik)
                    (edytowanyUzytkownik as Pracownik).ListaDyzurow = (_wybranyUzytkownik as Pracownik).ListaDyzurow;
            }

            if (i >= 0)
                Uzytkownicy.ListaUzytkownikow[i] = edytowanyUzytkownik;

            CzyWTrybieEdycji = false;
            _listaUzytkownikowDataGrid.Items.Refresh();
            WyczyscInputy();
        }

        public void DodajDyzur()
        {
            if (_wybranyUzytkownik is Pracownik pracownik)
            {
                // sprawdzenie czy lekarz o takiej samej specjalizacji ma juz dyzur tego dnia
                bool czyTakieSameSpecjalizacje = false;

                if (pracownik is Lekarz lekarz)
                {
                    czyTakieSameSpecjalizacje = Uzytkownicy.ListaUzytkownikow
                        .Where(u => u is Lekarz && u.NazwaUzytkownika != lekarz.NazwaUzytkownika)
                        .Cast<Lekarz>()
                        .Any(l => l.Specjalnosc == lekarz.Specjalnosc && l.ListaDyzurow.Any(d => d.Data == _dataDyzuru));
                }

                if (czyTakieSameSpecjalizacje)
                    MessageBox.Show("Niedodano dyżuru. Dwóch lekarzy od takie samej specjalizacji nie może mieć dyżuru tego samego dnia!", "Niedodano dyżuru", MessageBoxButton.OK, MessageBoxImage.Error);

                // sprawdzenie reszty warunków
                else if (!pracownik.SprobujDodacDyzur(_dataDyzuru, out string wiadomosc))
                    MessageBox.Show(wiadomosc, "Niedodano dyżuru", MessageBoxButton.OK, MessageBoxImage.Error);

                else
                {
                    // sortowanie dyżurów
                    pracownik.ListaDyzurow.Sort((a, b) => a.Data.CompareTo(b.Data));
                    _listaDyzurowDataGrid.Items.Refresh();
                }
            }
            else
                MessageBox.Show($"{_wybranyUzytkownik} nie jest pracownikiem!", "Niedodano dyżuru", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void UsunDyzur()
        {
            if (_wybranyUzytkownik is Pracownik pracownik)
            {
                pracownik.ListaDyzurow.Remove(_wybranyDyzur);
                _listaDyzurowDataGrid.Items.Refresh();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
