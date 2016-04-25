using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseMonitor.Models
{
    public class Shipment
    {
        public  DateTime Date { get; set; }
        public int Shipments { get; set; }  
        public int Weight { get; set; }
    }
}
