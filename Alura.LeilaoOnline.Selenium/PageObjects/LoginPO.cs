using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;        
        private By byInputUsuario;
        private By byInputSenha;
        private By byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;            
            byInputUsuario = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencheFormulario(string usuario, string senha)
        {
            driver.FindElement(byInputUsuario).SendKeys(usuario);
            driver.FindElement(byInputSenha).SendKeys(senha);            
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoLogin).Submit();
        }
    }
}
