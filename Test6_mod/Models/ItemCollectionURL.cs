using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6_mod.Models
{
    public delegate void AddURL(string column, string changed);
    public delegate void TaskAdd(string id);

    public class ItemCollectionURL : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static AddURL ThisChanged;
  
        #region Приватные переменные
        public static bool _IsInitialization;
        private string _Name;
        private string _URL;
        private bool _Status;
        #endregion

        #region Публичные поля
        public string IsName
        {
            get { return _Name; }
            set
            {
                if (_Name == value)
                    return;
                _Name = value;
                if (!_IsInitialization)
                    OnPropertyChanged("Name");
            }
        }
        public string IsURL
        {
            get { return _URL; }
            set
            {
                if (_URL == value)
                    return;
                _URL = value;
                if (!_IsInitialization)
                    OnPropertyChanged("URL");
            }
        }
        public bool IsStatus
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
                case "Name":
                    ThisChanged?.Invoke(propertyName, IsName);
                    break;

                case "URL":
                    ThisChanged?.Invoke(propertyName, IsURL);
                    break;

                case "Status":
                    ThisChanged?.Invoke(propertyName, IsStatus.ToString());
                    break;

            }
        }
    }
}