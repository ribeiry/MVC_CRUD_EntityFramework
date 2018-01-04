using MVC_CRUD_EF_WebGrid.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVC_CRUD_EF_WebGrid.Controllers
{
    public class UsuarioController:Controller
    {
        private IUsuarioRepositorio rep = null;

        public UsuarioController()
        {
            this.rep = new UsuarioRepositorio();
        }
        private UsuarioController(IUsuarioRepositorio repositorio)
        {
            this.rep = repositorio;
        }

        //GET: Usuario

        public ActionResult Index()
        {
            var listaUsuario = from usuario in rep.GetUsuarioDetalhes() select usuario;
            return View(listaUsuario);
        }

        public ActionResult AdicionarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarUsuario(Usuario usuario)
        {
            rep.AdicionaUsuario(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult EditarUsuario(int id = 0)
        {
            Usuario usuario = rep.GetUsuarioPorID(id);
            if(usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult EditarUsuario(Usuario usuario)
        {
            rep.AtualizaUsuario(usuario);
            return RedirectToAction("Index");
        }

        public ActionResult DeletarUsuario(int id = 0)
        {
            Usuario usuario = rep.GetUsuarioPorID(id);
            if(usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult DeletarUsuario(Usuario usuario)
        {
            rep.DeletaUsuario(usuario.usuarioID);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int id = 0)
        {
            Usuario usuario = rep.Detalhes(id);

            return View(usuario);
        }

    }
}