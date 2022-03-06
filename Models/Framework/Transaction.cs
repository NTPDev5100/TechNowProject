namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        public int TransactionID { get; set; }

        public bool? Status { get; set; }

        public int? UserID { get; set; }

        [StringLength(10)]
        public string Username { get; set; }

        [StringLength(20)]
        public string UserPhone { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(50)]
        public string Payment { get; set; }

        [Column(TypeName = "text")]
        public string PaymentInfo { get; set; }

        [StringLength(200)]
        public string Message { get; set; }

        [StringLength(20)]
        public string Security { get; set; }

        public int? Created { get; set; }
    }
}
