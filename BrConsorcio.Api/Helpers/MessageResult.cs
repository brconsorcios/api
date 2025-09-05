using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Helpers
{
    public class MessageResult
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="message">Mensagem</param>
        /// <param name="status">Status</param>
        public MessageResult(string message, StatusResult status)
        {
            this.Message = message;
            this.Status = status;
        }

        /// <summary>
        /// Mensagem
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Status da mensagem
        /// </summary>
        public StatusResult Status { get; set; }
    }
}
