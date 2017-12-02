using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Lancher.Models;

namespace Lancher.Controllers
{
    public class LastAdminController : Controller
    {
        // GET: LastAdmin
        public ActionResult Adminnnnnn()
        {
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user";
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            con.Open();
            var model = new List<user>();
            MySqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    var User = new user();
                    User.EmailID = dr.GetString(0);
                    User.StatusS = dr.GetString(11);
                    model.Add(User);

                }
                con.Clone();
            }
            catch
            {

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Ban()
        {
            string Id = Request.Form["111"];
            string Status = Request.Form["Statuss"].ToString();
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");//

            string strSQL = "UPDATE user SET StatusS = '" + Status + "' WHERE EmailID = '" + Id + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            cmd.ExecuteNonQuery();
            return RedirectToAction("Adminnnnnn", "LastAdmin");
        }
        public ActionResult News()
        {

            return RedirectToAction("Newssssss", "Newssss");
        }
    }
}