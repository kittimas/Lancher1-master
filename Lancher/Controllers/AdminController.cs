using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lancher.Models;
using MySql.Data.MySqlClient;

namespace Lancher.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpPost]
        public ActionResult Admin()
        {
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user WHERE StatusUser = '"+ "User" + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            MySqlDataReader rd = cmd.ExecuteReader();
            var model = new List<user>();
            try
            {
                while (rd.Read())
                {
                    var User = new user();
                    User.EmailID = rd.GetString(0);
                    User.Status = rd.GetString(11);
                    model.Add(User);
                }
                con.Close();
            }
            catch
            {

            }
            return View(model);

        }
        public ActionResult Ban()
        {
            var model = new List<user>();
            var User = new user();
            string  Email = User.EmailID;  
            string status = Request.Form["Status"];
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "UPDATE user SET Status = '"+ status + "'  WHERE EmailID = '"+ Email + "'";
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            MySqlDataReader rd = cmd.ExecuteReader();
            con.Open();
            System.Diagnostics.Debug.WriteLine(strSQL);
            return RedirectToAction("Admin");
        }
    }
}