using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechNow.Model
{
    public class CartItem
    {
        public Product Shopping_Product { get; set; }
        public int Quantity { get; set; }
    }


    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Product pro, int _quantity =1)
        {
            var item = items.FirstOrDefault(s => s.Shopping_Product.ProductID == pro.ProductID);
            if(item == null)
            {
                items.Add(new CartItem
                {
                    Shopping_Product = pro,
                    Quantity = _quantity
                });
            }
            else
            {
                item.Quantity += _quantity;
            }    
        }
       public void Update_Quantity_Shopping(int id,int _quantity)
        {
            var item = items.Find(s => s.Shopping_Product.ProductID == id);
            if(item != null)
            {
                item.Quantity = _quantity;
            }
        }
        public decimal Total_Money()
        {
            var total = items.Sum(s => s.Shopping_Product.Price * s.Quantity);
            return (decimal)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s.Shopping_Product.ProductID == id);
        }
        //Tong so luong shopping
        public int Total_Quantity_Cart()
        {
            return items.Sum(s => s.Quantity);
        }
        public void ClearCart()
        {
            items.Clear(); //Xoa gio hang de thuc hien order moi
        }
    }
}