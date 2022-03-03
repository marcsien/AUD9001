using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain.Models
{
    public class StrategicPositionAnalysis
    {
        public DateTime CreationDate { get; set; }
        public int RecordNumber { get; set; }
        public int SummaryS { get; set; }
        public int SummaryW { get; set; }
        public int SummaryO { get; set; }
        public int SummaryT { get; set; }
        public int AR { get; set; }
        public int PR { get; set; }
    }
}
