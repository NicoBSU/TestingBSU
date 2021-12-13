using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_9.Models
{
    public class TourSearchButtonsXPaths
    {
        public readonly string StartLocation = "//*[@id=\"sppb-addon-1543614584688\"]/div/div/div/div/div/div/div/div[1]"; 
        public readonly string DestinationCountry = "//*[@id=\"sppb-addon-1543614584688\"]/div/div/div/div/div/div/div/div[2]";
        public readonly string Dates = "//*[@id=\"sppb-addon-1543614584688\"]/div/div/div/div/div/div/div/div[3]";
        public readonly string Nights = "//*[@id=\"sppb-addon-1543614584688\"]/div/div/div/div/div/div/div/div[4]";
        public readonly string SearchButton = "//*[@id=\"sppb-addon-1543614584688\"]/div/div/div/div/div/div/div/div[6]";
    }
}
