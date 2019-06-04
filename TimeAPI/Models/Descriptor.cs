using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAPI.Models
{
    public class Descriptor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public IList<DescriptorEntry> DescriptorMatters { get; set; }

    }
}
