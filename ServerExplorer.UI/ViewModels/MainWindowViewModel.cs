using ServerExplorer.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using ServerExplorer.UI.Models;
using System.Security;

namespace ServerExplorer.UI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string Username { private get; set; }

        public string Password { private get; set; }

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged(() => Message);
                }
            }
        }

        public ICommand DownloadCommand{ get; private set;}

        public ObservableCollection<Server> ServerList { get; set; }

        public MainWindowViewModel()
        {
            DownloadCommand = new DelegateCommand(DonwloadData);

            ServerList = new ObservableCollection<Server>();/*
            ServerList.Add(new Server() { Name = "First", Distance = 123 });
            ServerList.Add(new Server() { Name = "Second", Distance = 456 });
            ServerList.Add(new Server() { Name = "Third", Distance = 2651462 });*/
        }

        private void DonwloadData()
        {
            ServerList.Add(new Server() { Name = Username, Distance = Password});
        }
    }
}
