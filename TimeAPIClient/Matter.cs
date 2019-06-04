using System.Collections.Generic;

namespace TimeAPIClient
{
    public class Matter
    {
        public int id { get; set; }
        public string name { get; set; }
        public string identifier { get; set; }

        // Foreign Key
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public IList<DescriptorEntry> DescriptorMatters { get; set; }
    }
}