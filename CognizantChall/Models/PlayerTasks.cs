using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChall.Models
{
    public class PlayerTasks
    {
        public int id { get; set; }
        public int playersId { get; set; }
        public Players player { get; set; }
        public int tasksId { get; set; }
        public Tasks task { get; set; }
    }
}
