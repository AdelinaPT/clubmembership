using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Repository;
using Microsoft.AspNetCore.Authorization;
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
            var list = announcementRepository.GetAllAnnouncements();
            return View(list);
        }

        // GET: AnnouncementControllercs/Details/5
        public ActionResult Details(Guid id)
        {
            var model = announcementRepository.GetAnnouncementById(id);
            return View("DetailsAnnouncement", model);
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

                return RedirectToAction("Index");
            }
            catch(Exception error)
            {
                return View("CreateAnnouncement");
            }
        }

        // GET: AnnouncementControllercs/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = announcementRepository.GetAnnouncementById(id);
            return View("EditAnnouncement", model);
        }

        // POST: AnnouncementControllercs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new AnnouncementModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    announcementRepository.UpdateAnnouncement(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: AnnouncementControllercs/Delete/5
        [Authorize(Roles = "User, Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = announcementRepository.GetAnnouncementById(id);
            return View("DeleteAnnouncement", model);
        }

        // POST: AnnouncementControllercs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                announcementRepository.DeleteAnnouncement(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
