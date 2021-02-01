using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;


namespace Test6_mod.Models
{
    //public delegate void TaskChang(string column, string changed, string id);
    //public delegate void NameChang(string changed, string id);
    //public delegate void TaskAdd(string id);

    //public class LogInfo : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    public static TaskChang ThisChanged;
    //    public static TaskAdd AddNewRow;
    //    public static NameChang Rename;

    //    #region Приватные переменные
    //    public static bool _IsInitialization;
    //    private string _Id;
    //    private string _Coment;
    //    private bool _Status;
    //    #endregion

    //    #region Публичные поля
    //    public string IsId
    //    {
    //        get { return _Id; }
    //        set
    //        {
    //            if (_Id == value)
    //                return;
    //            _Id = value;
    //            if (!_IsInitialization)
    //                OnPropertyChanged("Id");
    //        }
    //    }
    //    public string IsComent
    //    {
    //        get { return _Coment; }
    //        set
    //        {
    //            if (_Coment == value)
    //                return;
    //            _Coment = value;
    //            if (!_IsInitialization)
    //                OnPropertyChanged("Coment");
    //        }
    //    }
    //    public bool IsStatus
    //    {
    //        get { return _Status; }
    //        set
    //        {
    //            if (_Status == value)
    //                return;
    //            _Status = value;
    //            if (!_IsInitialization)
    //                OnPropertyChanged("Status");
    //        }
    //    }
    //    #endregion

    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //        switch (propertyName)
    //        {
    //            case "Id":
    //                AddNewRow(IsId);
    //                break;

    //            case "Coment":
    //                ThisChanged?.Invoke(propertyName, IsComent, IsId);
    //                break;

    //            case "Status":
    //                ThisChanged?.Invoke(propertyName, IsStatus.ToString(), IsId);
    //                break;

    //        }
    //    }
    //}
}