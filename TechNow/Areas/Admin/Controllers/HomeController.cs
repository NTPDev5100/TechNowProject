using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.Framework;

namespace TechNow.Areas.Admin.Controllers
{
    
    public class HomeController : BaseController
    {
        TechNowDBContext db = new TechNowDBContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            bager();
            return View();
        }
        public void bager()
        {
            //ViewBag.displayclient=db.Users.ToList() ;
            ViewBag.Count = db.Customers.Count();
            ViewBag.CountCategory = db.ProductCategories.Count();
            ViewBag.CountOrder = db.Orders.Count();
            ViewBag.CountSlider = db.Sliders.Count();
            //ViewBag.CountSlider = ThongKeLoiNhuanThang(8,2022);
            ViewBag.Rev1 = ThongKeDoanhThuThang(1,2022);
            ViewBag.Rev2 = ThongKeDoanhThuThang(2, 2022);
            ViewBag.Rev3 = ThongKeDoanhThuThang(3, 2022);
            ViewBag.Rev4 = ThongKeDoanhThuThang(4, 2022);
            ViewBag.Rev5 = ThongKeDoanhThuThang(5, 2022);
            ViewBag.Rev6 = ThongKeDoanhThuThang(6, 2022);
            ViewBag.Rev7 = ThongKeDoanhThuThang(7, 2022);
            ViewBag.Rev8 = ThongKeDoanhThuThang(8, 2022);
            ViewBag.Rev9 = ThongKeDoanhThuThang(9, 2022);
            ViewBag.Rev10 = ThongKeDoanhThuThang(10, 2022);
            ViewBag.Rev11 = ThongKeDoanhThuThang(11, 2022);
            ViewBag.Rev12 = ThongKeDoanhThuThang(12, 2022);
            //view bag loi nhuan
            ViewBag.Profit1 = ThongKeLoiNhuanThang(1, 2022);
            ViewBag.Profit2 = ThongKeLoiNhuanThang(2, 2022);
            ViewBag.Profit3 = ThongKeLoiNhuanThang(3, 2022);
            ViewBag.Profit4 = ThongKeLoiNhuanThang(4, 2022);
            ViewBag.Profit5 = ThongKeLoiNhuanThang(5, 2022);
            ViewBag.Profit6 = ThongKeLoiNhuanThang(6, 2022);
            ViewBag.Profit7 = ThongKeLoiNhuanThang(7, 2022);
            ViewBag.Profit8 = ThongKeLoiNhuanThang(8, 2022);
            ViewBag.Profit9 = ThongKeLoiNhuanThang(9, 2022);
            ViewBag.Profit10 = ThongKeLoiNhuanThang(10, 2022);
            ViewBag.Profit11 = ThongKeLoiNhuanThang(11, 2022);
            ViewBag.Profit12 = ThongKeLoiNhuanThang(12, 2022);
        }

        public decimal ThongKeDoanhThuThang(int Thang, int Nam)
        {
            //List ra những đơn đặt hàng nào có tháng và năm tương ứng
            var lstDDH = db.Orders.Where(n => n.CreatedDate.Value.Month == Thang && n.CreatedDate.Value.Year == Nam);
            decimal Tongtien = 0;
            //Duyệt chi tiết của đơn đặt hàng đó và lấy tổng tiền của tất cả các sản phẩm của đơn đặt hàng đó
            foreach (var item in lstDDH)
            {
                Tongtien += int.Parse(item.OrderDetails.Sum(n => n.Quantity * n.Price).Value.ToString());
            }
            return Tongtien;
        }

        public decimal ThongKeLoiNhuanThang(int Month, int Year)
        {
            //List ra những đơn đặt hàng nào có tháng và năm tương ứng
            var odl = db.Orders.Where(n => n.CreatedDate.Value.Month == Month && n.CreatedDate.Value.Year == Year);
            decimal totalrevenue = 0;
            decimal totalorginalprice = 0;
            decimal totalprofit = 0;
            //Duyệt chi tiết của đơn đặt hàng đó và lấy tổng tiền của tất cả các sản phẩm của đơn đặt hàng đó
            foreach (var item in odl)
            {
                var productid = item.OrderDetails.Select(n => n.ProductID);
                IEnumerable<int> id = productid;
                //Duyệt chi tiết các sản phẩm có trong đơn đặt hàng để lấy giá gốc của sản phẩm
                foreach (var itemid in productid)
                {
                    var Oprice = db.Products.Where(x => x.ProductID == itemid).Select(x => x.OriginalPrice).ToList();
                    decimal Orinalprice = Convert.ToDecimal(Oprice.ToList().FirstOrDefault());

                    var Idorderdt = item.OrderDetails.Select(n => n.OrderID);
                    IEnumerable<int?> idorderdt = Idorderdt;
                    var Quantitys = db.OrderDetails.Where(x => x.ProductID == itemid && x.OrderID == idorderdt.ToList().FirstOrDefault()).Select(x => x.Quantity).ToList();
                    int quantitys = Convert.ToInt32(Quantitys.ToList().FirstOrDefault());
                    totalorginalprice += Orinalprice * quantitys;
                    
                }
                // Tong doanh thu - tong gia nhap = Tong loi nhuan trong thang
                totalrevenue += (int.Parse(item.OrderDetails.Sum(n => n.Quantity * n.Price).Value.ToString()));
                totalprofit = totalrevenue - totalorginalprice;
            }
            return totalprofit;
        }


