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
        public IActionResult B2020_09_19_My_Rhythm(ContentDataViewModel YouMay)
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

            return View("~/Views/Read/Blog/B2020_09_19_My_Rhythm.cshtml", YouMay);
        }

        
        [Route("/blog/kimetsu-no-yaiba-mugen-train")]
        public IActionResult B2020_09_26_Yaiba_mugen_train(ContentDataViewModel YouMay)
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

            return View("~/Views/Read/Blog/B2020_09_26_Yaiba_mugen_train.cshtml", YouMay);
        }

        [Route("/blog/kimetsunoyaibataisho")]
        public IActionResult B2020_09_12_Yaiba_taisho(ContentDataViewModel YouMay)
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

            return View("~/Views/Read/Blog/B2020_09_12_Yaiba_taisho.cshtml", YouMay);
        }

        [Route("/blog/rikuoh")]
        public IActionResult B2020_09_05_Rikuoh(ContentDataViewModel YouMay)
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

            return View("~/Views/Read/Blog/B2020_09_05_Rikuoh.cshtml", YouMay);
        }

        [Route("/blog/comebackofmovieindustry")]
        public IActionResult B2020_08_31_Comeback_Of_Movie_Industry(ContentDataViewModel YouMay)
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

            return View("~/Views/Read/Blog/B2020_08_31_Comeback_Of_Movie_Industry.cshtml", YouMay);
        }

        [Route("/blog/bts")]
        public IActionResult B2020_08_26_BTS()
        {
            return View("~/Views/Read/Blog/B2020_08_26_BTS.cshtml");
        }

        [Route("/blog/tenet")]
        public IActionResult B2020_08_22_Tenet()
        {
            return View("~/Views/Read/Blog/B2020_08_22_Tenet.cshtml");
        }

        [Route("/blog/sevenskillsforfreshgraduate")]
        public IActionResult B2020_08_21_Seven_Skills()
        {
            return View("~/Views/Read/Blog/B2020_08_21_Seven_Skills.cshtml");
        }

        [Route("/blog/projectpowernetflix")]
        public IActionResult B2020_08_16_Project_Power()
        {
            return View("~/Views/Read/Blog/B2020_08_16_Project_Power.cshtml");
        }

        [Route("/blog/valorant")]
        public IActionResult B2020_08_17_Valorant()
        {
            return View("~/Views/Read/Blog/B2020_08_17_Valorant.cshtml");
        }
    }
}