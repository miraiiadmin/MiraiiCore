using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiraiiCore.Models;

namespace MiraiiCore.Controllers
{
    public class AboutController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public IActionResult Index()
        {
            return View();
        }

        void ConnectionString()
        {
            con.ConnectionString = "Data Source=DESKTOP-27AKM7H\\MSSQLSERVER01;Initial Catalog=Miraii;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        [HttpPost]
        public IActionResult Feedback(FeedbackModel insertFeedback) //Insert Feedback Action
        {
            DateTime date = DateTime.Now;
            ConnectionString();
            con.Open();

            com.Connection = con;
            com.CommandText = "INSERT INTO Feedback(Feedback,Date) VALUES (@Feedback,@Date)";

            com.Parameters.AddWithValue("@Feedback", insertFeedback.Feedback);
            com.Parameters.AddWithValue("@Date", date.ToString());
            com.ExecuteNonQuery();
            con.Close();

            return RedirectToAction("Index", "About");

        }

    }
}