using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAPI.Models;

namespace TimeAPI.Domain.Responses
{
    public class SaveMatterResponse : BaseResponse
    {
        public Matter Matter { get; private set; }

        private SaveMatterResponse(bool success, string message, Matter matter) : base(success, message)
        {
            Matter = matter;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveMatterResponse(Matter matter) : this(true, string.Empty, matter)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveMatterResponse(string message) : this(false, message, null)
        { }
    }
}
