using Console.Services;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class ConsoleAppUnitTests
    {
        private readonly Mock<IWebService> _webServcieMock;
        private readonly Console.Application.ConsoleApp _consoleApp;

        [TestMethod]
        public void ConsoleAppNullResponse()
        {
            _webServcieMock.Setup(m => m.Data()).Returns((Class1)null);

            _consoleApp.Run(null);

            Assert.AreEqual("null", "null");
        }

        [TestMethod]
        public void ConsoleAppNotNullResponse()
        {
            string response = "Hello World";
            var data = new Class1 { Data = response };

            _webServcieMock.Setup(m => m.Data()).Returns(data);

            _consoleApp.Run(null);

            Assert.AreEqual("Hello World", response);
        }
    }
}
