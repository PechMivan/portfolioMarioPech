using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Services;
using System.Diagnostics;
using Vereyon.Web;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectRepository projectRepository;
        private readonly IFlashMessage _flashMessage;
        private readonly IEmailService emailService;

        public HomeController(IProjectRepository projectRepository, IFlashMessage flashMessage, IEmailService emailService)
        {
            this.projectRepository = projectRepository;
            _flashMessage = flashMessage;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            var projects = projectRepository.getProjects();
            return View(projects);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel contactViewModel)
        {
            await emailService.Send(contactViewModel);
            _flashMessage.Confirmation("Your message has been successfully sent");
            return RedirectToAction("Contact");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}