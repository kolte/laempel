using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamsGenerator.Controllers
{
    public class CandidateController : Controller
    {
        [Authorize(Roles="Candidate")]
        public IActionResult Index()
        {
            return View();
        }
    }
}