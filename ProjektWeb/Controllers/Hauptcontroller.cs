using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektWeb.Models.DB;
using ProjektWeb.Models;

namespace ProjektWeb.Controllers
{
    public class Hauptcontroller : Controller
    {
        private readonly DbManager _dbManager;


        public Hauptcontroller(DbManager dbManager)
        {
            this._dbManager = dbManager;
        }

        public async Task<IActionResult> EinUser()
        {   

            
            return View(await this._dbManager.Users.FindAsync(2));
        }

        public async Task<IActionResult> AllUsers()
        {   

            
            return View(await this._dbManager.Users.ToListAsync());
        }

        [HttpGet]
        public IActionResult Register()
        {
            User u = new User()
            {
                Firstname = "Max",
                Lastname = "Mustermann",
                Birthdate = DateTime.Parse("13/3/2004")
            };
            return View(u);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (user == null)
            {
                return View();
            }

            if (user.Lastname == null || user.Lastname.Trim().Length < 3)
            {

                ModelState.AddModelError("Lastname", "Nachname muss mindestens 3 Zeichen Lang sein!");
            }

            if (user.Birthdate > DateTime.Now)
            {
                ModelState.AddModelError("Birthdate", "Bitte gültiges Datum eingeben!");
            }

            if (user.Hobbies == null || user.Hobbies.Trim().Length < 10)
            {
                ModelState.AddModelError("Hobbies", "Bitte geben Sie ihre Hobbies an!");
            }



            if (ModelState.IsValid)
            {

                this._dbManager.Users.Add(user);
                int result = await this._dbManager.SaveChangesAsync();

                if (result == 0)
                {



                    return View("Message", new Message()
                    {
                        Title = "Registrierung",
                        MessageText = "Sie konnten leider nicht registriert werden",
                        Solution = "Bitte versuchen Sie es später erneut",

                    });

                }
                else
                {

                    return View("Message", new Message()
                    {
                        Title = "Registrierung",
                        MessageText = "Sie wurden erfolgreich registriert",

                    });

                }

            }

            return View(user);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
