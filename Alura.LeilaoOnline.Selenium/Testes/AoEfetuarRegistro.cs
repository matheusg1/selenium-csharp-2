using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario("math", "mat@email.com", "adm", "adm");

            //Act
            registroPO.SubmeteFormulario();

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
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheFormulario(nome, email, password, confirmPassword);

            //Act
            registroPO.SubmeteFormulario();            

            //Assert
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoMostrarMensagemDeErro()
        {
            //Arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //Act
            registroPO.SubmeteFormulario();

            //Assert            
            Assert.False(string.IsNullOrEmpty(registroPO.NomeMensagemErro));
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //Arrange
            var registroPO = new RegistroPO(driver);

            registroPO.Visitar();            

            //Act
            registroPO.SubmeteFormulario();            

            //Assert                        
            Assert.Equal("The Endereço de Email field is required.", registroPO.EmailMensagemErro);
        }
    }
}
