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

        public IActionResult Index()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-27AKM7H\\MSSQLSERVER01; database=Miraii; integrated security = SSPI;";
        }


        [HttpGet]
        public IActionResult Verify()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Verify(Admin acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from AdminLogin where username='"+acc.username+"' and password ='"+acc.password+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("FileUploader");
            }
            else
            {
                con.Close();
                return View("Index");
            }
        }
        [HttpGet]
        public IActionResult FileUploader()
        {
            return View();
        }

       
    }
}
