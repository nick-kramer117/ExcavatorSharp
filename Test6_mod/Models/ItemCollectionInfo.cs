using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace Test6_mod.Models
{
    public delegate void AddLogInfo(string column, string changed);
    public delegate void AddId(long id);


    public class ItemCollectionInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public static AddLogInfo ThisChanged;
        public static AddId AddNewRow;

        #region Приватные переменные
        public static bool _IsInitialization;
        private long _Id;
        private string _Coment;
        private string _Status;
        #endregion

        #region Публичные поля
        public long IsId
        {
            get { return _Id; }
            set
            {
                if (_Id == value)
                    return;
                _Id = value;
                if (!_IsInitialization)
                    OnPropertyChanged("Id");
            }
        }
        public string IsComent
        {
            get { return _Coment; }
            set
            {
                if (_Coment == value)
                    return;
                _Coment = value;
                if (!_IsInitialization)
                    OnPropertyChanged("Coment");
            }
        }
        public string IsStatus
        {
            get { return _Status; }
            set
            {
                if (_Status == value)
                    return;
                _Status = value;
                if (!_IsInitialization)
                    OnPropertyChanged("Status");
            }
        }
        #endregion

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            switch (propertyName)
            {
                case "Id":
                    AddNewRow?.Invoke(IsId);
                    break;

                case "Coment":
                    ThisChanged?.Invoke(propertyName, IsComent);
                    break;

                case "Status":
                    ThisChanged?.Invoke(propertyName, IsStatus.ToString());
                    break;

            }
        }
    }
}