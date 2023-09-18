using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MM.CAAM.MAUI.Movil.DTOs
{
    public class Result<TObject>
    {
        public int Code { get; set; }
        public bool Successful
        {
            get
            {
                return Code == (int)HttpStatusCode.OK;
            }
        }
        public string Message { get; set; }
        public TObject Data { get; set; }
    }
}
