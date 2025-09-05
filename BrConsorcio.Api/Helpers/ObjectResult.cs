using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Helpers
{
    public enum StatusResult
    {
        Success,
        Information,
        Warning,
        Danger
    }

    /// <summary>
    /// Container para resultado de operações ou requisições no banco de dados
    /// </summary>
    public class ObjectResult
    {
        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public ObjectResult()
        {
            this.Messages = new List<MessageResult>();
        }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="status">Status do resultado</param>
        public ObjectResult(StatusResult status, params string[] messages)
            : this()
        {
            this.Status = status;

            if (messages != null)
            {
                foreach (var msg in messages)
                {
                    this.Messages.Add(new MessageResult(msg, status));
                }
            }
        }

        /// <summary>
        /// Status da operação
        /// </summary>
        public StatusResult Status { get; set; }

        /// <summary>
        /// Lista de mensagens da operação
        /// </summary>
        public List<MessageResult> Messages { get; set; }
    }

    /// <summary>
    /// Container para resultado de operações ou requisições no banco de dados
    /// </summary>
    /// <typeparam name="Tobj">Tipo do objeto</typeparam>
    public class ObjectResult<Tobj> : ObjectResult where Tobj : class
    {
        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public ObjectResult()
            : base()
        {

        }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="obj">Objeto</param>
        public ObjectResult(Tobj obj)
            : this(obj, StatusResult.Success)
        {

        }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="obj">Objeto</param>
        /// <param name="status">Status do resultado</param>
        public ObjectResult(Tobj obj, StatusResult status, params string[] messages)
            : base(status)
        {
            this.Object = obj;
            if (obj == default(Tobj))
            {
                this.Messages.Add(new MessageResult(Message.NoDataFound, StatusResult.Information));
            }

            if (messages != null)
            {
                foreach (var msg in messages)
                {
                    this.Messages.Add(new MessageResult(msg, status));
                }
            }
        }

        /// <summary>
        /// Objeto de retorno
        /// </summary>
        public Tobj Object { get; set; }
    }
}
