using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YuiMvvm.Models
{
    public class Menu : ObservableObject
    {
        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (!ReferenceEquals(_displayName, value))
                {
                    _displayName = value;
                    RaisePropertyChanged("DisplayName");
                }
            }
        }
        private int _sortIndex;

        public int SortIndex
        {
            get { return _sortIndex; }
            set
            {
                if (!ReferenceEquals(_sortIndex, value))
                {
                    _sortIndex = value;
                    RaisePropertyChanged("SortIndex");
                }
            }
        }

        private bool _isChecked = true;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (!ReferenceEquals(_isChecked, value))
                {
                    _isChecked = value;
                    RaisePropertyChanged("IsChecked");
                }
            }
        }
        
    }
}
