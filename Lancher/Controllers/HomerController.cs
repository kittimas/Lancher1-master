﻿using Lancher.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lancher.Controllers
{
    public class HomerController : Controller
    {
        // GET: Homer
        
        public ActionResult FirstPage()
        {
        
            string email = Session["email"].ToString();
            MySqlConnection con = new MySqlConnection("host=localhost;user=Lancher;password=123456;database=lancherdb");
            string strSQL = "SELECT * FROM user WHERE EmailID = '" + email + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(strSQL, con);
            var model = new List<user>();

            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            var User = new user();
            User.StatusUser = dr.GetString(10);
            User.StatusS = dr.GetString(11);
            ViewBag.StatusS = User.StatusS;
            ViewBag.sdsdsdsd = User.StatusUser;
            User.ImgUser = dr.GetString(9);
            Session["Photo"] = User.ImgUser;
            User.ImgUser = Session["Photo"].ToString();
            model.Add(User);

            return View(model);
        }

        public ActionResult Homepage()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Loginn", "Loginn");
;        }
        public ActionResult Admin()
        {
            return RedirectToAction("Adminnnnnn", "LastAdmin");
        }
    }
}