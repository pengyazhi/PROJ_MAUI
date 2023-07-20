using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAPP_MAUI.Models
{
    public class CProducts
    {
        public int 流水號 { get; set; }
        public string product { get; set; }
        public string supplier { get; set; }
        public int price { get; set; }
        public string date { get; set; }
        public int min { get; set; }
        public int max { get; set; }   
    }
}
