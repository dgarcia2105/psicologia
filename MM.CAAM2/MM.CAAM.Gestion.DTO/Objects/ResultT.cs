using System.Net;

namespace MM.CAAM.Gestion.DTO.Objects
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