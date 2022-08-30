using Microsoft.AspNetCore.Mvc;
using SampleCrud.Models;
using SampleCrud.Models.Contracts.AppServices;
using SampleCrud.Models.Entities;
using SampleCrud.Models.ViewModels;
using System.Diagnostics;

namespace SampleCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserAppService _userAppService;
        public HomeController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Users(CancellationToken cancellationToken)
        {
            var result = await _userAppService.GetAll(cancellationToken);
            var users = result.Select(u => new UserViewModel()
            {
                Id = u.Id,
                Name = u.Name,
                PersonnelCode = u.PersonnelCode,
                IsActive = u.IsActive,
            }).ToList();
            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
                try
                {
                    var user = new User()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        PersonnelCode = model.PersonnelCode,
                        IsActive = model.IsActive,
                    };
                    await _userAppService.Set(user, cancellationToken);
                    return RedirectToAction("Users");
                }
                catch (Exception e)
                {
                        ModelState.AddModelError("internalMessage", $"Error ! {e.Message}");                    
                }
            else
                ModelState.AddModelError("internalMessage", "Error ! Invalid input");
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id, CancellationToken cancellationToken)
        {
            var model = await _userAppService.Get(id, cancellationToken);
            var user = new UserViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                PersonnelCode = model.PersonnelCode,
                IsActive = model.IsActive,
            };
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
                try
                {
                    var user = new User()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        PersonnelCode = model.PersonnelCode,
                        IsActive = model.IsActive,
                    };
                    await _userAppService.Update(user, cancellationToken);
                    return RedirectToAction("Users");
                }
                catch (Exception e)
                {

                    ModelState.AddModelError("internalMessage", $"Error ! {e.Message}");
                }
            else
                ModelState.AddModelError("internalMessage", "Error ! Invalid input");
            return View(model);

        }
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _userAppService.Delete(id, cancellationToken);
            return RedirectToAction("Users");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}