using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAPI.Domain.Services;
using TimeAPI.Models;

namespace TimeAPI.Domain.Responses
{
    public class SaveClientResponse : BaseResponse
    {
        public Client Client { get; private set; }

        private SaveClientResponse(bool success, string message, Client client) : base(success, message)
        {
            Client = client;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveClientResponse(Client client) : this(true, string.Empty, client)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveClientResponse(string message) : this(false, message, null)
        { }
    }
}
