using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL3_Loot_Tracker
{
    public class Runs
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string Boss { get; set; }
        public string Time { get; set; }
        public string Loot { get; set; }

        public string Run
        {
            get
            {
                return $"{Date} {Boss} {Time} {Loot}";
            }
        }
    }
}
