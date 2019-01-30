﻿using Caliburn.Micro;
using System.Windows;

namespace HelloCaliburn
{
    class ShellViewModel : PropertyChangedBase
    {
        string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanSayHello);
                NotifyOfPropertyChange(() => CanSayGoodbye);
            }
        }

        public bool CanSayHello
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        public bool CanSayGoodbye
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        public void SayHello()
        {
            MessageBox.Show(string.Format("Hello {0}!", Name)); //Don't do this in real life :)
        }
        public void SayGoodbye()
        {
            MessageBox.Show(string.Format("Goodbye {0}!", Name)); //Don't do this in real life :)
        }
    }
}
