using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Models
{
    public class MaintananceRequest
    {
        public int[,] Timeinterval { get; set; }
    }

    public class Timeinterval
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}
