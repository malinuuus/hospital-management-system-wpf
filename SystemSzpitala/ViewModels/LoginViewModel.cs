using SystemSzpitala.Models;
using BibliotekaKlas;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SystemSzpitala.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _login;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Haslo { private get; set; }
        
        public bool SprobujZalogowac(out Uzytkownik zalogowanyUzytkownik)
        {
            foreach (var uzytkownik in Uzytkownicy.ListaUzytkownikow)
            {
                if (uzytkownik.NazwaUzytkownika == _login && uzytkownik.Haslo == Haslo)
                {
                    zalogowanyUzytkownik = uzytkownik;
                    return true;
                }
            }

            zalogowanyUzytkownik = null;
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
