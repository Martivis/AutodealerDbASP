using System;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using AutodealerDbASP.Models.News;
using PagedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace AutodealerDbASP.Controllers
{
    public class NewsController : Controller
    {

        NewsDBStorage _storage = new NewsDBStorage(new NewsContext());

        // метод для передачи всех новостей в представление
        public ActionResult NewsList(int? page)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(_storage.GetAll().OrderBy(p => p.NewsId).ToPagedList(pageNumber, pageSize));
        }
        //Get - метод для изменения новости
        [HttpGet]
        public ActionResult NewsEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            News news = _storage.Get(id);

            if (news != null)
            {
                return View(news);
            }
            return NotFound();

        }
        //Post - метод для изменения новости
        [HttpPost]
        public ActionResult NewsEdit(News model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.DateTime = DateTime.Now;
            _storage.Edit(model);
            return RedirectToAction("NewsList");
            
        }
        //Get - метод для удаления новости
        [HttpGet]
        public ActionResult DeleteNews(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            News news = _storage.Get(Id);

            if (news != null)
            {
                return View(news);
            }
            return NotFound();

        }
        //Post - метод для удаления новости
        [HttpPost, ActionName("DeleteNews")]
        public ActionResult DeleteNewsConfirmed(int Id)
        {
            _storage.Delete(Id);
            return RedirectToAction("NewsList");
        }
        //Get - метод для добавления новости
        [HttpGet]
        public ActionResult AddNews()
        {

            return View(new News());
        }
        //Post - метод для добавления новости
        [HttpPost]
        public ActionResult AddNews(News model)
        {
            model.DateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                _storage.Add(model);
                return RedirectToAction("NewsList");
            }
            return View(model);
        }
        // метод для получения информации о вопросе
        [HttpGet]
        public ActionResult NewsInfo(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            return View(_storage.Get(Id));
        }

    }
}