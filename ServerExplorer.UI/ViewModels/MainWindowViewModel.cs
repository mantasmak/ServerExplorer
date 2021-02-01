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
using ServerExplorer.Services.Interfaces;

namespace ServerExplorer.UI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string Username { private get; set; }

        public string Password { private get; set; }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    RaisePropertyChanged(() => ErrorMessage);
                }
            }
        }

        public ICommand DownloadCommand{ get; private set;}

        private IServerService _serverService;

        public ObservableCollection<Server> ServerList { get; set; }

        public MainWindowViewModel(IServerService serverService)
        {
            DownloadCommand = new DelegateCommand(DonwloadData, CanDonwloadData);

            ServerList = new ObservableCollection<Server>();

            _serverService = serverService;
        }

        private bool CanDonwloadData()
        {
            return !(String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password));
        }

        private async void DonwloadData()
        {
            ErrorMessage = "";

            if(!InternetConnection.CheckForInternetConnection())
            {
                ErrorMessage = "Check your internet connection";
                return;
            }

            if (!await _serverService.UpdateDatabase(Username, Password))
            {
                ErrorMessage = "Wrong Username or Password";
                return;
            }

            var servers = _serverService.GetServers();
            if(servers == null || !servers.Any())
            {
                ErrorMessage = "Database is empty";
            }

            ServerList.Clear();

            foreach(var server in servers)
                ServerList.Add(new Server() { Name = server.Name, Distance = server.Distance });
        }
    }
}
