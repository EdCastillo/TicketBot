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
