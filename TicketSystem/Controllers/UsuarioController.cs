using Microsoft.AspNetCore.Mvc;
using TicketSystem.DTOs;
using TicketSystem.Validations; 

namespace TicketSystem.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Usuarios _usuarios; 

        public UsuarioController(Usuarios usuarios)
        {
            _usuarios= usuarios;
        }

        [ValidateLogin]
        public IActionResult Index()
        {
            return View(_usuarios.lista_usuarios);
        }

        [ValidateLogin]
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [ValidateLogin]
        [HttpPost]
        public IActionResult Create(Usuario nuevoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return View(nuevoUsuario); 
            }

            //Revisar que el nombre de usuario no este duplicado. 
            foreach(Usuario usuario in _usuarios.lista_usuarios)
            {
                if(usuario.nombre_usuario == nuevoUsuario.nombre_usuario)
                {
                    ModelState.AddModelError(
                            "nombre_usuario",
                            "El nombre de usuario ya existe"
                        );

                    return View(nuevoUsuario); 
                }
            }

            //Agregar un usuario nuevo a la lista
            _usuarios.lista_usuarios.Add(nuevoUsuario);
            TempData["Success"] = "El usario fue agregado correctamente"; 

            return RedirectToAction("Index");
        }

        [ValidateLogin]
        [HttpGet]
        public IActionResult Edit(string nombre_usuario)
        {
            Usuario? usuarioEncontrado = null; 

            foreach(Usuario usuario in _usuarios.lista_usuarios)
            {
                if(usuario.nombre_usuario == nombre_usuario)
                {
                    usuarioEncontrado= usuario;
                    break; 
                }
            }

            if(usuarioEncontrado == null)
            {
                return NotFound(); 
            }

            return View(usuarioEncontrado);
        }

        [ValidateLogin]
        [HttpPost]
        public IActionResult Edit(Usuario usuarioEncontrado)
        {
            if(!ModelState.IsValid)
            {
                return Edit(usuarioEncontrado);
            }

            foreach(Usuario usuario in _usuarios.lista_usuarios)
            {
                if(usuario.nombre_usuario == usuarioEncontrado.nombre_usuario)
                {
                    usuario.nombre = usuarioEncontrado.nombre;
                    usuario.apellido = usuarioEncontrado.apellido; 
                    usuario.password = usuarioEncontrado.password;
                    usuario.isAdmin = usuarioEncontrado.isAdmin;
                }

                break; 
            }

            TempData["Success"] = "El usuario fue actualizado correctamente"; 

            return RedirectToAction("Index");

        }

        [ValidateLogin]
        [HttpGet]
        public IActionResult Delete(string nombre_usuario)
        {
            Usuario? usuarioEncontrado = null; 

            foreach(Usuario usuario in _usuarios.lista_usuarios)
            {
                if(usuario.nombre_usuario == nombre_usuario)
                {
                    usuarioEncontrado = usuario;
                    break; 
                }
            }

            if(usuarioEncontrado == null)
            {
                return NotFound(); 
            }

            return View(usuarioEncontrado);
        }

        [ValidateLogin]
        [HttpPost]
        public IActionResult DeleteConfirmed(string nombre_usuario)
        {
            Usuario? usuarioEncontrado = null;

            foreach (Usuario usuario in _usuarios.lista_usuarios)
            {
                if (usuario.nombre_usuario == nombre_usuario)
                {
                    usuarioEncontrado = usuario;
                    break;
                }
            }

            if (usuarioEncontrado == null)
            {
                return NotFound();
            }

            _usuarios.lista_usuarios.Remove(usuarioEncontrado);

            TempData["Success"] = "El usuario fue elimanado correctamente";

            return RedirectToAction("Index"); 

        }

    }
}
