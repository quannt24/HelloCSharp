using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMVVM.ViewModel
{
    class TextViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string DummyText
        {
            get {
                return dummyText;
            }
            set
            {
                dummyText = value;
            }
        }

        private string dummyText;

        public TextViewModel()
        {
            dummyText = "Dummy text";
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
