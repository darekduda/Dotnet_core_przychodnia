using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //to jest klasa pomocnicza ktora decyduje o zawartosci okna MainWindow
        #region Fields
        //to jest kolekcja elementow menu okna lewego
        private ReadOnlyCollection<CommandViewModel> _Commands;
        //to jest kolekcja wszytskich zakladek projektu
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion
        #region Commands
        //to jest komenda która zostanie podpięta pod menu i pasek narzędzi
        // Komenda ta otwiera nową zakładkę z towarem
        private BaseCommand _NowyKontrahentCommand;
        private BaseCommand _NowaFakturaCommand;
        private BaseCommand _WszyscyKontrahenciCommand;
        private BaseCommand _WszystkieFakturyCommand;
        private BaseCommand _WszystkieKrajeCommand;
        private BaseCommand _WszystkieOddzialyCommand;
        private BaseCommand _WszystkieSposobyPlatnosciCommand;
        private BaseCommand _WszystkieStatusyCommand;
        private BaseCommand _UstawieniaCommand;
        private BaseCommand _WszystkieTypyWizytCommand;
        private BaseCommand _WszystkieUslugiCommand;
        private BaseCommand _WszystkieUslugiKontrahentaCommand;
        private BaseCommand _WszyscyPracownicyCommand;
        private BaseCommand _NowyAdresCommand;
        private BaseCommand _NowyPacjentCommand;
        private BaseCommand _WszyscyPacjenciCommand;
        private BaseCommand _NowaWizytaCommand;
        private BaseCommand _WszystkieWizytyCommand;
        private BaseCommand _WszystkieAdresyCommand;
        private BaseCommand _NowyKrajCommand;
        private BaseCommand _ZmienHasloCommand;

        public ICommand NowyKontrahentCommand
        {
            get
            {
                if (_NowyKontrahentCommand == null)
                    _NowyKontrahentCommand = new BaseCommand(() => CreateView(new NowyKontrahentViewModel())); //Komenda ta wywołuje metode CreateTowar
                return _NowyKontrahentCommand;
            }
        }
        public ICommand NowaFakturaCommand
        {
            get
            {
                if (_NowaFakturaCommand == null)
                    _NowaFakturaCommand = new BaseCommand(() => CreateView(new NowaFakturaViewModel())); //Komenda ta wywołuje metode CreateTowar
                return _NowaFakturaCommand;
            }
        }
        public ICommand NowyKrajCommand
        {
            get
            {
                if (_NowyKrajCommand == null)
                    _NowyKrajCommand = new BaseCommand(() => CreateView(new NowyKrajViewModel())); //Komenda ta wywołuje metode CreateTowar
                return _NowyKrajCommand;
            }
        }
        public ICommand WszyscyKontrahenciCommand
        {
            get
            {
                if (_WszyscyKontrahenciCommand == null)
                    _WszyscyKontrahenciCommand =
                        new BaseCommand(() => ShowAllKontrahent()); //Komenda ta wywołuje metode CreateTowar
                return _WszyscyKontrahenciCommand;
            }
        }
        public ICommand WszystkieFakturyCommand
        {
            get
            {
                if (_WszystkieFakturyCommand == null)
                    _WszystkieFakturyCommand =
                        new BaseCommand(() => ShowAllFaktura()); //Komenda ta wywołuje metode CreateTowar
                return _WszystkieFakturyCommand;
            }
        }
        public ICommand WszystkieAdresyCommand
        {
            get
            {
                if (_WszystkieAdresyCommand == null)
                    _WszystkieAdresyCommand =
                        new BaseCommand(() => ShowAllAdres()); //Komenda ta wywołuje metode CreateTowar
                return _WszystkieAdresyCommand;
            }
        }
        public ICommand WszystkieKrajeCommand
        {
            get
            {
                if (_WszystkieKrajeCommand == null)
                    _WszystkieKrajeCommand =
                        new BaseCommand(() => ShowAllKraj()); //Komenda ta wywołuje metode CreateTowar
                return _WszystkieKrajeCommand;
            }
        }
        public ICommand NowyPacjentCommand
        {
            get
            {
                if (_NowyPacjentCommand == null)
                    _NowyPacjentCommand = new BaseCommand(() => CreateView(new NowyPacjentViewModel())); //Komenda ta wywołuje metode CreateTowar
                return _NowyPacjentCommand;
            }
        }
        public ICommand NowyAdresCommand
        {
            get
            {
                if (_NowyAdresCommand == null)
                    _NowyAdresCommand = new BaseCommand(() => CreateView(new NowyAdresViewModel())); //Komenda ta wywołuje metode CreateTowar
                return _NowyAdresCommand;
            }
        }
        public ICommand NowaWizytaCommand
        {
            get
            {
                if (_NowaWizytaCommand == null)
                    _NowaWizytaCommand = new BaseCommand(() => CreateView(new NowaWizytaViewModel())); //Komenda ta wywołuje metode CreateTowar
                return _NowaWizytaCommand;
            }
        }
        public ICommand WszystkieWizytyCommand
        {
            get
            {
                if (_WszystkieWizytyCommand == null)
                    _WszystkieWizytyCommand =
                        new BaseCommand(() => ShowAllWizyta()); //Komenda ta wywołuje metode CreateTowar
                return _WszystkieWizytyCommand;
            }
        }
        public ICommand WszyscyPacjenciCommand
        {
            get
            {
                if (_WszyscyPacjenciCommand == null)
                    _WszyscyPacjenciCommand =
                        new BaseCommand(() => ShowAllPacjent()); //Komenda ta wywołuje metode CreateTowar
                return _WszyscyPacjenciCommand;
            }
        }
        public ICommand UstawieniaCommand
        {
            get
            {
                if (_UstawieniaCommand == null)
                    _UstawieniaCommand =
                        new BaseCommand(() => ShowAllUstawienia()); //Komenda ta wywołuje metode CreateTowar
                return _UstawieniaCommand;
            }
        }
        public ICommand ZmienHasloCommand
        {
            get
            {
                if (_ZmienHasloCommand == null)
                    _ZmienHasloCommand =
                        new BaseCommand(() => ShowAllZmienHaslo()); //Komenda ta wywołuje metode CreateTowar
                return _ZmienHasloCommand;
            }
        }
        public ICommand WszystkieOddzialyCommand
        {
            get
            {
                if (_WszystkieOddzialyCommand == null)
                    _WszystkieOddzialyCommand =
                        new BaseCommand(() => ShowAllOddzial()); //Komenda ta wywołuje metode CreateTowar
                return _WszystkieOddzialyCommand;
            }
        }
        public ICommand WszystkieSposobyPlatnosciCommand
        {
            get
            {
                if (_WszystkieSposobyPlatnosciCommand == null)
                    _WszystkieSposobyPlatnosciCommand =
                        new BaseCommand(() => ShowAllSposobPlatnosci()); //Komenda ta wywołuje metode CreateTowar
                return _WszystkieSposobyPlatnosciCommand;
            }
        }
        public ICommand WszystkieStatusyCommand
        {
            get
            {
                if (_WszystkieStatusyCommand == null)
                    _WszystkieStatusyCommand =
                        new BaseCommand(() => ShowAllStatusPacjenta()); //Komenda ta wywołuje metode CreateTowar
                return _WszystkieStatusyCommand;
            }
        }
        public ICommand WszystkieTypyWizytCommand
        {
            get
            {
                if (_WszystkieTypyWizytCommand == null)
                    _WszystkieTypyWizytCommand =
                        new BaseCommand(() => ShowAllTypWizyty()); //Komenda ta wywołuje metode CreateTowar
                return _WszystkieTypyWizytCommand;
            }
        }
        public ICommand WszystkieUslugiCommand
        {
            get
            {
                if (_WszystkieUslugiCommand == null)
                    _WszystkieUslugiCommand =
                        new BaseCommand(() => ShowAllUsluga()); //Komenda ta wywołuje metode CreateTowar
                return _WszystkieUslugiCommand;
            }
        }
        public ICommand WszystkieUslugiKontrahentaCommand
        {
            get
            {
                if (_WszystkieUslugiKontrahentaCommand == null)
                    _WszystkieUslugiKontrahentaCommand =
                        new BaseCommand(() => ShowAllUslugaKontrahent()); //Komenda ta wywołuje metode CreateTowar
                return _WszystkieUslugiKontrahentaCommand;
            }
        }
        public ICommand WszyscyPracownicyCommand
        {
            get
            {
                if (_WszyscyPracownicyCommand == null)
                    _WszyscyPracownicyCommand =
                        new BaseCommand(() => ShowAllPracownik()); //Komenda ta wywołuje metode CreateTowar
                return _WszyscyPracownicyCommand;
            }
        }
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Pacjent ",
                    new BaseCommand(() => this.CreatePacjent())),
                new CommandViewModel(
                    "Pacjenci ",
                    new BaseCommand(() => this.ShowAllPacjent())),
                new CommandViewModel(
                    "Kontrahnet ",
                    new BaseCommand(() => this.CreateKontrahent())),
                 new CommandViewModel(
                    "Kontrahenci ",
                    new BaseCommand(() => this.ShowAllKontrahent())),
                new CommandViewModel(
                    "Wizyta ",
                    new BaseCommand(() => this.CreateWizyta())),
                new CommandViewModel(
                    "Wizyty ",
                    new BaseCommand(() => this.ShowAllWizyta())),    
                new CommandViewModel(
                    "Faktura ",
                    new BaseCommand(() => this.CreateFaktura())),
                new CommandViewModel(
                    "Faktury ",
                    new BaseCommand(() => this.ShowAllFaktura())),
                new CommandViewModel(
                    "Raport Wizyt",
                    new BaseCommand(() => this.CreateView(new RaportSprzedazyViewModel()))),
                new CommandViewModel(
                    "Raport Pacjentów",
                    new BaseCommand(() => this.CreateView(new RaportPacjentowViewModel()))),
                new CommandViewModel(
                    "Raport Usług",
                    new BaseCommand(() => this.CreateView(new RaportUslugViewModel()))),
            };
        }
        #endregion
        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces
        #region Private Helpers
        private void open(string name)
        {
            if (name == "Wszystkie fakturyAdd")
                this.CreateView(new NowaFakturaViewModel());
            if (name == "PacjentAdd")
                this.CreateView(new NowyAdresViewModel());
            if (name == "PacjenciAdd")
                this.CreateView(new NowyPacjentViewModel());
            if (name == "WizytyAdd")
                this.CreateView(new NowaWizytaViewModel());
            if (name == "KontrahenciAdd")
                this.CreateView(new NowyKontrahentViewModel());
            if (name == "Adresy Show")
                this.ShowAllAdres();
            if (name == "Wszyscy kontrahenciShow")
            this.ShowAllKontrahent();
            if (name == "Pozycje fakturyAdd")
                this.CreateView(new NowaPozycjaFakturyViewModel());
            if (name == "Wszystkie krajeAdd")
                this.CreateView(new NowyKrajViewModel());
            if (name == "Wszystkie oddziały NFZAdd")
                this.CreateView(new NowyOddzialViewModel());
            if (name == "Wszystkie sposoby płatnościAdd")
                this.CreateView(new NowySposobPlatnosciViewModel());
            if (name == "Wszystkie statusy pacjentaAdd")
                this.CreateView(new NowyStatusPacjentaViewModel());
            if (name == "Typy wizytAdd")
                this.CreateView(new NowyTypWizytyViewModel());
            if (name == "UslugiAdd")
                this.CreateView(new NowaUslugaViewModel());
            if (name == "Usługi kontrahentaAdd")
                this.CreateView(new NowaUslugaKontrahentViewModel());
            if (name == "PracownicyAdd")
                this.CreateView(new NowyPracownikViewModel());
        }
        private void CreateView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        //to sa funkcje ktore wywoluja zakladki
        //ponizsza funkcja za kazdym razem wywoluje nowa zakladka
        private void CreateAdres()
        {
            NowyAdresViewModel workspace = new NowyAdresViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateKontrahent()
        {
            NowyKontrahentViewModel workspace = new NowyKontrahentViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreatePacjent()
        {
            NowyPacjentViewModel workspace = new NowyPacjentViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateWizyta()
        {
            NowaWizytaViewModel workspace = new NowaWizytaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateFaktura()
        {
            NowaFakturaViewModel workspace = new NowaFakturaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        //ponizsza funkcja najpierw sprawdza czy dana zakladka istnieje i jak istnieje to ha ponownie uaktywnia
        // a jak nie istnieje to tworzy nowa                    
        private void ShowAllPacjent()
        {
            WszyscyPacjenciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyPacjenciViewModel)
                as WszyscyPacjenciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPacjenciViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllAdres()
        {
            WszystkieAdresyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel)
                as WszystkieAdresyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllKontrahent()
        {
            WszyscyKontrahenciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyKontrahenciViewModel)
                    as WszyscyKontrahenciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKontrahenciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllWizyta()
        {
            WszytskieWizytyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszytskieWizytyViewModel)
                as WszytskieWizytyViewModel;
            if (workspace == null)
            {
                workspace = new WszytskieWizytyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllFaktura()
        {
            WszystkieFakturyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel)
                    as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllKraj()
        {
            WszystkieKrajeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieKrajeViewModel)
                as WszystkieKrajeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKrajeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllOddzial()
        {
            WszystkieOddzialyNFZViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieOddzialyNFZViewModel)
                as WszystkieOddzialyNFZViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieOddzialyNFZViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllSposobPlatnosci()
        {
            WszystkieSposobyPlatnosciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieSposobyPlatnosciViewModel)
                as WszystkieSposobyPlatnosciViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSposobyPlatnosciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllStatusPacjenta()
        {
            WszystkieStatusyPacjentaViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieStatusyPacjentaViewModel)
                as WszystkieStatusyPacjentaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStatusyPacjentaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllTypWizyty()
        {
            WszystkieTypyWizytViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieTypyWizytViewModel)
                as WszystkieTypyWizytViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyWizytViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllUsluga()
        {
            WszystkieUslugiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieUslugiViewModel)
                as WszystkieUslugiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieUslugiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllUslugaKontrahent()
        {
            WszystkieUslugiKontrahentaViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieUslugiKontrahentaViewModel)
                as WszystkieUslugiKontrahentaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieUslugiKontrahentaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPracownik()
        {
            WszyscyPracownicyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel)
                as WszyscyPracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPracownicyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllUstawienia()
        {
            UstawieniaViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is UstawieniaViewModel)
                    as UstawieniaViewModel;
            if (workspace == null)
            {
                workspace = new UstawieniaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllZmienHaslo()
        {
            ZmienHasloViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is ZmienHasloViewModel)
                    as ZmienHasloViewModel;
            if (workspace == null)
            {
                workspace = new ZmienHasloViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        //powyzsze dwie funkcje sa wywolywane w funkcji create command
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion
    }
}
