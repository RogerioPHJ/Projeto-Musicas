using FS.Musicas.AcessoDados.Entity.Context;
using FS.Musicas.Web.Identity;
using FS.Musicas.Web.ViewModels.Usuario;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FS.Musicas.Web.Controllers
{
    [AllowAnonymous]
    public class UsuariosController : Controller
    {
        //GET CRIAR USUARIO

        public ActionResult CriarUsuario()
        {
            return View();
        }

        //POST CRIAR USUARIO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarUsuario(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid) {
                var userStore = new UserStore<IdentityUser>(new MusicasIdentityDbContext()); //Cuida do armazenamento dos usuarios
                var userManager = new UserManager<IdentityUser>(userStore); //Controla as regras de validação dos usuarios
                var identityUser = new IdentityUser  
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };
                IdentityResult resultado = userManager.Create(identityUser, viewModel.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("erro_identity", resultado.Errors.First());
                    return View(viewModel);
                }

            }
            return View(viewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new MusicasIdentityDbContext()); //Cuida do armazenamento dos usuarios
                var userManager = new UserManager<IdentityUser>(userStore); //Controla as regras de validação dos usuarios
                var usuario = userManager.Find(viewModel.Email, viewModel.Senha);
                if (usuario == null)
                {
                    ModelState.AddModelError("erro_identity", "Usuario e/ou Senha incorretos");
                    return View(viewModel);
                }
                var authManager = HttpContext.GetOwinContext().Authentication;
                var identity = userManager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                {
                    IsPersistent = false

                }, identity);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Logoff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}