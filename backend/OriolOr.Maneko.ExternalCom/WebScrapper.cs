using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Globalization;

namespace OriolOr.Maneko.ExternalCom
{
    public class WebScrapper : IDisposable
    {
        private string UserName;
        private string Password;
        private IWebDriver Driver;

        public WebScrapper(string user, string password)
        {
            this.UserName = user;
            this.Password = password;
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");
            chromeOptions.AddArguments("--no-sandbox");

            this.Driver = new ChromeDriver(chromeOptions);

            this.Driver.Navigate().GoToUrl("https://www.afterbanks.com/appmain/static");
        }

        public double ScrapCurrentBalance()
        {
            this.Login();
            this.NavigateToClobalInfo();
            var Balance = this.ParseCurrentBalance();

            return Balance;
        }

        private void Login()
        {
            this.Driver.FindElement(By.Id("username")).SendKeys(UserName);
            Thread.Sleep(500);

            this.Driver.FindElement(By.Id("password")).SendKeys(Password);
            Thread.Sleep(500);

            this.Driver.FindElement(By.TagName("button")).Click();
            Thread.Sleep(500);

        }

        private void NavigateToClobalInfo()
        {
            var elem = this.Driver.FindElements(By.Id("addBank")).Where(elm => elm.Text.Contains("GLOBAL")).FirstOrDefault();
            elem.Click();
            Thread.Sleep(500);
        }

        private double ParseCurrentBalance()
        {
            var text = this.Driver.FindElement(By.Id("product_150543")).Text.Split(" ")[1];
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";
            var currentBalance = Convert.ToDouble(text, provider);

            return currentBalance;
        }

        public void Dispose()
        {
            this.Driver.Close();
        }
    }
}
