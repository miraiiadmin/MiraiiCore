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
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public IActionResult Index(ContentDataViewModel data)
        
            {
                ConnectionString();
                con.Open();
                com.Connection = con;

                com.CommandText = "SELECT TOP 9 * FROM ContentData WHERE release ='yes' ORDER BY ContentDate DESC";
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
                return View(data);
            }
        
        void ConnectionString()
        {
            con.ConnectionString = "Data Source= miraii.space; Database= miraii_space; User ID=miraii_space; Password=Hostmiraii007;";
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

            return RedirectToAction("Index", "Home");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
