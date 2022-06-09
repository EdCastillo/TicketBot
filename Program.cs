using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketBot.Model;

namespace TicketBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeSpan timeoutMain=TimeSpan.FromMinutes(5);
            TimeSpan timeoutTest = TimeSpan.FromSeconds(5);

            TicketConfig test = new TicketConfig { StartRoute= "https://www.eticket.mx/masinformacion.aspx?idevento=29871", };
            TicketConfig main = new TicketConfig { StartRoute= "https://www.eticket.cr/eventos.aspx?idartista=835" };
            TicketConfig test2 = new TicketConfig();
            TicketConfig running = test;
            TimeSpan timeout = timeoutTest;

            IWebDriver driver = new EdgeDriver("D:");
            var waiter = new WebDriverWait(driver,timeout);



            driver.Manage().Window.Maximize();
            driver.Url = running.StartRoute;

            IWebElement ComprarBoletos = WaitUntilElementIsByVisible(driver,running.XPath_Comprar_Boletos);
            ComprarBoletos.Click();

            IWebElement SumarBoletos = WaitUntilElementIsByVisible(driver, running.XPath_NumeroBoletos);
            SumarBoletos.Clear();
            SumarBoletos.SendKeys("5");

            IWebElement ExecuteCompra = WaitUntilElementIsByVisible(driver, running.EjecutarCompra);
            ExecuteCompra.Click();
            //Thread.Sleep(TimeSpan.FromSeconds(2)); //deprecated

            string aceptarTerminos = "//*[@id=\"bAceptaTyc\"]";
            IWebElement AceptarTerminos =WaitUntilElementIsByVisible(driver,aceptarTerminos);
            Thread.Sleep(1000);
            AceptarTerminos.Click();

            
            
        }
        public static IWebElement WaitUntilElementIsByVisible(IWebDriver driver,string ElementXPath) {
            DateTime now = DateTime.Now;
            now=now.AddMinutes(5);
            while (DateTime.Now<now)
            {
                try {
                    IWebElement element=driver.FindElement(By.XPath(ElementXPath));
                    return element;
                }
                catch { 
                    //Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
            return null;
        }
        
    }
}
