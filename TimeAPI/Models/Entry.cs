using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAPI.Models
{
    public class Entry
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public double ElapsedTime { get; set; }
        public string Narrative { get; set; }
        
        // Foreign Key
        public int MatterId { get; set; }
        public Matter Matter { get; set; }
        public IList<Descriptor> Descriptor { get; set; } = new List<Descriptor>();
    }
}
