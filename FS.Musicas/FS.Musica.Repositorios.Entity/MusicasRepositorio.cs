using FS.Repositiorios.Comum.Entity;
using FS.Musicas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FS.Musicas.AcessoDados.Entity.Context;
using System.Data.Entity;

namespace FS.Musicas.Repositorios.Entity
{
    public class MusicasRepositorio : RepositorioGenericoEntity<Musica, long>
    {
        public MusicasRepositorio(MusicasDbContext contexto)
            :base (contexto)
        {

        }

        public override List<Musica> Selecionar()
        {
            return _contexto.Set<Musica>().Include(p => p.Album).ToList();  
        }

        public override Musica SelecionarPorId(long id)
        {
            return _contexto.Set<Musica>().Include(p => p.Album).SingleOrDefault(m => m.Id == id) ;
        }
    }
}
