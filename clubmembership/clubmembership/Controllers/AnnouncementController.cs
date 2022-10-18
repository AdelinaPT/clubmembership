using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clubmembership.Controllers
{
    public class AnnouncementController : Controller
    {
        private AnnouncementRepository announcementRepository;

        public AnnouncementController(ApplicationDbContext dbContext)
        {
            announcementRepository = new AnnouncementRepository(dbContext);
        }
        // GET: AnnouncementControllercs
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnnouncementControllercs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnnouncementControllercs/Create
        public ActionResult Create()
        {
            return View("CreateAnnouncement");
        }

        // POST: AnnouncementControllercs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new AnnouncementModel();                
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    announcementRepository.InsertAnnouncement(model);
                }

                return View("Index");
            }
            catch(Exception error)
            {
                return View("CreateAnnouncement");
            }
        }

        // GET: AnnouncementControllercs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnnouncementControllercs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementControllercs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnnouncementControllercs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
