using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicketBot.Model
{
    
    internal class TicketConfig
    {
        public IWebDriver driver = ProtectRequest();
        public List<Action> actions;
        public static IWebDriver ProtectRequest() {
            //return new EdgeDriver("C://");
            Random random = new Random();
            int result = random.Next(0, 2);
            if (result == 0)
            {
                return new EdgeDriver("D:");
            }
            else {
                return new ChromeDriver("D:");
            }
        }
        public void ExecuteAction() {
            foreach (var action in actions) {
                ActionSwitch(action);
            }
        }
        public void ExecuteAction(List<Action> actionList) {
            foreach (var action in actionList) {
                ActionSwitch(action);
            }       
        }
        public void ExecuteAction(Action action) {
            ActionSwitch(action);
        }
        public void ClickOnBestSectionAvailable() {
            IList<IWebElement> all = WaitForElementByCSSSelector("div[class='seccion contenedor']");
            //IList<IWebElement> all = driver.FindElements(By.CssSelector("div[class='seccion contenedor']"));
            
            string SectionId="";
            float precio = 0;
            string Nombre="";
            foreach (IWebElement element in all)
            {
                //element.GetAttribute("data-sectionid");
                try
                {
                    string text = WaitForElementCssSelector(element,"*[class='seccion precio']").Text;
                    //string text = element.FindElement(By.CssSelector("*[class='seccion precio']")).Text;
                    //text = text.Remove(0,1);
                    text = text.Replace('¢', '0');
                    text = text.Replace(',', '.');


                    float precioE = float.Parse(text);
                    if (precioE > precio)
                    {
                        precio = precioE;
                        SectionId = element.GetAttribute("data-sectionid");
                        Nombre = element.FindElement(By.CssSelector("*[class='seccion titulo']")).Text;
                    }
                }
                catch {
                    continue;
                }
            }
            Console.Write(Nombre);
            IWebElement bestSection = driver.FindElement(By.XPath("//*[@data-sectionid='" + SectionId + "']"));
            bestSection.Click();
        }
        public void URL_RefreshForElement(string url,string XPath)
        {
            while (true)
            {
                driver.Url = url;
                Thread.Sleep(300);
                try
                {
                    IWebElement element = driver.FindElement(By.XPath(XPath));
                    Console.WriteLine("Found it");
                    
                    return;
                }
                catch
                {
                    Console.WriteLine("Refresh");
                }
            }
            
        }
        public IWebElement WaitForElementCssSelector(IWebElement element,string objective) {
            DateTime now = DateTime.Now;
            now = now.AddMinutes(10);
            while (DateTime.Now < now)
            {
                try
                {
                    Console.WriteLine("Trying to request.");
                    IWebElement elementO = element.FindElement(By.CssSelector(objective));
                    return elementO;
                }
                catch
                {
                    //Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
            Thread.CurrentThread.Abort();
            return null;
        }
        public IList<IWebElement> WaitForElementByCSSSelector(string objective)
        {

            DateTime now = DateTime.Now;
            now = now.AddMinutes(10);
            while (DateTime.Now < now)
            {
                try
                {
                    Console.WriteLine("Trying to request.");
                    IList<IWebElement> element = driver.FindElements(By.CssSelector(objective));
                    return element;
                }
                catch
                {
                    //Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
            Thread.CurrentThread.Abort();
            return null;
        }
        public void ActionSwitch(Action action) {
            if (action.Type == "Click") {
                IWebElement element = WaitAndGetElement(action.Objective);
                element.Click();
                return;
            }
            if (action.Type == "SendKeys") {
                IWebElement element = WaitAndGetElement(action.Objective);
                element.Clear();
                element.SendKeys(action.Value);
                return;
            }
            if (action.Type == "Url") {
                driver.Url = action.Objective;
                return;
            }
            if (action.Type == "Wait") {
                Thread.Sleep(Int32.Parse(action.Value));
            }

        }


        public IWebElement WaitAndGetElement(string Xpath)
        {
            DateTime now = DateTime.Now;
            now = now.AddMinutes(10);
            while (DateTime.Now < now)
            {
                try
                {
                    IWebElement element = driver.FindElement(By.XPath(Xpath));
                    return element;
                }
                catch
                {
                    //Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
            return null;
        }
    }
}
