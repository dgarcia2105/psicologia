﻿using System;
namespace MM.CAAM.Gestion.WebApi.Entidades
{
	public class Comentario
	{
        public int Id { get; set; }
        public string Contenido { get; set; }
        public int LibroId { get; set; }
        public Libro libro { get; set; }

    }
}

