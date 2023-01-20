using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NowaPozycjaFakturyViewModel : JedenViewModel<PozycjaFaktury>
    {
        #region Constructor
        public NowaPozycjaFakturyViewModel()
            : base()
        {
            base.DisplayName = "Pozycja faktury";
            item = new PozycjaFaktury();
        }
        #endregion Constructor
        #region Properties
        // dla każdego pola na interfejsie trzeba utworzyć propertisa zgodnie z poniższym wzorem
        public int? IDUslugi
        {
            get
            {
                return item.IDUslugi;
            }
            set
            {
                if (item.IDUslugi != value)
                {
                    item.IDUslugi = value;
                    base.OnPropertyChanged(() => IDUslugi);
                }
            }
        }
        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                if (item.Cena != value)
                {
                    item.Cena = value;
                    base.OnPropertyChanged(() => Cena);
                }
            }
        }
        public decimal? Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                if (item.Ilosc != value)
                {
                    item.Ilosc = value;
                    base.OnPropertyChanged(() => Ilosc);
                }
            }
        }
        public decimal? Rabat
        {
            get
            {
                return item.Rabat;
            }
            set
            {
                if (item.Rabat != value)
                {
                    item.Rabat = value;
                    base.OnPropertyChanged(() => Rabat);
                }
            }
        }
        #endregion Properties
        #region Helpers
        public override void Save()
        {
            Messenger.Default.Send<PozycjaFaktury>(item);
        }
        #endregion Helpers
    }
}
