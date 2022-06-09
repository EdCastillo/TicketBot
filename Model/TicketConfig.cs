using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBot.Model
{
    
    internal class TicketConfig
    {
        public string XPath_Comprar_Boletos = "//*[@id=\"frmGlobal\"]/div[3]/div[4]/div[1]/div/div[2]/a";
        public string XPath_NumeroBoletos= "//*[@id=\"btnComprar805496\"]";
        public string EjecutarCompra= "//*[@id=\"bContinuar\"]";

        public string ConfirmarCompra = "/html/body/form/div[3]/div[4]/div/div[3]/div/div[1]/div/div[2]/div[5]/div[2]/div[1]/button";

        public string StartRoute;
        
    }
}
