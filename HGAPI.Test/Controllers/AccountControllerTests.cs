using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using EdusvKids.WebUI.Controllers; 
using HGAPI.DTOs.UserPlayerDTOs;
using System;
using Microsoft.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace HGAPI.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTests
    {
        private AccountController _controller;
        private Mock<IHttpClientFactory> _httpClientFactoryMock;

        [TestInitialize]
        public void Initialize()
        {
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _controller = new AccountController(_httpClientFactoryMock.Object);
        }

        [TestMethod]
        public void SignIn_Get_ReturnsView()
        {
            var expectedModel = new UserLoginInputDTO();

            var result = _controller.SignIn() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedModel, result.Model);
        }

        [TestMethod]
        public async Task SignIn_Post_ValidUser_ReturnsRedirectToAction()
        {
            var userLogin = new UserLoginInputDTO();
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            _httpClientFactoryMock.Setup(factory => factory.CreateClient("API")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = await _controller.SignIn(userLogin) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
        }

        [TestMethod]
        public async Task SignIn_Post_InvalidUser_ReturnsView()
        {
            var userLogin = new UserLoginInputDTO();
            var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);

            _httpClientFactoryMock.Setup(factory => factory.CreateClient("API")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = await _controller.SignIn(userLogin) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(userLogin, result.Model);
        }
        [TestMethod]
        public void SignUp_Get_ReturnsView()
        {
            var expectedModel = new CreateUserPlayerDTO();

            var result = _controller.SignUp() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedModel, result.Model);
        }

        [TestMethod]
        public async Task SignUp_Post_ValidUser_ReturnsRedirectToAction()
        {
            var user = new CreateUserPlayerDTO();
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);

            _httpClientFactoryMock.Setup(factory => factory.CreateClient("API")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = await _controller.SignUp(user) as RedirectToActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
        }

        [TestMethod]
        public async Task SignUp_Post_InvalidUser_ReturnsView()
        {
            var user = new CreateUserPlayerDTO();
            var responseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);

            _httpClientFactoryMock.Setup(factory => factory.CreateClient("API")).Returns(new HttpClient(new Mock<HttpMessageHandler>().Object));
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();

            var result = await _controller.SignUp(user) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(user, result.Model);
        }

    }
}
