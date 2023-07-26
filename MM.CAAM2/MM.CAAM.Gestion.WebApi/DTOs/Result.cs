using Microsoft.AspNetCore.DataProtection;
using MM.CAAM.Gestion.WebApi.Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MM.CAAM.Gestion.WebApi.DTOs
{
    public class Result
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
        public object Data { get; set; }
    }
}

