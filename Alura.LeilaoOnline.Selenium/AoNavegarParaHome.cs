using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    public class AoNavegarParaHome : IDisposable
    {
        IWebDriver driver;

        //Setup
        public AoNavegarParaHome()
        {
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostarLeiloesNoTitulo()
        {
            //Arrange            

            //Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //Assert
            Assert.Contains("Leil�es", driver.Title);

        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //Arrange            

            //Act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //Assert
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);
        }

        public void Dispose()
        {
            driver.Quit();         
        }
    }
}
