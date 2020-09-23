using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void ConnectionString()
        {
            con.ConnectionString = "Data Source= miraii.space; Database= miraii_space; User ID=miraii_space; Password=Hostmiraii007;";
        }

        MyProjectContext db = new MyProjectContext();

        [Route("/management")]
        public IActionResult Index(AdminViewModel acc)
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                return View("Login");
            }
            else
            {
                var model = db.ContentData.ToList();
                return View(model);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(AdminViewModel acc)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from AdminLogin where username='" + acc.username + "' and password ='" + acc.password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                HttpContext.Session.SetString("Username", acc.username);
                ViewBag.data = HttpContext.Session.GetString("Username");
                return RedirectToAction("Index");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View("Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContentDataModel model, IFormFile fileUpload)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View("Login");
            }
            else
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

                    model.ContentLocation = pathImgMovie + fileName;
                    db.ContentData.Add(model);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            ContentDataModel content = db.ContentData.Find(id);
            db.ContentData.Remove(content);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View("Login");
            }
            else
            {
                ContentDataModel content = db.ContentData.Find(id);
                return View(content);
            }
        }
        [HttpPost]
        public ActionResult Update(ContentDataModel content)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;

            com.CommandText = "UPDATE ContentData SET ContentName=@ContentName, ContentDescription=@ContentDescription, Action=@Action, Controller=@Controller, Release=@Release, ContentCategory=@ContentCategory WHERE ContentId=@ContentID";

            com.Parameters.AddWithValue("@ContentID", content.ContentID);
            com.Parameters.AddWithValue("@ContentName", content.ContentName);
            com.Parameters.AddWithValue("@ContentDescription", content.ContentDescription);
            com.Parameters.AddWithValue("@Action", content.Action);
            com.Parameters.AddWithValue("@Controller", content.Controller);
            com.Parameters.AddWithValue("@Release", content.Release);
            com.Parameters.AddWithValue("@ContentCategory", content.ContentCategory);
            com.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Logout");
        }

        [HttpGet]
        public IActionResult Search(string text, ContentDataViewModel data)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View("Login");
            }
            else
            {
                ConnectionString();
                con.Open();
                com.Connection = con;

                com.CommandText = "SELECT * FROM ContentData WHERE ContentName like '%" + text + "%'";
                dr = com.ExecuteReader();
                List<ContentDataViewModel> objmodel = new List<ContentDataViewModel>();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var details = new ContentDataViewModel();
                        details.ContentID = dr["ContentID"].ToString();
                        details.ContentLocation = dr["ContentLocation"].ToString();
                        details.ContentName = dr["ContentName"].ToString();
                        details.ContentCategory = dr["ContentCategory"].ToString();
                        details.ContentDescription = dr["ContentDescription"].ToString();
                        details.ContentDate = dr["ContentDate"].ToString();
                        details.ContentWriter = dr["ContentWriter"].ToString();
                        details.Controller = dr["Controller"].ToString();
                        details.Action = dr["Action"].ToString();
                        details.Release = dr["Release"].ToString();
                        objmodel.Add(details);
                    }
                    data.ContentInfo = objmodel;
                }
                else
                {
                    return View("Error");
                }
                con.Close();
                ModelState.Clear();
                return View("Search", data);
            }
        }

    }
}
       