using System;

namespace MM.CAAM.Admin.Services.Exceptions
{
    public class ExceptionMessage
    {
        private string messageException;
        public string MessageException { get => messageException; private set => messageException = value; }

        public ExceptionMessage(Exception exception)
        {
            var mensaje = exception.InnerException == null ? exception.Message : (exception.InnerException.InnerException == null ? exception.InnerException.Message : exception.InnerException.InnerException.Message);

            if (string.IsNullOrWhiteSpace(mensaje))
                mensaje = ((Services.Exceptions.RestException)exception).Content;

            MessageException = mensaje;
        }
    }

}