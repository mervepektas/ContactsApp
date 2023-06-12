using ContactsApp.Models;
using Domain.Models;
using Domain.Repositories;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactsApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        private ContactsDBContext _context;
        private IContactRepository _contactRepository;

        public ContactController(ILogger<ContactController> logger, ContactsDBContext context, IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = await _contactRepository.GetAllAsync();

            return View(contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contact.InsertedDate = DateTime.Now;
                    _contactRepository.Add(contact);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Bir hata oluştu: {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Lütfen eksik alanları doldurunuz.");

            return View(contact);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var exist = _contactRepository.FindByIdAsync(id).Result;

            return View(exist);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _contactRepository.FindByIdAsync(contact.Id).Result;

                    if (exist != null)
                    {
                        exist.FirstName = contact.FirstName;
                        exist.LastName = contact.LastName;
                        exist.EmployeeRegistrationNumber = contact.EmployeeRegistrationNumber;
                        exist.Department = contact.Department;
                        exist.Location = contact.Location;
                        exist.Position = contact.Position;
                        exist.WorkPhoneNumber = contact.WorkPhoneNumber;
                        exist.OtherWorkPhoneNumber = contact.OtherWorkPhoneNumber;
                        exist.CorporatePhoneNumber = contact.CorporatePhoneNumber;
                        exist.WalkieTalkieNumber = contact.WalkieTalkieNumber;
                        exist.Email = contact.Email;
                        exist.UpdatedDate = DateTime.Now;

                        _contactRepository.Update(exist);

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Bir hata oluştu: {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Lütfen eksik alanları doldurunuz.");

            return View(contact);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var exist = _contactRepository.FindByIdAsync(id).Result;

                if (exist != null)
                {
                    exist.IsDeleted = true;
                    exist.UpdatedDate = DateTime.Now;

                    _contactRepository.Update(exist);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"SBir hata oluştu: {ex.Message}");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}