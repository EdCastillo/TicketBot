using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketBot.Model;
using Action = TicketBot.Model.Action;

namespace TicketBot
{
    internal class Program
    {
        static string globalComprarYaRoute = "/html/body/form/div[3]/div[4]/div[1]/div/div[2]/a";
        static int instances = 5;
        static Thread[] threads = new Thread[instances];
        static DateTime[] dates = new DateTime[instances];
        static void Main(string[] args)
        {
            //TicketConfig testBB = new TicketConfig();
            //testBB.URL_RefreshForElement(" https://www.eticket.cr/masinformacion.aspx?idevento=6965", "//a[@class=\"URLCOMPRA botoncompra\"]");
            //testBB.ExecuteAction(new Action { Type = "Click", Objective = globalComprarYaRoute });
            //testBB.ClickOnBestSectionAvailable();
            //InstanceMultiplier();
            //Global_Basic_Execution(7577, 38966, 66258);

            while (DateTime.Now <= DateTime.Parse("06/16/2022 10:00am"))
            {

            }
            InstanceMultiplier();
            //Global_Basic_Execution(7577, 38966, 66258);//saprissa
            //Global_Basic_Execution(7309, 39226); //bad bunny
        }
        public static void InstanceMultiplier() {
            for (int i = 0; i < 5; i++) {
                if (threads[i] == null)
                {
                    threads[i] = new Thread(() => Global_Basic_Execution(7309, 39226));
                    threads[i].Start();
                    dates[i] = DateTime.Now.AddMinutes(20);
                }
                else {
                    if (threads[i].IsAlive == true && dates[i] > DateTime.Now) {
                        continue;
                    }
                    if (threads[i].IsAlive == true && dates[i] < DateTime.Now) { 
                        threads[i].Abort();
                        threads[i] = new Thread(() => Global_Basic_Execution(7309, 39226));
                        threads[i].Start();
                        dates[i] = DateTime.Now.AddMinutes(20);
                    }
                    if (threads[i].IsAlive == false) {
                        threads[i] = new Thread(() => Global_Basic_Execution(7309, 39226));
                        threads[i].Start();
                        dates[i] = DateTime.Now.AddMinutes(20);
                    }
                }
            }
        }
        public static void BadBunny_EXEC_1()
        {
            int eventID = 7309;
            int SectionID = 39226;
            TicketConfig badBunny = new TicketConfig();
            List<Action> actions1 = new List<Action>();
            Action Url = new Action { Type = "Url", Objective = "https://www.eticket.cr/masinformacion.aspx?idevento=" + eventID };
            Action ComprarBoletos = new Action { Type = "Click", Objective = globalComprarYaRoute };
            actions1.Add(Url);
            actions1.Add(ComprarBoletos);
            badBunny.ExecuteAction(actions1);
        }
        public static void Global_Intelli_Request_Execution(int eventID, int SectionID) {
            TicketConfig ticket = new TicketConfig();
            ticket.URL_RefreshForElement("https://www.eticket.cr/masinformacion.aspx?idevento=" + eventID, "//a[@class=\"URLCOMPRA botoncompra\"]");
            ticket.ExecuteAction(new Action { Type = "Click", Objective = globalComprarYaRoute });
            ticket.ClickOnBestSectionAvailable();
            ticket.ExecuteAction(new Action { Type = "SendKeys", Value = "5", Objective = "//input[@class='spinbox SoloEnteros form-control']" });
            ticket.ExecuteAction(new Action { Type = "Click", Objective = "//*[@id=\"bContinuar\"]" });


        }
        public static void Global_Basic_Execution(int eventID, int SectionID) {
            TicketConfig ticket = new TicketConfig();
            //Action Url = new Action { Type = "Url", Objective = "https://www.eticket.cr/masinformacion.aspx?idevento=" + eventID };
            ticket.URL_RefreshForElement("https://www.eticket.cr/masinformacion.aspx?idevento=" + eventID, "//a[@class=\"URLCOMPRA botoncompra\"]");
            
            Action ComprarBoletos = new Action { Type = "Click", Objective = globalComprarYaRoute };
            Action sectionBtn = new Action { Type = "Click", Objective = "//*[@data-sectionid='" + SectionID + "']" };
            Action sendKeys = new Action { Type = "SendKeys", Value = "5", Objective = "//input[@class='spinbox SoloEnteros form-control']" };
            Action confirmBtn = new Action { Type = "Click", Objective = "//*[@id=\"bContinuar\"]" };
            Action wait = new Action { Type = "Wait", Value = "500" };
            Action AceptarTerminos = new Action { Type = "Click", Objective = "//*[@id=\"bAceptaTyc\"]" };
            List<Action> actions = new List<Action>();
            //actions.Add(Url);
            actions.Add(ComprarBoletos);
            actions.Add(sectionBtn);
            actions.Add(sendKeys);
            actions.Add(confirmBtn);
            actions.Add(wait);
            actions.Add(AceptarTerminos);
            ticket.ExecuteAction(actions);
        }
        public static void Global_Basic_Execution(int eventID, int SectionID, int blockID)
        {
            TicketConfig ticket = new TicketConfig();
            //ticket.driver.Manage().Window.Minimize();
            //Action Url = new Action { Type = "Url", Objective = "https://www.eticket.cr/masinformacion.aspx?idevento=" + eventID };
            ticket.URL_RefreshForElement("https://www.eticket.cr/masinformacion.aspx?idevento=" + eventID, "//a[@class=\"URLCOMPRA botoncompra\"]");
            Action ComprarBoletos = new Action { Type = "Click", Objective = globalComprarYaRoute };
            Action sectionBtn = new Action { Type = "Click", Objective = "//*[@data-sectionid='" + SectionID + "']" };
            //OPT
            Action block = new Action { Type = "Click", Objective = "//*[@data-blockid='" + blockID + "']" };
            //
            Action sendKeys = new Action { Type = "SendKeys", Value = "5", Objective = "//input[@class='spinbox SoloEnteros form-control']" };
            Action confirmBtn = new Action { Type = "Click", Objective = "//*[@id=\"bContinuar\"]" };
            Action wait = new Action { Type = "Wait", Value = "500" };
            Action AceptarTerminos = new Action { Type = "Click", Objective = "//*[@id=\"bAceptaTyc\"]" };
            Action Confirm = new Action { Type = "Click", Objective = "//*[@class='goButton btn-wait']" };
            List<Action> actions = new List<Action>();

            //actions.Add(Url);
            actions.Add(ComprarBoletos);
            actions.Add(sectionBtn);
            actions.Add(block);
            actions.Add(sendKeys);
            actions.Add(confirmBtn);
            actions.Add(wait);
            actions.Add(AceptarTerminos);
            actions.Add(Confirm);
            ticket.ExecuteAction(actions);
            ticket.driver.Manage().Window.Maximize();
        }
        public static void Cosevi(){
            TicketConfig cosevi = new TicketConfig();
            cosevi.ExecuteAction(new Action { Type="Url",Objective= "https://servicios.educacionvial.go.cr/Formularios/MatriculaPruebaTeorica" });
            cosevi.ExecuteAction(new Action { Type="Click",Objective= "/html/body/div[3]/div[2]/div/div[2]/form/div[10]/label/input" });
            IWebElement captcha = cosevi.WaitAndGetElement("/html/body/div[2]/div[3]/div[1]/div/div/span/div[1]");
            Actions action = new Actions(cosevi.driver);
            action.MoveToElement(captcha).Perform();
            //cosevi.ExecuteAction(new Action {Type="Click",Objective= "/html/body/div[2]/div[3]/div[1]/div/div/span/div[1]" });

        }

