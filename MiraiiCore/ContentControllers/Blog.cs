using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiraiiCore.Models;

namespace MiraiiCore.Controllers
{
    public class Blog : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void ConnectionString()
        {
            con.ConnectionString = "Data Source= miraii.space; Database= miraii_space; User ID=miraii_space; Password=Hostmiraii007;";
        }


        
        public IActionResult Index(ContentDataViewModel data)

        {
            ConnectionString();
            con.Open();
            com.Connection = con;

            com.CommandText = "SELECT TOP 9 * FROM ContentData WHERE ContentCategory = 'Blog' AND release = 'yes' ORDER BY ContentDate DESC";
            dr = com.ExecuteReader();
            List<ContentDataViewModel> objmodel = new List<ContentDataViewModel>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    var details = new ContentDataViewModel();
                    details.ContentLocation = dr["ContentLocation"].ToString();
                    details.ContentName = dr["ContentName"].ToString();
                    details.ContentCategory = dr["ContentCategory"].ToString();
                    details.ContentDescription = dr["ContentDescription"].ToString();
                    details.ContentDate = dr["ContentDate"].ToString();
                    details.ContentWriter = dr["ContentWriter"].ToString();
                    details.Controller = dr["Controller"].ToString();
                    details.Action = dr["Action"].ToString();
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
            return View("~/Views/Read/Blog/Index.cshtml", data);
        }


        
        public IActionResult T(ContentDataViewModel data)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;

            com.CommandText = "SELECT TOP 2 * FROM ContentData WHERE ContentCategory = 'Blog' AND release = 'yes' ORDER BY NEWID ()";
            dr = com.ExecuteReader();
            List<ContentDataViewModel> objmodel = new List<ContentDataViewModel>();
                while (dr.Read())
                {
                    var details = new ContentDataViewModel();
                    details.ContentLocation = dr["ContentLocation"].ToString();
                    details.ContentName = dr["ContentName"].ToString();
                    details.ContentCategory = dr["ContentCategory"].ToString();
                    details.ContentDate = dr["ContentDate"].ToString();
                    details.ContentWriter = dr["ContentWriter"].ToString();
                    details.Controller = dr["Controller"].ToString();
                    details.Action = dr["Action"].ToString();
                    objmodel.Add(details);
                }
                data.ContentInfo = objmodel;
            con.Close();
            ModelState.Clear();

