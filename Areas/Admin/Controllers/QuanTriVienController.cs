﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAoLite.Areas.Admin.Controllers
{
    public class QuanTriVienController : Controller
    {
        // GET: Admin/QuanTriVien
        public ActionResult Index()
        {
            if (Session["Taikhoanadmin"] == null || Session["Taikhoanadmin"].ToString() == "")
            {
                return Redirect("~/Admin/Login");
            }
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
    }
}