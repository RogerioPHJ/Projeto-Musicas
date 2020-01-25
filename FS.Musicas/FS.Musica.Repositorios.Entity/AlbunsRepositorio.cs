using FS.Musicas.AcessoDados.Entity.Context;
using FS.Musicas.Dominio;
using FS.Repositiorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS.Musica.Repositorios.Entity
{
    public class AlbunsRepositorio : RepositorioGenericoEntity<Album, int>
    {

        public AlbunsRepositorio(MusicasDbContext contexto)
            :base(contexto)
        {
             
        }


    }
}
