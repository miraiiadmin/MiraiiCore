using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiraiiCore.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MiraiiCore.Controllers
{
    public class ContentDataController : Controller
    {
        public IActionResult Search (string ContentSearch)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "selct * from [dbo].[ContentData] where ContentName like '%" + ContentSearch + "%' ";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter (sqlcomm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<ContentDataViewModel> ec = new List<ContentDataViewModel>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ec.Add(new ContentDataViewModel
                {
                    ContentLocation = Convert.ToString(dr["image"]),
                    ContentName = Convert.ToString(dr["name"]),
                    ContentCategory = Convert.ToString(dr["category"]),
                    ContentDescription = Convert.ToString(dr["description"]),
                    ContentDate = Convert.ToDateTime(dr["date"])
                });
            }

            sqlconn.Close();
            ModelState.Clear();
            return View(ec);
        }
    }
}
