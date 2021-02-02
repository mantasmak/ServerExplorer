using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject.Extensions.Logging;
using ServerExplorer.Domain.Entities;
using ServerExplorer.Infrastructure.Interfaces;
using ServerExplorer.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerExplorer.Services.Services.Tests
{
    [TestClass()]
    public class ServerServiceTests
    {
        Mock<IServerWebService> _serverWebServiceMock;
        Mock<IServerRepository> _serverRepositoryMock;
        Mock<ILogger> _loggerMock;
        ServerService _serverService;

        public ServerServiceTests()
        {
            _serverWebServiceMock = new Mock<IServerWebService>();
            _serverRepositoryMock = new Mock<IServerRepository>();
            _loggerMock = new Mock<ILogger>();
            _serverService = new ServerService(_serverWebServiceMock.Object, _serverRepositoryMock.Object, _loggerMock.Object);
        }

        [TestMethod()]
        public async Task UpdateDatabase_WebServiceReturnsNull_False()
        {
            _serverWebServiceMock.Setup(s => s.GetServersAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<IEnumerable<Server>>(null));

            var result = await _serverService.UpdateDatabaseAsync(It.IsAny<string>(), It.IsAny<string>());

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public async Task UpdateDatabase_WebServiceReturnsEmptyList_False()
        {
            _serverWebServiceMock.Setup(s => s.GetServersAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<IEnumerable<Server>>(new List<Server>()));

            var result = await _serverService.UpdateDatabaseAsync(It.IsAny<string>(), It.IsAny<string>());

            Assert.IsFalse(result);
        }

        [TestMethod()]
        public async Task UpdateDatabase_WebServiceReturnsNonEmptyList_True()
        {
            _serverWebServiceMock.Setup(s => s.GetServersAsync(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult<IEnumerable<Server>>(new List<Server>()
                {
                    new Server()
                }
                ));

            var result = await _serverService.UpdateDatabaseAsync(It.IsAny<string>(), It.IsAny<string>());

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void GetServers_ServerRepositoryReturnsNull_Null()
        {
            _serverRepositoryMock.Setup(s => s.GetAllOrderedByDescendingDistance())
                .Returns((IEnumerable<Server>) null);
            
            var result = _serverService.GetServers();

            Assert.IsNull(result);
        }

        [TestMethod()]
        public void GetServers_ServerRepositoryReturnsEmptyList_Null()
        {
            _serverRepositoryMock.Setup(s => s.GetAllOrderedByDescendingDistance())
                .Returns(new List<Server>());

            var result = _serverService.GetServers();

            Assert.IsNull(result);
        }

        [TestMethod()]
        public void GetServers_ServerRepositoryReturnsNonEmptyList_ReturnsList()
        {
            _serverRepositoryMock.Setup(s => s.GetAllOrderedByDescendingDistance())
                .Returns(new List<Server>()
                {
                    new Server()
                });

            var result = _serverService.GetServers();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Server>));
        }
    }
}