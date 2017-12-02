using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace Lancher.Controllers
{
    public class NewssssController : Controller
    {
        // GET: Newssss
        public ActionResult Newssssss()
        {
            return View();
        }
        public ActionResult Submit()
        {
            string Head = Request.Form["Head"];
            string picture = Request.Form["picture"];
            string title = Request.Form["title"];
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-15IPMV7\SQLEXPRESS;Initial Catalog=news;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into new values ('"+Head+"','"+picture+"','"+title+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
            return View();
        }
    }
}