            return View("~/Views/Read/Blog/T.cshtml", data);
        }

        [Route("/blog/my-rhythm")]
        public IActionResult MyRhythm(ContentDataViewModel YouMay)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;

            com.CommandText = "SELECT TOP 2 * FROM ContentData WHERE ContentCategory = 'Blog' AND release = 'yes' ORDER BY NEWID ()";
            dr = com.ExecuteReader();
            List<ContentDataViewModel> objmodel = new List<ContentDataViewModel>();
            while (dr.Read())
            {
                var details = new ContentDataViewModel();
                details.ContentLocation = dr["ContentLocation"].ToString();
                details.ContentName = dr["ContentName"].ToString();
                details.ContentCategory = dr["ContentCategory"].ToString();
                details.ContentDate = dr["ContentDate"].ToString();
                details.ContentWriter = dr["ContentWriter"].ToString();
                details.Controller = dr["Controller"].ToString();
                details.Action = dr["Action"].ToString();
                objmodel.Add(details);
            }
            YouMay.ContentInfo = objmodel;
            con.Close();
            ModelState.Clear();

            return View("~/Views/Read/Blog/MyRhythm.cshtml", YouMay);
        }

        public IActionResult Kimetsunoyaiba(ContentDataViewModel YouMay)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;

            com.CommandText = "SELECT TOP 2 * FROM ContentData WHERE ContentCategory = 'Blog' AND release = 'yes' ORDER BY NEWID ()";
            dr = com.ExecuteReader();
            List<ContentDataViewModel> objmodel = new List<ContentDataViewModel>();
            while (dr.Read())
            {
                var details = new ContentDataViewModel();
                details.ContentLocation = dr["ContentLocation"].ToString();
                details.ContentName = dr["ContentName"].ToString();
                details.ContentCategory = dr["ContentCategory"].ToString();
                details.ContentDate = dr["ContentDate"].ToString();
                details.ContentWriter = dr["ContentWriter"].ToString();
                details.Controller = dr["Controller"].ToString();
                details.Action = dr["Action"].ToString();
                objmodel.Add(details);
            }
            YouMay.ContentInfo = objmodel;
            con.Close();
            ModelState.Clear();

            return View("~/Views/Read/Blog/Kimetsunoyaiba.cshtml", YouMay);
        }

        public IActionResult Kimetsunoyaibataisho(ContentDataViewModel YouMay)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;

            com.CommandText = "SELECT TOP 2 * FROM ContentData WHERE ContentCategory = 'Blog' AND release = 'yes' ORDER BY NEWID ()";
            dr = com.ExecuteReader();
            List<ContentDataViewModel> objmodel = new List<ContentDataViewModel>();
            while (dr.Read())
            {
                var details = new ContentDataViewModel();
                details.ContentLocation = dr["ContentLocation"].ToString();
                details.ContentName = dr["ContentName"].ToString();
                details.ContentCategory = dr["ContentCategory"].ToString();
                details.ContentDate = dr["ContentDate"].ToString();
                details.ContentWriter = dr["ContentWriter"].ToString();
                details.Controller = dr["Controller"].ToString();
                details.Action = dr["Action"].ToString();
                objmodel.Add(details);
            }
            YouMay.ContentInfo = objmodel;
            con.Close();
            ModelState.Clear();

            return View("~/Views/Read/Blog/Kimetsunoyaibataisho.cshtml", YouMay);
        }

        public IActionResult Rikuoh(ContentDataViewModel YouMay)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;

            com.CommandText = "SELECT TOP 2 * FROM ContentData WHERE ContentCategory = 'Blog' AND release = 'yes' ORDER BY NEWID ()";
            dr = com.ExecuteReader();
            List<ContentDataViewModel> objmodel = new List<ContentDataViewModel>();
            while (dr.Read())
            {
                var details = new ContentDataViewModel();
                details.ContentLocation = dr["ContentLocation"].ToString();
                details.ContentName = dr["ContentName"].ToString();
                details.ContentCategory = dr["ContentCategory"].ToString();
                details.ContentDate = dr["ContentDate"].ToString();
                details.ContentWriter = dr["ContentWriter"].ToString();
                details.Controller = dr["Controller"].ToString();
                details.Action = dr["Action"].ToString();
                objmodel.Add(details);
            }
            YouMay.ContentInfo = objmodel;
            con.Close();
            ModelState.Clear();

            return View("~/Views/Read/Blog/Rikuoh.cshtml", YouMay);
        }

        public IActionResult ComebackOfMovieIndustry(ContentDataViewModel YouMay)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;

            com.CommandText = "SELECT TOP 2 * FROM ContentData WHERE ContentCategory = 'Blog' AND release = 'yes' ORDER BY NEWID ()";
            dr = com.ExecuteReader();
            List<ContentDataViewModel> objmodel = new List<ContentDataViewModel>();
            while (dr.Read())
            {
                var details = new ContentDataViewModel();
                details.ContentLocation = dr["ContentLocation"].ToString();
                details.ContentName = dr["ContentName"].ToString();
                details.ContentCategory = dr["ContentCategory"].ToString();
                details.ContentDate = dr["ContentDate"].ToString();
                details.ContentWriter = dr["ContentWriter"].ToString();
                details.Controller = dr["Controller"].ToString();
                details.Action = dr["Action"].ToString();
                objmodel.Add(details);
            }
            YouMay.ContentInfo = objmodel;
            con.Close();
            ModelState.Clear();

            return View("~/Views/Read/Blog/ComebackOfMovieIndustry.cshtml", YouMay);
        }

        public IActionResult BTS()
        {
            return View("~/Views/Read/Blog/BTS.cshtml");
        }
        public IActionResult Tenet()
        {
            return View("~/Views/Read/Blog/Tenet.cshtml");
        }

        public IActionResult SevenSkillsForFreshGraduate()
        {
            return View("~/Views/Read/Blog/SevenSkillsForFreshGraduate.cshtml");
        }

        public IActionResult ProjectPowerNetflix()
        {
            return View("~/Views/Read/Blog/ProjectPowerNetflix.cshtml");
        }

        public IActionResult Valorant()
        {
            return View("~/Views/Read/Blog/Valorant.cshtml");
        }
    }
}