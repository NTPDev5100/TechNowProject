﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TechNowDBContext : DbContext
    {
        public TechNowDBContext()
            : base("name=TechNowDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<New> News { get; set; }
        public virtual DbSet<NewCategory> NewCategories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
    
        public virtual ObjectResult<GetRevenueStatistic_Result> GetRevenueStatistic(string fromDate, string toDate)
        {
            var fromDateParameter = fromDate != null ?
                new ObjectParameter("fromDate", fromDate) :
                new ObjectParameter("fromDate", typeof(string));
    
            var toDateParameter = toDate != null ?
                new ObjectParameter("toDate", toDate) :
                new ObjectParameter("toDate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetRevenueStatistic_Result>("GetRevenueStatistic", fromDateParameter, toDateParameter);
        }
    
        public virtual ObjectResult<Nullable<bool>> Sp_Admin_Login(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("Sp_Admin_Login", usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Sp_Category_ListAll_Result> Sp_Category_ListAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Sp_Category_ListAll_Result>("Sp_Category_ListAll");
        }
    
        public virtual int Sp_ProductCategory_Insert(string name, string metaTitle, Nullable<int> parentID, Nullable<int> displayOrder, string seoTitle, string createBy, string modifiedBy, string metaKeywords, string metaDescriptions, Nullable<bool> status, Nullable<bool> showOnHome)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var metaTitleParameter = metaTitle != null ?
                new ObjectParameter("MetaTitle", metaTitle) :
                new ObjectParameter("MetaTitle", typeof(string));
    
            var parentIDParameter = parentID.HasValue ?
                new ObjectParameter("ParentID", parentID) :
                new ObjectParameter("ParentID", typeof(int));
    
            var displayOrderParameter = displayOrder.HasValue ?
                new ObjectParameter("DisplayOrder", displayOrder) :
                new ObjectParameter("DisplayOrder", typeof(int));
    
            var seoTitleParameter = seoTitle != null ?
                new ObjectParameter("SeoTitle", seoTitle) :
                new ObjectParameter("SeoTitle", typeof(string));
    
            var createByParameter = createBy != null ?
                new ObjectParameter("CreateBy", createBy) :
                new ObjectParameter("CreateBy", typeof(string));
    
            var modifiedByParameter = modifiedBy != null ?
                new ObjectParameter("ModifiedBy", modifiedBy) :
                new ObjectParameter("ModifiedBy", typeof(string));
    
            var metaKeywordsParameter = metaKeywords != null ?
                new ObjectParameter("MetaKeywords", metaKeywords) :
                new ObjectParameter("MetaKeywords", typeof(string));
    
            var metaDescriptionsParameter = metaDescriptions != null ?
                new ObjectParameter("MetaDescriptions", metaDescriptions) :
                new ObjectParameter("MetaDescriptions", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(bool));
    
            var showOnHomeParameter = showOnHome.HasValue ?
                new ObjectParameter("ShowOnHome", showOnHome) :
                new ObjectParameter("ShowOnHome", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Sp_ProductCategory_Insert", nameParameter, metaTitleParameter, parentIDParameter, displayOrderParameter, seoTitleParameter, createByParameter, modifiedByParameter, metaKeywordsParameter, metaDescriptionsParameter, statusParameter, showOnHomeParameter);
        }
    }
}