﻿using System;
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
    public class Review : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public IActionResult Index(ContentDataViewModel data)

        {
            ConnectionString();
            con.Open();
            com.Connection = con;

            com.CommandText = "SELECT TOP 9 * FROM ContentData WHERE ContentCategory = 'Review' AND release = 'yes' ORDER BY ContentDate DESC";
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
            return View("~/Views/Read/Review/Index.cshtml", data);
        }
        void ConnectionString()
        {
            con.ConnectionString = "Data Source= miraii.space; Database= miraii_space; User ID=miraii_space; Password=Hostmiraii007;";
        }

        [Route("/review/hamilton")]
        public IActionResult R2020_08_28_Hamilton()
        {
            return View("~/Views/Read/Review/R2020_08_28_Hamilton.cshtml");
        }
    }
}