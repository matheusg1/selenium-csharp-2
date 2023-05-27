﻿using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            
            //Act
            loginPO.SubmeteFormulario();

            //Assert
            Assert.Contains("Dashboard", driver.Title);
        }

        [Fact]
        public void DadoCredenciaisValidasDeveContinuarNoLogin()
        {
            //Arrange
            var loginPO = new LoginPO(driver);

            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "");

            //Act
            loginPO.SubmeteFormulario();

            //Assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}
