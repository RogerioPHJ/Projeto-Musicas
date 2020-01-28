using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FS.Musicas.AcessoDados.Entity.Context;
using FS.Musicas.Dominio;
using FS.Musicas.Repositorios.Entity;
using FS.Musicas.Web.ViewModels.Album;
using FS.Musicas.Web.ViewModels.Musica;
using FS.Repositorios.Comum;

namespace FS.Musicas.Web.Controllers
{
    [Authorize]
    public class MusicasController : Controller
    {
        private IRepositorioGenerico<Musica, long> repositorioMusicas =
            new MusicasRepositorio(new MusicasDbContext());

        private IRepositorioGenerico<Album, int> repositorioAlbuns =
            new AlbunsRepositorio(new MusicasDbContext());

        // GET: Musicas
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Musica>, List<MusicaExibicaoViewModel>>(repositorioMusicas.Selecionar()));
        }

        // GET: Musicas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Musica, MusicaExibicaoViewModel>(musica));
        }

        // GET: Musicas/Create
        public ActionResult Create()
        {
            List<AlbumExibicaoViewModel> albuns = Mapper.Map<List<Album>, List<AlbumExibicaoViewModel>>(repositorioAlbuns.Selecionar());
            SelectList dropDownAlbuns = new SelectList(albuns, "Id" , "Nome");
            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View();
        }

        // POST: Musicas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusicas.Inserir(musica);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Musicas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            List<AlbumExibicaoViewModel> albuns = Mapper.Map<List<Album>, List<AlbumExibicaoViewModel>>(repositorioAlbuns.Selecionar());
            SelectList dropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View(Mapper.Map<Musica, MusicaViewModel>(musica));
        }

        // POST: Musicas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Musica musica = Mapper.Map<MusicaViewModel, Musica>(viewModel);
                repositorioMusicas.Alterar(musica);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Musicas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioMusicas.ExcluirPorId(id);
            return RedirectToAction("Index");
        }

    }
}

