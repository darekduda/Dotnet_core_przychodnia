using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    // w klasie WszystkieViewModel będą znajdowały się te elementy które występuja w każdej klasie obsługującej 
    //dowolną kolekcję obiektów biznesowych
    //A zatem z klasy WszytskieViewModel będą dziedziczyły np. WszytskieTowaryViewModel, WszytskieZamowieniaViewModel,
    //WszyscyPracownicyViewModel
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        // to jest pole odpowiedzialne za połączenie z baza danych
        protected readonly GabinetEntities4 gabinetEntities;
        //to jest commenda która wywoła ładowanie wszytskich towarów z bazy danych
        private BaseCommand _LoadCommand;
        //to jest komenda do wywoływania zakładki do wywoływania 
        private BaseCommand _AddCommand;

        private ObservableCollection<T> _List;
        public T SelectedItem { get; set; }


        private BaseCommand _ModifyCommand;
        private BaseCommand _DeleteCommand;
        private BaseCommand _UpdateCommand;
        //to jest komenda która zostanie podpięta pod przycisk sortuj 
        private BaseCommand _SortCommand;
        //to jest komenda która zostanie podpięta pod przycisk szukaj w generic.xaml
        private BaseCommand _FindCommand;
        #endregion Fields
        #region Properties
        // ta komenda wywołuję metodę load
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }
                return _LoadCommand;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add());
                }
                return _AddCommand;
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                if (_UpdateCommand == null)
                {
                    _UpdateCommand = new BaseCommand(() => load());
                }
                return _UpdateCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new BaseCommand(() => del());
                }
                return _DeleteCommand;
            }
        }
        public abstract void del();

        public ICommand ModifyCommand
        {
            get
            {
                if (_ModifyCommand == null)
                {
                    _ModifyCommand = new BaseCommand(() => modify());
                }
                return _ModifyCommand;
            }
        }
        public abstract void modify();


        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) load(); // jezeli lista jest pusta, to wywolujemy metode load
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        //w tej właściwości zostanie zapisane po czym sortować 
        public string SortField { get; set; }
        //w tej właściwości zostanie podana lista elementów wzgledem ktorych zostanie podana lista po czym sortować
        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }

        // to jest komenda która zostanie podpięta pod przycisk sortuj
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());
                return _SortCommand;
            }
        }
        //w tej właściwości będziemy przechowywać wynik wyboru po czym wyszukiwac z comboboxa
        public string FindField { get; set; }
        //w tej właściwości będziemy pobierać wszytskie możliwości po których można wyszukiwać 
        //po to zeby cobobox wiedział po czym można wyszukiwać
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        //w tej właściwości będziemy przechowywać początek szukanej frazy
        public string FindTextBox { get; set; }
        //ta komenda będzie podpięta pod przycisk szukaj
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());
                return _FindCommand;
            }
        }
        #endregion Properties

        #region Constructor
        public WszystkieViewModel()
        {
            gabinetEntities = new GabinetEntities4();
        }
        #endregion Constructor
        #region Helpers
        //ta metoda będzie okrślała jak sortować w klassach dziedizczących
        public abstract void Sort();
        //ta metoda będzie mówiła po czym sortowac w klasach dziedziczących
        public abstract List<string> GetComboboxSortList();
        // ta metoda będzie mówiła  jak wyszukiwać
        public abstract void Find();
        //ta metoda określa po czym wyszukiwać i będzie zdefiniowana w klasach dziedziczących
        public abstract List<string> GetComboboxFindList();
        //metoda load pobierze z bazy wszystkie towary i przypisze je do listy 

        //metoda load pobierze z bazy wszystkie towary i przypisze je do listy 
        public abstract void load();

        protected void add()
        {
            //za pomocą messengera z biblioteki MvvmLight wyślemy do MainWindowViewModel stringa z poleceniem otwarcie okna
            Messenger.Default.Send(DisplayName + "Add"); 

        }
        #endregion Helpers
    }
}
