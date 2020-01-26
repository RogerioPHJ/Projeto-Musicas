using AutoMapper;
using FS.Musicas.Dominio;
using FS.Musicas.Web.ViewModels.Album;
using FS.Musicas.Web.ViewModels.Musica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FS.Musicas.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AlbumViewModel, Album>();
            Mapper.CreateMap<MusicaViewModel, Musica>();
        }
    }
}