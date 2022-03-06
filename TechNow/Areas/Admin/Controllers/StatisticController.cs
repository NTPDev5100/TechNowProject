using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechNow.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {
        TechNowDBContext db = new TechNowDBContext();
        // GET: Admin/Statistic
        public ActionResult Index()
        {
            ViewBag.TongDoanhthu = ThongKeDoanhThuThang(1,2021); //Thong ke tong doanh thu
            return View();
        }

        public decimal ThongKeTongDoanhThu()
        {
            decimal TongDoanhThu = db.OrderDetails.Sum(n => n.Quantity * n.Price).Value;
            return TongDoanhThu;
        }
        public decimal ThongKeDoanhThuThang(int Thang, int Nam)
        {
            //List ra những đơn đặt hàng nào có tháng và năm tương ứng
            var lstDDH = db.Orders.Where(n => n.CreatedDate.Value.Month == Thang && n.CreatedDate.Value.Year == Nam);
            decimal Tongtien = 0;
            //Duyệt chi tiết của đơn đặt hàng đó và lấy tổng tiền của tất cả các sản phẩm của đơn đặt hàng đó
            foreach(var item in lstDDH)
            {
                Tongtien += decimal.Parse(item.OrderDetails.Sum(n => n.Quantity * n.Price).Value.ToString());
            }
            return Tongtien;
        }
    }
}