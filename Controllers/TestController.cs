using ShopQuanAoLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopQuanAoLite.Controllers
{
    public class TestController : Controller
    {
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();

        // GET: Test
        public ActionResult Index()
        {
            data.SanPhamSizes.InsertOnSubmit(
                            new SanPhamSize { MaSP = 2057, MaS = 2, }
                        );
            data.SanPhamSizes.InsertOnSubmit(
                            new SanPhamSize { MaSP = 2057, MaS = 3, }
                        );
            data.SanPhamSizes.InsertOnSubmit(
                            new SanPhamSize { MaSP = 2057, MaS = 4, }
                        );
            data.SubmitChanges();
            return View();
        }
    }
}