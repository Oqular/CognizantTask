using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChall.Models
{
    public class Players
    {
        public int id { get; set; }
        public string nickname { get; set; }
        public int successfulTaskCount { get; set; }
        public List<PlayerTasks> tasks { get; set; }
    }
}
