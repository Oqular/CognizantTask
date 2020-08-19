using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChall.Models
{
    public class Tasks
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string testInput { get; set; }
        public string testOutput { get; set; }
        public List<PlayerTasks> players { get; set; }
    }
}
