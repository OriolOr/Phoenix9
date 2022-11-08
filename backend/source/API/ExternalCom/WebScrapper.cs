using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OriolOr.Maneko.API.Models.IdentityManagement;
using System.Globalization;

namespace OriolOr.Maneko.API.ExternalCom
{
    internal class WebScrapper : IDisposable
    {

        private IWebDriver Driver;
        private readonly UserCredentials UserCredentials;


        private IWebElement UserInput => this.Driver.FindElement(By.Id("username"));
        private IWebElement PasswordInput => this.Driver.FindElement(By.Id("password"));
        private IWebElement SubmitButtonCredentials => this.Driver.FindElement(By.TagName("button"));
        private IWebElement NavigateToAccountInfo => this.Driver.FindElements(By.Id("addBank")).Where(elm => elm.Text.Contains("GLOBAL")).FirstOrDefault();
        private IWebElement AccountInfo => this.Driver.FindElement(By.Id("product_150543"));

        public WebScrapper(UserCredentials userCredentials )
        {
            this.UserCredentials = userCredentials;
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");
            chromeOptions.AddArguments("--no-sandbox");

            this.Driver = new ChromeDriver(chromeOptions);

            this.Driver.Navigate().GoToUrl("https://www.afterbanks.com/appmain/static");

            this.Login();
            this.NavigateToClobalInfo();
        }

        public double ScrapCurrentBalance()
        {
            var text = AccountInfo.Text.Split(" ")[1];
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";
            var currentBalance = Convert.ToDouble(text, provider);

            return currentBalance;
        }

        public String ScrapAccountId()
        {
            var text  = AccountInfo.Text.Split("(")[1].Split(")")[0];
            text = text.Replace(" ", "");

            return text;
        }


        private void Login()
        {
            UserInput.SendKeys(this.UserCredentials.UserName);
            Thread.Sleep(300);

            PasswordInput.SendKeys(this.UserCredentials.Password);
            Thread.Sleep(300);

            SubmitButtonCredentials.Click();
            Thread.Sleep(300);

        }

        private void NavigateToClobalInfo()
        {
            NavigateToAccountInfo.Click();
            Thread.Sleep(500);
        }

        public void Dispose()

           => this.Driver.Close();
        
    }
}
