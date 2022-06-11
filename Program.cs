using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
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
        static void Main(string[] args)
        {
            //Cosevi();

            //while (DateTime.Now <= DateTime.Parse("06/16/2022 8:00pm"))
            //{

            //}
            InstanceMultiplier(5);
            //Global_Basic_Execution(7577, 38966, 66258);//saprissa
            //Global_Basic_Execution(7309, 39226); //bad bunny

        }
        public static void InstanceMultiplier(int quantity) {
            for (int i = 0; i < quantity; i++)
            {
                //Thread temp = new Thread(() => Global_Basic_Execution(7577, 38966, 66258));
                Thread temp = new Thread(() => Global_Basic_Execution(7309, 39226));
                temp.Start();
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
        public static void Global_Basic_Execution(int eventID, int SectionID) {
            TicketConfig ticket = new TicketConfig();
            Action Url = new Action { Type = "Url", Objective = "https://www.eticket.cr/masinformacion.aspx?idevento=" + eventID };
            Action ComprarBoletos = new Action { Type = "Click", Objective = globalComprarYaRoute };
            Action sectionBtn = new Action { Type = "Click", Objective = "//*[@data-sectionid='" + SectionID + "']" };
            Action sendKeys = new Action { Type = "SendKeys", Value = "5", Objective = "//input[@class='spinbox SoloEnteros form-control']" };
            Action confirmBtn = new Action { Type = "Click", Objective = "//*[@id=\"bContinuar\"]" };
            Action wait = new Action { Type = "Wait", Value = "500" };
            Action AceptarTerminos = new Action { Type = "Click", Objective = "//*[@id=\"bAceptaTyc\"]" };
            List<Action> actions = new List<Action>();
            actions.Add(Url);
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
            Action Url = new Action { Type = "Url", Objective = "https://www.eticket.cr/masinformacion.aspx?idevento=" + eventID };
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

            actions.Add(Url);
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
            cosevi.ExecuteAction(new Action {Type="Click",Objective= "/html/body/div[2]/div[3]/div[1]/div/div/span/div[1]" });

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
