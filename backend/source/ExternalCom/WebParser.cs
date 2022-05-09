using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OriolOr.Maneko.ExternalCom
{
    public class WebParser
    {
        public void startDriver()
        {
            ChromeDriver driver = new ChromeDriver();
            var nav = driver.Navigate();
            nav.GoToUrl("https://google.com");
    
        }
    }
    
}