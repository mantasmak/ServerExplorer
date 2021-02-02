using ServerExplorer.UI.Helpers;
using System;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ServerExplorer.UI.Models;
using ServerExplorer.Services.Interfaces;
using Ninject.Extensions.Logging;

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

        private readonly IServerService _serverService;

        private readonly ILogger _logger;

        public ObservableCollection<Server> ServerList { get; set; }

        public MainWindowViewModel(IServerService serverService, ILogger logger)
        {
            DownloadCommand = new DelegateCommand(DonwloadData, CanDonwloadData);

            ServerList = new ObservableCollection<Server>();

            _serverService = serverService;

            _logger = logger;
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
                _logger.Warn("There is no internet connection");
                ErrorMessage = "Check your internet connection";
                return;
            }

            if (!await _serverService.UpdateDatabaseAsync(Username, Password))
            {
                ErrorMessage = "Wrong Username or Password";
                return;
            }

            var servers = _serverService.GetServers();
            if(servers == null || !servers.Any())
            {
                ErrorMessage = "Database is empty";
                return;
            }

            ServerList.Clear();

            foreach(var server in servers)
                ServerList.Add(new Server() { Name = server.Name, Distance = server.Distance });
        }
    }
}
