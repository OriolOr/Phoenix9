
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class Program
{
    public static void Main (string[] args)
    {
        //input id="username"
        System.Console.WriteLine("UserName:");
        var user = Console.ReadLine();

        //input id="password" 
        System.Console.WriteLine("Password:");
        var password = Console.ReadLine();


        var driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.afterbanks.com/appmain/static");

        driver.FindElement(By.Id("username")).SendKeys(user);
        Thread.Sleep(500);

        driver.FindElement(By.Id("password")).SendKeys(password);
        Thread.Sleep(500);

        driver.FindElement(By.TagName("button")).Click();
        Thread.Sleep(500);

        var elem = driver.FindElements(By.LinkText("List"));

        Thread.Sleep(10000); 
        driver.Close();

        
  
    }

}