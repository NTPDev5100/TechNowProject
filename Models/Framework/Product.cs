namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    using System.Web.Mvc;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductID { get; set; }

        [StringLength(10, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        [Required(ErrorMessage = "The ProductCode field is required")]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "The ProductName field is required")]
        [StringLength(250)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "The MetaTitle field is required")]
        [StringLength(250, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string ProductImage { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Please input is type number")]
        public decimal? OriginalPrice { get; set; }

        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Please input is type number")]
        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public bool IncludeVAT { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "Please input is type number")]
        public int? Quantity { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "Please input is type number")]
        public int? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string Detail { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "Please input is type number")]
        public int? Warranty { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public bool Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TopHot { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "Please input is type number")]
        public int? ViewCounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
