using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPriceDemo
{
    public  class Column : INotifyPropertyChanged
    {
        public Column()
        { }
        public Column(string data, bool isChecked = false,bool isEnabled = true)
        {
            Data = data;
            IsChecked = isChecked;
            IsEnabled = isEnabled;
        }
        

        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                OnIsCheckedPropertyChanged(nameof(IsChecked));
            }
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                OnIsEnabledPropertyChanged(nameof(IsEnabled));
            }
        }


        protected string data;

        protected bool isChecked;

        protected bool isEnabled;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnIsCheckedPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }

        public void OnIsEnabledPropertyChanged(string name)
        {
            //TODO: Endless
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
