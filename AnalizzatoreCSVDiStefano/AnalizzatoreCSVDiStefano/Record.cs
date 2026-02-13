using System;
using System.Collections.Generic;
using System.Text;

namespace AnalizzatoreCSVDiStefano
{
    internal class Record
    {
        public string Country { get; set; }
        public string ActiveMilitary { get; set; }
        public string ReserveMilitary { get; set; }
        public string Paramilitary { get; set; }
        public string Total { get; set; }
        public string PerThousandTotal { get; set; }
        public string PerThousandActive { get; set; }
    }
}
