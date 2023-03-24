using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using WebAppMVCPractice.Controllers;
using WebAppMVCPractice.Repository;
using Xunit;

namespace Tests
{
    public class ControllerTest
    {
        private List<Tenant> TestTenantsList()
        {
            var tenant = new List<Tenant>
            {
                new Tenant
                {
                    Id = Guid.NewGuid(),
                    Surn = "Ляпунов",
                    Name = "Ляпун",
                    Patr = "Ляпунович",
                    Email = "te.st@mail.ru",
                    Phone = "111333"
                },
                new Tenant
                {
                    Id = Guid.NewGuid(),
                    Surn = "Иванов",
                    Name = "Иван",
                    Patr = "Иванович",
                    Email = "te.st@gmail.com",
                    Phone = "123456"
                }
                
            };
            return tenant;
        }

        [Fact]
        public void TenantListReturnAViewResultWithAllTenants()
        {
            //Arrange
            var mock = new Mock<ITestRepository>();
            mock.Setup(testRepository => testRepository.GetTenants()).Returns(TestTenantsList());
            var controller = new HomeController(mock.Object);

            //Act
            var result = controller.TenantList();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Tenant>>(viewResult.Model);
            Assert.Equal(TestTenantsList().Count, model.Count());
        }

        [Fact]
        public void TenantBySurnReturnAViewResultWithTenants()
        {
            //Arrange
            string testSurn = TestTenantsList().First().Surn;
            var mock = new Mock<ITestRepository>();
            mock.Setup(testRepository => testRepository.GetTenantBySurn(testSurn)).Returns(TestTenantsList().Where(x => x.Surn.Contains(testSurn)).ToList());
            var controller = new HomeController(mock.Object);
            //Act
            var result = controller.TenantBySurn(testSurn);
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<List<Tenant>>(viewResult.ViewData.Model);
            Assert.Equal("Ляпунов", model.First().Surn);
            Assert.Equal("Ляпун", model.First().Name);
            Assert.Equal("Ляпунович", model.First().Patr);
            Assert.Equal("te.st@mail.ru", model.First().Email);
            Assert.Equal("111333", model.First().Phone);
        }

        [Fact]
        public void TenantCreateReturnAViewResultWithTenantModel()
        {
            var tenant = new Tenant()
            {
                Id = Guid.NewGuid(),
                Surn = "Ляпунов",
                Name = "Ляпун",
                Patr = "Ляпунович",
                Email = "te.st@mail.ru",
                Phone = "111333"
            };
            //Arrange
            var mock = new Mock<ITestRepository>();
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            mock.Setup(testRepository => testRepository.CreateTenant(tenant)).Returns(response);
            var controller = new HomeController(mock.Object);
            //Act
            var result = controller.TenantCreate(tenant);
            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("TenantList", redirectToActionResult.ActionName);
        }

        [Fact]
        public void TenantEditReturnAViewResultWithTenantModel()
        {
            var tenant = new Tenant()
            {
                Id = Guid.NewGuid(),
                Surn = "Ляпунов",
                Name = "Ляпун",
                Patr = "Ляпунович",
                Email = "te.st@mail.ru",
                Phone = "111333"
            };
            //Arrange
            var mock = new Mock<ITestRepository>();
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            mock.Setup(testRepository => testRepository.EditTenantPost(tenant)).Returns(response);
            var controller = new HomeController(mock.Object);
            //Act
            var result = controller.TenantEdit(tenant);
            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("TenantList", redirectToActionResult.ActionName);
        }

        [Fact]
        public void TenantDeleteReturnAViewResultWithTenantModel()
        {
            var tenant = new Tenant()
            {
                Id = Guid.NewGuid(),
                Surn = "Ляпунов",
                Name = "Ляпун",
                Patr = "Ляпунович",
                Email = "te.st@mail.ru",
                Phone = "111333"
            };
            //Arrange
            var mock = new Mock<ITestRepository>();
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            mock.Setup(testRepository => testRepository.DeleteTenant(tenant.Id)).Returns(response);
            var controller = new HomeController(mock.Object);
            //Act
            var result = controller.TenantDelete(tenant.Id);
            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("TenantList", redirectToActionResult.ActionName);
        }
    }
}
