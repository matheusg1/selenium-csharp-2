using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {
        private IWebDriver driver;
        private By byFormRegistro;
        private By byInputNome;
        private By byInputEmail;
        private By byInputSenha;
        private By byInputConfirmacaoSenha;
        private By byBotaoRegistro;
        private By bySpanErroEmail;
        private By bySpanErroNome;

        public string NomeMensagemErro => driver.FindElement(bySpanErroNome).Text;
        public string EmailMensagemErro => driver.FindElement(bySpanErroEmail).Text;

        public RegistroPO(IWebDriver driver)
        {
            this.driver = driver;
            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputSenha = By.Id("Password");
            byInputConfirmacaoSenha = By.Id("ConfirmPassword");
            byBotaoRegistro = By.Id("btnRegistro");
            bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for='Nome']");
            bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for='Email']");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        internal void PreencheFormulario(string nome, string email, string senha, string confirmaSenha)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputSenha).SendKeys(senha);
            driver.FindElement(byInputConfirmacaoSenha).SendKeys(confirmaSenha);            
        }

        internal void SubmeteFormulario()
        {
            driver.FindElement(byBotaoRegistro).Click();               
        }
    }
}