        public ActionResult GetData()
        {
            decimal tkdtt1 = ThongKeDoanhThuThang(1, 2022);
            decimal tkdtt2 = ThongKeDoanhThuThang(2, 2022);
            decimal tkdtt3 = ThongKeDoanhThuThang(3, 2022);
            decimal tkdtt4 = ThongKeDoanhThuThang(4, 2022);
            decimal tkdtt5 = ThongKeDoanhThuThang(5, 2022);
            decimal tkdtt6 = ThongKeDoanhThuThang(6, 2022);
            decimal tkdtt7 = ThongKeDoanhThuThang(7, 2022);
            decimal tkdtt8 = ThongKeDoanhThuThang(8, 2022);
            decimal tkdtt9 = ThongKeDoanhThuThang(9, 2022);
            decimal tkdtt10 = ThongKeDoanhThuThang(10, 2022);
            decimal tkdtt11 = ThongKeDoanhThuThang(11, 2022);
            decimal tkdtt12 = ThongKeDoanhThuThang(12, 2022);
            Ratio obj = new Ratio();
            obj.TKDTT1 = tkdtt1;
            obj.TKDTT2 = tkdtt2;
            obj.TKDTT3 = tkdtt3;
            obj.TKDTT4 = tkdtt4;
            obj.TKDTT5 = tkdtt5;
            obj.TKDTT6 = tkdtt6;
            obj.TKDTT7 = tkdtt7;
            obj.TKDTT8 = tkdtt8;
            obj.TKDTT9 = tkdtt9;
            obj.TKDTT10 = tkdtt10;
            obj.TKDTT11 = tkdtt11;
            obj.TKDTT12 = tkdtt12;
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDataProfit()
        {
            decimal tklnt1 = ThongKeLoiNhuanThang(1, 2022);
            decimal tklnt2 = ThongKeLoiNhuanThang(2, 2022);
            decimal tklnt3 = ThongKeLoiNhuanThang(3, 2022);
            decimal tklnt4 = ThongKeLoiNhuanThang(4, 2022);
            decimal tklnt5 = ThongKeLoiNhuanThang(5, 2022);
            decimal tklnt6 = ThongKeLoiNhuanThang(6, 2022);
            decimal tklnt7 = ThongKeLoiNhuanThang(7, 2022);
            decimal tklnt8 = ThongKeLoiNhuanThang(8, 2022);
            decimal tklnt9 = ThongKeLoiNhuanThang(9, 2022);
            decimal tklnt10 = ThongKeLoiNhuanThang(10, 2022);
            decimal tklnt11 = ThongKeLoiNhuanThang(11, 2022);
            decimal tklnt12 = ThongKeLoiNhuanThang(12, 2022);
            Ratio obj = new Ratio();
            obj.TKLNT1 = tklnt1;
            obj.TKLNT2 = tklnt2;
            obj.TKLNT3 = tklnt3;
            obj.TKLNT4 = tklnt4;
            obj.TKLNT5 = tklnt5;
            obj.TKLNT6 = tklnt6;
            obj.TKLNT7 = tklnt7;
            obj.TKLNT8 = tklnt8;
            obj.TKLNT9 = tklnt9;
            obj.TKLNT10 = tklnt10;
            obj.TKLNT11 = tklnt11;
            obj.TKLNT12 = tklnt12;
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public class Ratio
        {
            public decimal TKDTT1 { get; set; }
            public decimal TKDTT2 { get; set; }
            public decimal TKDTT3 { get; set; }
            public decimal TKDTT4 { get; set; }
            public decimal TKDTT5 { get; set; }
            public decimal TKDTT6 { get; set; }
            public decimal TKDTT7 { get; set; }
            public decimal TKDTT8 { get; set; }
            public decimal TKDTT9 { get; set; }
            public decimal TKDTT10 { get; set; }
            public decimal TKDTT11 { get; set; }
            public decimal TKDTT12 { get; set; }
            public decimal TKLNT1 { get; set; }
            public decimal TKLNT2 { get; set; }
            public decimal TKLNT3 { get; set; }
            public decimal TKLNT4 { get; set; }
            public decimal TKLNT5 { get; set; }
            public decimal TKLNT6 { get; set; }
            public decimal TKLNT7 { get; set; }
            public decimal TKLNT8 { get; set; }
            public decimal TKLNT9 { get; set; }
            public decimal TKLNT10 { get; set; }
            public decimal TKLNT11 { get; set; }
            public decimal TKLNT12 { get; set; }
        }


        public ActionResult GetRevenueStatistics(string fromDate, string toDate)
        {
            var statistic = new StatisticDao().GetRevenueStatistic(fromDate, toDate);
            return Json(statistic, JsonRequestBehavior.AllowGet);
        }

    }
}