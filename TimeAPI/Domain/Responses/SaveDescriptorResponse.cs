using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAPI.Models;

namespace TimeAPI.Domain.Responses
{
    public class SaveDescriptorResponse : BaseResponse
    {
        public Descriptor Descriptor { get; private set; }

        private SaveDescriptorResponse(bool success, string message, Descriptor descriptor) : base(success, message)
        {
            Descriptor = descriptor;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveDescriptorResponse(Descriptor descriptor) : this(true, string.Empty, descriptor)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveDescriptorResponse(string message) : this(false, message, null)
        { }
    }
}
