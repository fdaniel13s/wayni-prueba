

using Microsoft.AspNetCore.Mvc;
using wayni_prueba.Application.Services;
using wayni_prueba.Domain.Entities;

namespace wayni_prueba.Web.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        //Lista vacia
        var users = new List<User>();
        return View(users);
    }

    public IActionResult Details(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            _userService.AddUser(user);
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        if (ModelState.IsValid)
        {
            _userService.UpdateUser(user);
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    public IActionResult Delete(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _userService.DeleteUser(id);
        return RedirectToAction(nameof(Index));
    }
}