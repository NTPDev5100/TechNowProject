namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [Key]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password")]
        public int CodeCus { get; set; }


        [Required(ErrorMessage = "Please enter your email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [StringLength(50)]
        public string Email { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter your name"), MaxLength(30)]
        public string Name { get; set; }


        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter your phone number")]
        [StringLength(20)]
        [Required(ErrorMessage = "Please enter Mobile No")]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
