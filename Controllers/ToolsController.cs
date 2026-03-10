using Microsoft.AspNetCore.Mvc;
using ratpdf.Models;

namespace ratpdf.Controllers
{
    public class ToolsController : Controller
    {
        public IActionResult RingSizeConverter()
        {
            #region Ring Sizes
            var ringSizes = new List<RingSize>
            {
                // US 1–2.5 (children / small)
                new RingSize { US="1",    UK="B½",  AU="B½",  EU="40", FR_RU="40", JP="2",  CH="40", CN="2",  IN="1",  DiameterMM=12.7, CircumferenceMM=39.8 },
                new RingSize { US="1.5",  UK="C½",  AU="C½",  EU="41", FR_RU="41", JP="2",  CH="41", CN="2",  IN="2",  DiameterMM=13.0, CircumferenceMM=40.8 },
                new RingSize { US="2",    UK="D½",  AU="D½",  EU="42", FR_RU="42", JP="3",  CH="42", CN="3",  IN="3",  DiameterMM=13.4, CircumferenceMM=42.0 },
                new RingSize { US="2.5",  UK="E½",  AU="E½",  EU="43", FR_RU="43", JP="4",  CH="43", CN="4",  IN="4",  DiameterMM=13.8, CircumferenceMM=43.4 },

                // US 3–16 (adults)
                new RingSize { US="3",    UK="F",   AU="F",   EU="44", FR_RU="44", JP="5",  CH="44", CN="5",  IN="5",  DiameterMM=14.1, CircumferenceMM=44.2 },
                new RingSize { US="3.5",  UK="G",   AU="G",   EU="46", FR_RU="46", JP="6",  CH="46", CN="6",  IN="6",  DiameterMM=14.5, CircumferenceMM=45.5 },
                new RingSize { US="4",    UK="H",   AU="H",   EU="47", FR_RU="47", JP="7",  CH="47", CN="7",  IN="7",  DiameterMM=14.8, CircumferenceMM=46.5 },
                new RingSize { US="4.5",  UK="I",   AU="I",   EU="48", FR_RU="48", JP="8",  CH="48", CN="8",  IN="8",  DiameterMM=15.2, CircumferenceMM=47.8 },
                new RingSize { US="5",    UK="J",   AU="J",   EU="49", FR_RU="49", JP="9",  CH="49", CN="9",  IN="9",  DiameterMM=15.6, CircumferenceMM=49.0 },
                new RingSize { US="5.5",  UK="K",   AU="K",   EU="50", FR_RU="50", JP="10", CH="50", CN="10", IN="10", DiameterMM=16.0, CircumferenceMM=50.3 },
                new RingSize { US="6",    UK="L",   AU="L",   EU="52", FR_RU="52", JP="11", CH="52", CN="11", IN="11", DiameterMM=16.5, CircumferenceMM=51.8 },
                new RingSize { US="6.5",  UK="M",   AU="M",   EU="53", FR_RU="53", JP="12", CH="53", CN="12", IN="12", DiameterMM=16.9, CircumferenceMM=53.1 },
                new RingSize { US="7",    UK="N½",  AU="N½",  EU="54", FR_RU="54", JP="13", CH="54", CN="13", IN="13", DiameterMM=17.3, CircumferenceMM=54.4 },
                new RingSize { US="7.5",  UK="O",   AU="O",   EU="56", FR_RU="56", JP="14", CH="56", CN="14", IN="14", DiameterMM=17.7, CircumferenceMM=55.6 },
                new RingSize { US="8",    UK="P½",  AU="P½",  EU="57", FR_RU="57", JP="15", CH="57", CN="15", IN="15", DiameterMM=18.1, CircumferenceMM=56.9 },
                new RingSize { US="8.5",  UK="Q",   AU="Q",   EU="58", FR_RU="58", JP="16", CH="58", CN="16", IN="16", DiameterMM=18.5, CircumferenceMM=58.1 },
                new RingSize { US="9",    UK="R½",  AU="R½",  EU="59", FR_RU="59", JP="17", CH="59", CN="17", IN="17", DiameterMM=18.9, CircumferenceMM=59.4 },
                new RingSize { US="9.5",  UK="S½",  AU="S½",  EU="61", FR_RU="61", JP="18", CH="61", CN="18", IN="18", DiameterMM=19.4, CircumferenceMM=60.9 },
                new RingSize { US="10",   UK="T½",  AU="T½",  EU="62", FR_RU="62", JP="20", CH="62", CN="20", IN="19", DiameterMM=19.8, CircumferenceMM=62.2 },
                new RingSize { US="10.5", UK="U½",  AU="U½",  EU="64", FR_RU="64", JP="21", CH="64", CN="21", IN="20", DiameterMM=20.2, CircumferenceMM=63.5 },
                new RingSize { US="11",   UK="V½",  AU="V½",  EU="65", FR_RU="65", JP="22", CH="65", CN="22", IN="21", DiameterMM=20.6, CircumferenceMM=64.8 },
                new RingSize { US="11.5", UK="W½",  AU="W½",  EU="66", FR_RU="66", JP="23", CH="66", CN="23", IN="22", DiameterMM=21.0, CircumferenceMM=66.0 },
                new RingSize { US="12",   UK="X½",  AU="X½",  EU="67", FR_RU="67", JP="24", CH="67", CN="24", IN="23", DiameterMM=21.4, CircumferenceMM=67.3 },
                new RingSize { US="12.5", UK="Y½",  AU="Y½",  EU="69", FR_RU="69", JP="25", CH="69", CN="25", IN="24", DiameterMM=21.8, CircumferenceMM=68.6 },
                new RingSize { US="13",   UK="Z½",  AU="Z½",  EU="70", FR_RU="70", JP="26", CH="70", CN="26", IN="25", DiameterMM=22.2, CircumferenceMM=69.8 },
                new RingSize { US="13.5", UK="Z1½", AU="Z1½", EU="71", FR_RU="71", JP="27", CH="71", CN="27", IN="26", DiameterMM=22.6, CircumferenceMM=71.1 },
                new RingSize { US="14",   UK="Z2½", AU="Z2½", EU="72", FR_RU="72", JP="28", CH="72", CN="28", IN="27", DiameterMM=23.0, CircumferenceMM=72.3 },
                new RingSize { US="14.5", UK="Z3½", AU="Z3½", EU="74", FR_RU="74", JP="29", CH="74", CN="29", IN="28", DiameterMM=23.4, CircumferenceMM=73.6 },
                new RingSize { US="15",   UK="Z4½", AU="Z4½", EU="75", FR_RU="75", JP="30", CH="75", CN="30", IN="29", DiameterMM=23.8, CircumferenceMM=74.8 },
                new RingSize { US="16",   UK="Z5½", AU="Z5½", EU="76", FR_RU="76", JP="31", CH="76", CN="31", IN="30", DiameterMM=24.2, CircumferenceMM=76.0 },
            };
            #endregion

            return View(ringSizes);
        }
    }
}
