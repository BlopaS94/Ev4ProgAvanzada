using Microsoft.AspNetCore.Mvc;
using Ev4ProgAvanzada.Data;
using Ev4ProgAvanzada.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Ev4ProgAvanzada.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Mostrar formulario de login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Verificar si el usuario existe
            var user = _context.Usuarios.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                ViewBag.Error = "El correo electrónico no está registrado.";
                return View();
            }

            // Validar la contraseña
            if (user.Password != password)
            {
                ViewBag.Error = "La contraseña es incorrecta.";
                return View();
            }

            // Almacenar datos del usuario en la sesión
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("UserRole", user.Rol);
            HttpContext.Session.SetString("UserName", user.Nombre);

            // Redirigir según el rol del usuario
            if (user.Rol == "Administrador")
            {
                return RedirectToAction("Index", "Proyectoes");
            }
            else if (user.Rol == "Agente")
            {
                return RedirectToAction("Index", "AgendaClientes");
            }
            else
            {
                ViewBag.Error = "Rol desconocido.";
                return View();
            }
        }

        // Cerrar sesión
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
    }
}
