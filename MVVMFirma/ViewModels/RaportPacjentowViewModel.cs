using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class RaportPacjentowViewModel: WorkspaceViewModel
    {
        private GabinetEntities4 gabinetEntities;

        private DateTime _DataOd;
        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (value != _DataOd)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }
        private DateTime _DataDo;
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (value != _DataDo)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }
        private int _IDPacjenta;
        public int IDPacjenta
        {
            get
            {
                return _IDPacjenta;
            }
            set
            {
                if (value != _IDPacjenta)
                {
                    _IDPacjenta = value;
                    OnPropertyChanged(() => IDPacjenta);
                }
            }
        }

        public IQueryable<ComboBoxKeyAndValue> PacjentComboBoxItems
        {
            get
            {
                //
                return new PacjentB(gabinetEntities).GetPacjentComboBoxItems();
            }
        }

        private decimal? _LiczbaWizyt;
        public decimal? LiczbaWizyt
        {
            get
            {
                return _LiczbaWizyt;
            }
            set
            {
                if (value != _LiczbaWizyt)
                {
                    _LiczbaWizyt = value;
                    OnPropertyChanged(() => LiczbaWizyt);
                }
            }
        }

        public RaportPacjentowViewModel()
        {
            base.DisplayName = "Raport Pacjentów";
            gabinetEntities = new GabinetEntities4();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            LiczbaWizyt = 0;
        }

        #region Commands
        //
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => obliczLiczbeWizytClick());
                }
                return _ObliczCommand;
            }
        }
        #endregion
        #region Helpers
        private void obliczLiczbeWizytClick()
        {
            //to jest 
            LiczbaWizyt = new PacjentWizyty(gabinetEntities).WizytyPacjenta(IDPacjenta, DataOd, DataDo);
        }
        #endregion
    }
}
