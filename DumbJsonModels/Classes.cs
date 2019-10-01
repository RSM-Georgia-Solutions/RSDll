using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevenueServices.DumbJsonModels
{
    public class Classes
    {
        public class Data2
        {
            public List<string> Fields { get; set; }
            public List<List<object>> Rows { get; set; }
        }

        public class Summary
        {
            public double _Count { get; set; }
        }

        public class DATA
        {
            public Data2 Data { get; set; }
            public Summary Summary { get; set; }
        }

        public class STATUS
        {
            public int ID { get; set; }
            public string TEXT { get; set; }
        }

        public class RootObject
        {
            public DATA DATA { get; set; }
            public STATUS STATUS { get; set; }
        }
    }
}
