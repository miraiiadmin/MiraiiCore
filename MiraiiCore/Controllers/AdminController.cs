using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiraiiCore.Models;
using System.Data.SqlClient;

namespace MiraiiCore.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public IActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "Data Source= miraii.space; Database= miraii_space; User ID=miraii_space; Password=Hostmiraii007;";
        }

        [HttpGet]
        public IActionResult Verify()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Verify(AdminViewModel acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from AdminLogin where username='"+acc.username+"' and password ='"+acc.password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Uploader");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
        [HttpGet]
        public IActionResult Uploader()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
