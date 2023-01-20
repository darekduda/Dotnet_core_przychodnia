using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkieAdresyViewModel : WszystkieViewModel<AdresyForAllView>
    {

        #region Properties
        private AdresyForAllView _WybranyAdres;
        public AdresyForAllView WybranyAdres
        {
            get
            {
                return _WybranyAdres;
            }
            set
            {
                if (_WybranyAdres != value)
                {
                    _WybranyAdres = value;
                    //jak klikniemy w datagridzie na wybranego kontrhaneta to wywola się set WybranegoKontrahneta
                    //i należy tego kontrahenta messengerem wysłać do okna z nową fakturą 
                    Messenger.Default.Send(_WybranyAdres);
                    //po wybraniu kontrahenta zamykam oknno
                    OnRequestClose();
                }
            }
        }
        #endregion


        public WszystkieAdresyViewModel()
            :base()
        {
            base.DisplayName = "Adresy";
        }
        public override void load()
        {
            List = new ObservableCollection<AdresyForAllView>
                
                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from adres in gabinetEntities.Adres //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                            //fakture for all view
                    select new AdresyForAllView
                    {
                        IDAdresu = adres.IDAdresu,
                        Ulica = adres.Ulica,
                        NrDomu = adres.NrDomu,
                        NrLokalu = adres.NrLokalu,
                        KodPocztowy = adres.KodPocztowy,
                        Miasto = adres.Miasto,
                        WojewodztwoNazwa = adres.Wojewodztwo.Nazwa,
                        KrajNazwa = adres.Kraj.Nazwa,
                    }
                );
        }

        #region Sort and Find
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Ulica", "Miasto" };
        }

        public override void Find()
        {
            if (FindField == "Ulica")
                List = new ObservableCollection<AdresyForAllView>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
            if (FindField == "Miasto")
                List = new ObservableCollection<AdresyForAllView>(List.Where(item => item.Miasto != null && item.Miasto.StartsWith(FindTextBox)));
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Ulica", "Miasto", "Województwo", "Kraj"};

        }

        public override void Sort()
        {
            if (SortField == "Ulica")
                List = new ObservableCollection<AdresyForAllView>(List.OrderBy(item => item.Ulica));
            if (SortField == "Miasto")
                List = new ObservableCollection<AdresyForAllView>(List.OrderBy(item => item.Miasto));
            if (SortField == "Województwo")
                List = new ObservableCollection<AdresyForAllView>(List.OrderBy(item => item.WojewodztwoNazwa));
            if (SortField == "Kraj")
                List = new ObservableCollection<AdresyForAllView>(List.OrderBy(item => item.KrajNazwa));
        }

        public override void del()
        {
            throw new NotImplementedException();
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
