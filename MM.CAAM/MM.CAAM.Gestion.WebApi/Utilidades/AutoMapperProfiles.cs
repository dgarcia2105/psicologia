using System;
using AutoMapper;
using MM.CAAM.Gestion.DTO;
using MM.CAAM.Gestion.WebApi.Entidades;

namespace MM.CAAM.Gestion.WebApi.Utilidades
{
	public class AutoMapperProfiles: Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<AutorCreacionDTO, Autor>();
		}
	}
}

