using AutoMapper;
using FS.Musicas.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FS.Musicas.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configurar()
        {
            Mapper.AddProfile<DominioParaViewModelProfile>();
        }
    }
}