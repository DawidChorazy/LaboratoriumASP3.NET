using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers;

public class ContactController : Controller
{

    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    // Contact list
    public IActionResult Index()
    {
        return View(_contactService.GetAll());
    }

    // Adding contact form
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    // Getting and saving new contact
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        else
        {
            _contactService.Add(model);
            return RedirectToAction(nameof(Index));
        }
    }

    public IActionResult Delete(int id)
    {
        _contactService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    public ActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }

    [HttpPost]
    public ActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _contactService.Update(model);
        return RedirectToAction(nameof(Index));
    }
    
}