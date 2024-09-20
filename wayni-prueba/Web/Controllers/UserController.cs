using Microsoft.AspNetCore.Mvc;
using wayni_prueba.Application.Services;
using wayni_prueba.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace wayni_prueba.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly ILogger<UserController> _logger;

        // Constructor para inyección de dependencias
        public UserController(UserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // Acción para mostrar la lista de usuarios
        public IActionResult Index()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        // Acción para mostrar los detalles de un usuario específico
        public IActionResult Details(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound(); // Retorna un 404 si el usuario no existe
            }
            return View(user);
        }

        // Acción para mostrar el formulario de creación de un nuevo usuario
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Acción para manejar la creación de un nuevo usuario
        [HttpPost]
        public IActionResult Create(User user)
        {
            _logger.LogDebug("Entering Create action with user: {@User}", user);

            // Verifica si el modelo es válido antes de procesar
            if (ModelState.IsValid)
            {
                _userService.AddUser(user);
                _logger.LogDebug("User created successfully: {@User}", user);
                return RedirectToAction(nameof(Index)); // Redirige a la lista de usuarios
            }

            // Si el modelo no es válido, vuelve a mostrar el formulario con los errores
            _logger.LogDebug("ModelState is invalid: {@ModelState}", ModelState);
            return View(user);
        }

        // Acción para mostrar el formulario de edición de un usuario
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound(); // Retorna un 404 si el usuario no existe
            }
            return View(user);
        }

        // Acción para manejar la actualización de un usuario existente
        [HttpPost]
        public IActionResult Edit(User user)
        {
            _logger.LogDebug("Entering Update action with user: {@User}", user);

            // Verifica si el modelo es válido antes de procesar
            if (ModelState.IsValid)
            {
                _userService.UpdateUser(user);
                _logger.LogDebug("User updated successfully: {@User}", user);
                return RedirectToAction(nameof(Index)); // Redirige a la lista de usuarios
            }

            // Si el modelo no es válido, vuelve a mostrar el formulario con los errores
            _logger.LogDebug("ModelState is invalid: {@ModelState}", ModelState);
            return View("Edit", user);
        }

        // Acción para mostrar la confirmación de eliminación de un usuario
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound(); // Retorna un 404 si el usuario no existe
            }
            return View(user);
        }

        // Acción para manejar la eliminación de un usuario
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index)); // Redirige a la lista de usuarios después de eliminar
        }
    }
}
