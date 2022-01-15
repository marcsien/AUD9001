using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.Entities
{
    public class Factor : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Importance { get; set; }
        public bool Positive { get; set; }
        public bool Internal { get; set; }
        public StrategicPositionAnalysis StrategicPositionAnalysis { get; set; }
    }
}
