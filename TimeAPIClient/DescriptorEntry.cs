using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAPIClient
{
    public class DescriptorEntry
    {
        public int Id { get; set; }
        public int DescriptorId { get; set; }
        public Descriptor Descriptor { get; set; }

        public int EntryId { get; set; }
        public Entry Entry { get; set; }
    }
}