        public static List<Action> TestActions() {
            List<Action> actions = new List<Action>();
            Action url = new Action { Type = "Url", Objective = "https://www.eticket.mx/masinformacion.aspx?idevento=29871" };
            Action comprarBoletosButton = new Action { Type = "Click", Objective = "//*[@id=\"frmGlobal\"]/div[3]/div[4]/div[1]/div/div[2]/a" };
            Action TypeCantidadBoletos = new Action { Type = "SendKeys", Value = "10", Objective = "//*[@id=\"btnComprar805496\"]" };
            Action ExecuteCompra = new Action { Type = "Click", Objective = "//*[@id=\"bContinuar\"]" };
            Action wait = new Action { Type = "Wait", Value = "500" };
            Action AceptarTerminos = new Action { Type = "Click", Objective = "//*[@id=\"bAceptaTyc\"]" };
            Action continuarCompra = new Action { Type = "Click", Objective = "/html/body/form/div[3]/div[4]/div/div[3]/div/div[1]/div/div[2]/div[5]/div[2]/div[1]/button" };
            actions.Add(url);
            actions.Add(comprarBoletosButton);
            actions.Add(TypeCantidadBoletos);
            actions.Add(ExecuteCompra);
            actions.Add(wait);
            actions.Add(AceptarTerminos);
            actions.Add(continuarCompra);
            return actions;
            
        }
        

        
            
        
        
        
    }
}
