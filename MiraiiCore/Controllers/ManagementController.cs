using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiraiiCore.Models;

namespace MiraiiCore.Controllers
{
    public class ManagementController : Controller
    {
        MyProjectContext db = new MyProjectContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = db.ContentData.ToList();
            return View(model);
        }

        public string Welcome(string name, string id)
        {
            return $"Hello, Your name's {name}. Your ID is {id}.";
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContentDataModel model, IFormFile fileUpload)
        {

            if (fileUpload == null)
            {
                ModelState.AddModelError("errFileUpload", "The file upload field is required.");
                return View();
            }

            if (ModelState.IsValid)
            {
                string pathImgMovie = "/images/upload/";
                string pathSave = $"wwwroot{pathImgMovie}";
                if (!Directory.Exists(pathSave))
                {
                    Directory.CreateDirectory(pathSave);
                }
                string extFile = Path.GetExtension(fileUpload.FileName);
                string fileName = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + extFile;
                var path = Path.Combine(Directory.GetCurrentDirectory(), pathSave, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }

                DateTime dateNow = DateTime.Now;
                model.ContentLocation = pathImgMovie + fileName;
                model.ContentDate = dateNow.ToString();
                db.ContentData.Add(model);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            ContentDataModel content = db.ContentData.Find(id);
            db.ContentData.Remove(content);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ContentDataModel movie = db.ContentData.Find(id);
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContentDataModel model, IFormFile fileUpload)
        {
            // set old data
            db.ContentData.Attach(model);
            ContentDataModel oldContent = new MyProjectContext().ContentData.Find(model.ContentID);
            model.ContentLocation = oldContent.ContentLocation;
            oldContent = null;

            if (ModelState.IsValid)
            {
                if (fileUpload != null)
                {
                    string pathImgMovie = "/images/upload/";
                    string pathSave = $"wwwroot{pathImgMovie}";
                    if (!Directory.Exists(pathSave))
                    {
                        Directory.CreateDirectory(pathSave);
                    }
                    string extFile = Path.GetExtension(fileUpload.FileName);
                    string fileName = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + extFile;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), pathSave, fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await fileUpload.CopyToAsync(stream);
                    }
                    model.ContentLocation = pathImgMovie + fileName;
                }

                
                db.Entry(model).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
       