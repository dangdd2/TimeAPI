using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAPI.Models;

namespace TimeAPI.Domain.Responses
{
    public class SaveEntryResponse : BaseResponse
    {
        public Entry Entry { get; private set; }

        private SaveEntryResponse(bool success, string message, Entry entry) : base(success, message)
        {
            Entry = entry;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveEntryResponse(Entry entry) : this(true, string.Empty, entry)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveEntryResponse(string message) : this(false, message, null)
        { }
    }
}
