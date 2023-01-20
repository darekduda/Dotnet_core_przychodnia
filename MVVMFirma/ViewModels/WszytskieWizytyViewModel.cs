using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszytskieWizytyViewModel : WszystkieViewModel<WizytyForAllView>
    {
        public WszytskieWizytyViewModel()
            : base()
        {
            base.DisplayName = "Wizyty";

        }

      
        #region Helpers
        //metoda load pobierze z bazy wszystkie towary i przypisze je do listy 
        public override void load()
        {
            //za pomocą obiektu reprezentującego całą bazę danych o nazwie fakturyEntities pobieram wszystkie 
            //rekordy z tabeli Towary i zamieniam je na ObservableCollection
            List = new ObservableCollection<WizytyForAllView>
                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from wizyta in gabinetEntities.Wizyta //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                            //fakture for all view
                    select new WizytyForAllView
                    {
                        IDWizyty = wizyta.IDWizyty,
                        PacjentImieNazwisko = wizyta.Pacjent.Imie + " " + wizyta.Pacjent.Nazwisko,
                        DataWizyty = wizyta.DataWizyty,
                        GodzinaWizyty=wizyta.GodzinaWizyty,
                        RodzajWizyty=wizyta.RodzajWizyty.Nazwa,
                        EWizyta = wizyta.EWizyta.Nazwa,
                        TypWizyty = wizyta.TypWizyty.Nazwa,
                        Skierowanie = wizyta.Skierowanie.Nazwa
    }
                );
        }
        #endregion Helpers
        #region Sort and Find

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imię i nazwisko", "Data wizyty", "Rodzaj wizyty", "Typ wizyty", "Skierowanie" };

        }

        public override void Sort()
        {
            if (SortField == "Imię i nazwisko")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.PacjentImieNazwisko));
            if (SortField == "Data wizyty")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.DataWizyty));
            if (SortField == "Rodzaj wizyty")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.RodzajWizyty));
            if (SortField == "Typ wizyty")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.TypWizyty));
            if (SortField == "Skierowanie")
                List = new ObservableCollection<WizytyForAllView>(List.OrderBy(item => item.Skierowanie));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię i nazwisko", "Typ wizyty" };
        }

        public override void Find()
        {
            if (FindField == "Imię i nazwisko")
                List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.PacjentImieNazwisko != null && item.PacjentImieNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Typ wizyty")
                List = new ObservableCollection<WizytyForAllView>(List.Where(item => item.TypWizyty != null && item.TypWizyty.StartsWith(FindTextBox)));
        }

        public override void del()
        {
            WizytyForAllView wizytaSelectedListItem = List.Single(item => item.IDWizyty == SelectedItem.IDWizyty); // znajdz jeden element f listy List,
            Wizyta wizyta = gabinetEntities.Wizyta.Single(item => item.IDWizyty == wizytaSelectedListItem.IDWizyty);
            gabinetEntities.Wizyta.Remove(wizyta); // usuwa z bazy
            gabinetEntities.SaveChanges();
            List.Remove(wizytaSelectedListItem); // usuwa z listy na widoku
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}