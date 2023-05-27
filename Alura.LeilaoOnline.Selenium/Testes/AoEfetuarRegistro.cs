using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        public IWebDriver driver { get; set; }

        public AoEfetuarRegistro(TestFixture fixture)
        {
            this.driver = fixture.Driver;
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDeAgradecimento()
        {
            //Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            driver.FindElement(By.Id("Nome")).SendKeys("Matheus");
            driver.FindElement(By.Id("Email")).SendKeys("mat@email.com");
            driver.FindElement(By.Id("Password")).SendKeys("adm");
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("adm");

            //Act
            driver.FindElement(By.Id("btnRegistro")).Click();

            //Assert
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "", "", "")]
        [InlineData("", "mat@gmail.com", "mat", "mat")]
        [InlineData("mat", "", "mat", "mat")]
        [InlineData("mat", "mat@email.com", "", "mat")]
        [InlineData("mat", "mat@email.com", "mat", "")]
        [InlineData("mat", "mat", "mat", "mat")]
        [InlineData("mat", "mat", "mat", "mat2")]
        public void DadoInformacoesInvalidasDeveContinuarNaHome(string nome, string email, string password, string confirmPassword)
        {
            //Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            driver.FindElement(By.Id("Nome")).SendKeys(nome);
            driver.FindElement(By.Id("Email")).SendKeys(email);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmPassword);

            //Act
            driver.FindElement(By.Id("btnRegistro")).Click();

            //Assert
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoMostrarMensagemDeErro()
        {
            //Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");
            //driver.FindElement(By.Id("Nome")).SendKeys(string.Empty);

            //Act
            driver.FindElement(By.Id("btnRegistro")).Click();

            //Assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for='Nome']"));
            
            Assert.False(string.IsNullOrEmpty(elemento.Text));
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");            
            driver.FindElement(By.Id("Email")).SendKeys(string.Empty);

            //Act
            driver.FindElement(By.Id("btnRegistro")).Click();

            //Assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for='Email']"));
            
            Assert.Equal("The Endereço de Email field is required.", elemento.Text);
        }
    }
}
