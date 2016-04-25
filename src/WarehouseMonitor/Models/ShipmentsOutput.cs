using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseMonitor.Models
{
    public class ShipmentsOutput
    {
        public DateTime Date { get; set; }

        public string Department { get; set; }

        public string CategoryWeight { get; set; }

        public int Shipments { get; set; }

        public decimal Weight { get; set; }
    }
}
