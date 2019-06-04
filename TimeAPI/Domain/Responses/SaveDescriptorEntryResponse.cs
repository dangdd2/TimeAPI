using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAPI.Models;

namespace TimeAPI.Domain.Responses
{ 
    public class SaveDescriptorEntryResponse : BaseResponse
    {

        public DescriptorEntry DescriptorEntry { get; private set; }

        private SaveDescriptorEntryResponse(bool success, string message, DescriptorEntry descriptorentry) : base(success, message)
        {
            DescriptorEntry = descriptorentry;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveDescriptorEntryResponse(DescriptorEntry descriptorentry) : this(true, string.Empty, descriptorentry)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveDescriptorEntryResponse(string message) : this(false, message, null)
        { }
    }
}
