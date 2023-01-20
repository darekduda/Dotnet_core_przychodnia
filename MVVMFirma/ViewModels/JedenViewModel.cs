using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        protected GabinetEntities4 gabinetEntities;
        protected T item; // to jest towar który bedziemy dodawac
        private BaseCommand _SaveCommand; // to jest komenda to zapisu towaru
        private BaseCommand _AddCommand;
        public JedenViewModel()
            : base()
        {
            gabinetEntities = new GabinetEntities4(); // tworze polaczenie z baza danych
        }
        //to jest komenda która zostanie podpięta pod przycisk zapisz i ta komenda wywoła metodę saveAndClose
        //która będzie zdefiniowana niżej
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveCommand;
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
        #region Validation
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion

        public abstract void Save();

        private void add()
        {
            //za pomocą messengera z biblioteki MvvmLight wyślemy do MainWindowViewModel stringa z poleceniem otwarcie okna
            Messenger.Default.Send(DisplayName + "Add"); //nie działa przez to ze nie mam wtyczki

        }
        private void saveAndClose()
        {
            if (IsValid())
            {
                //zapisujemy obiekt
                Save();
                //zamykamy zakladke
                base.OnRequestClose();
            }
            else
            {
                ShowMessageBox("Popraw błędy");
            }
        }
    }
}
