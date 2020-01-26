using FS.Musicas.AcessoDados.Entity.Context;
using FS.Musicas.Dominio;
using FS.Repositiorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FS.Musicas.Repositorios.Entity
{
    public class AlbunsRepositorio : RepositorioGenericoEntity<Album, int>
    {

        public AlbunsRepositorio(MusicasDbContext contexto)
            :base(contexto)
        {
             
        }

        public override List<Album> Selecionar()
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).ToList();
        }

        public override Album SelecionarPorId(int id)
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).SingleOrDefault(a => a.Id == id);
        }
    }
}
