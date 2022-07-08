using ShopQuanAoLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopQuanAoLite.Controllers
{
    public class NguoiDungController : Controller
    {
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile(KhachHang khachhang)
        {
            return View(khachhang);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "ShopQuanAo");
        }
        [HttpGet]
        public PartialViewResult DangKy()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KhachHang kh)
        {
            // Gán các giá tị người dùng nhập liệu cho các biến 
            var tendangnhap = collection["TenDangnhap"];
            var matkhau = collection["MatKhau"];
            var nhaplaimatkhau = collection["NhapLaiMatkhau"];
            var hoten = collection["HoTen"];
            var diachi = collection["Diachi"];
            var email = collection["Email"];
            var sodienthoai = collection["SoDienthoai"];
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["hoten"] = "Họ tên khách hàng không được để trống";
            }
            else if (String.IsNullOrEmpty(tendangnhap))
            {
                ViewData["tendangnhap"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["matkhau"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(nhaplaimatkhau))
            {
                ViewData["nhaplaimatkhau"] = "Phải nhập lại mật khẩu";
            }

            if (String.IsNullOrEmpty(email))
            {
                ViewData["email"] = "Email không được bỏ trống";
            }

            if (String.IsNullOrEmpty(sodienthoai))
            {
                ViewData["sodienthoai"] = "Phải nhập điện thoai";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (kh)
                kh.TenDangNhap = tendangnhap;
                kh.MatKhau = matkhau;
                kh.HoTen = hoten;
                kh.DiaChi = diachi;
                kh.Email = email;
                kh.SoDienThoai = sodienthoai;
                data.KhachHangs.InsertOnSubmit(kh);
                data.SubmitChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            // Gán các giá trị người dùng nhập liệu cho các biến 
            var tendangnhap = collection["tendangnhap"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendangnhap))
            {
                ViewData["tendangnhap"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["matkhau"] = "Phải nhập mật khẩu";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (kh)
                KhachHang kh = data.KhachHangs.SingleOrDefault(n => n.TenDangNhap == tendangnhap && n.MatKhau == matkhau);
                if (kh != null)
                {
                    ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return RedirectToAction("Index", "ShopQuanAo");
        }
    }

}