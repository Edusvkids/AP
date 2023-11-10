using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EdusvKids.WebUI.Controllers;
using EdusvKids.WebUI.Models;
using System.Diagnostics;

namespace EdusvKids.WebUI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private ILogger<HomeController> _logger;

        [TestInitialize]
        public void Initialize()
        {
            _logger = new LoggerFactory().CreateLogger<HomeController>();
            _controller = new HomeController(_logger);
        }

        [TestMethod]
        public void Index_ReturnsViewResult()
        {
            var result = _controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Productos_ReturnsViewResult()
        {
            var result = _controller.Productos() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Monedas_ReturnsViewResult()
        {
            var result = _controller.Monedas() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Descargar_ReturnsViewResult()
        {
            var result = _controller.Descargar() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Pagar_ReturnsViewResult()
        {
            var result = _controller.Pagar() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Cuenta_ReturnsViewResult()
        {
            var result = _controller.Cuenta() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Crear_ReturnsViewResult()
        {
            var result = _controller.Crear() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Vida_ReturnsViewResult()
        {
            var result = _controller.Vida() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Inicio_ReturnsViewResult()
        {
            var result = _controller.Inicio() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Error_ReturnsViewResultWithModel()
        {
            var result = _controller.Error() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(ErrorViewModel));
        }
    }
}
