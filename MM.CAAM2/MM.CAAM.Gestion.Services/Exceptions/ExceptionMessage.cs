using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.CAAM.Gestion.Services.Exceptions
{
    public class ExceptionMessage
    {
        private string messageException;
        public string MessageException { get => messageException; private set => messageException = value; }

        public ExceptionMessage(Exception exception)
        {
            var mensaje = exception.InnerException == null ? exception.Message : (exception.InnerException.InnerException == null ? exception.InnerException.Message : exception.InnerException.InnerException.Message);

            MessageException = mensaje;
        }
    }
}
