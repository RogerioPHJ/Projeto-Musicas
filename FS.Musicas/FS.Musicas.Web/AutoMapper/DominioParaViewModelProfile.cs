using AutoMapper;
using FS.Musicas.Dominio;
using FS.Musicas.Web.ViewModels.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FS.Musicas.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Album, AlbumIndexViewModel>();
        }
    }
}