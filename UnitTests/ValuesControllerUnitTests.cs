using Console.Services;
using Domain;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyHelloWorld.Controllers;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class ValuesControllerUnitTests
    {
        private readonly Mock<IDataService> _dataServiceMock;
        private readonly ValuesController _valuesController;

        [TestMethod]
        public void ValuesControllerSuccessResponse()
        {
            var expectedResult = new Class1 { Data = "Hello World" };

            _dataServiceMock.Setup(m => m.GetData()).Returns(expectedResult);

            var result = _valuesController.GetData();

            Assert.AreEqual(result.Data, expectedResult.Data);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ValuesControllerException()
        {
            _dataServiceMock.Setup(m => m.GetData()).Throws(new IOException("Error!"));
            _valuesController.GetData();
        }
    }
}
