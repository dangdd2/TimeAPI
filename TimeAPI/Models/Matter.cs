using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAPI.Models
{
    public class Matter
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }

        // Foreign Key
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public IList<DescriptorEntry> DescriptorMatters { get; set; }

    }
}
