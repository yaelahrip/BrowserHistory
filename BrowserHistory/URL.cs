using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.BrowserHistory
{
    public class URL
    {
        public string browser { get; set; } // browser
        public long id { get; set; } // integer
        public object url { get; set; } // longvarchar
        public object title { get; set; } // longvarchar
        public object rev_host { get; set; } // longvarchar
        public long? visit_count { get; set; } // integer
        public long hidden { get; set; } // integer
        public long typed { get; set; } // integer
        public long? favicon_id { get; set; } // integer
        public long frecency { get; set; } // integer
        public long? last_visit_date { get; set; } // integer
        public string guid { get; set; } // text(max)
        public long foreign_count { get; set; } // integer
    }
}
