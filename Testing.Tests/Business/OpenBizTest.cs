using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Testing.Business;
using Testing.Domain.Interfaces.Business;
using Testing.Domain.Interfaces.DataAccess;
using Testing.Domain.Interfaces.Services;
using Testing.Domain.Models;

namespace Testing.Tests.Business
{
    [TestClass]
    public class OpenBizTest
    {
        private IOpenBiz openBiz;
        private Mock<IOpenService> openServiceMock;
        private Mock<IDiagnosticoDal> diagnosticoDalMock;
        private Mock<ISmpService> smpServiceMock;
        private Mock<IOutageService> outageServiceMock;
        private Mock<IDtbService> dtbServiceMock;

        [TestInitialize]
        public void Init()
        {
            openServiceMock = new Mock<IOpenService>();
            diagnosticoDalMock = new Mock<IDiagnosticoDal>();
            smpServiceMock = new Mock<ISmpService>();
            outageServiceMock = new Mock<IOutageService>();
            dtbServiceMock = new Mock<IDtbService>();

            openBiz = new OpenBiz(openServiceMock.Object, diagnosticoDalMock.Object, smpServiceMock.Object, outageServiceMock.Object, dtbServiceMock.Object);
        }

        [TestMethod]
        public void GetDiagnostic()
        {
            var data = new ResponseDataBase();
            diagnosticoDalMock.Setup(x => x.SaveInicioDiagnostico()).Returns(data);

            var response = openBiz.GetDiagnostic();

            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Count);
            diagnosticoDalMock.VerifyAll();
        }

    }
}
