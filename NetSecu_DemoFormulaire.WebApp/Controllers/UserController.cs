using Microsoft.AspNetCore.Mvc;
using NetSecu_DemoFormulaire.Models.Entities;
using NetSecu_DemoFormulaire.Repository; 

namespace NetSecu_DemoFormulaire.WebApp.Controllers
{
    public class UserController : Controller
    {

        IUserRepository repo;

        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
                      
            return View(repo.Get().ToList());
        }

        public IActionResult Details(Guid id)
        {
             
            return View(repo.GetById(id));

        }
    }
}
