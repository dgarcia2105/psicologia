//using Microsoft.AspNetCore.DataProtection;
using MM.CAAM.Gestion.Models.Entidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MM.CAAM.Gestion.DTO.Objects
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

