namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int MenuID { get; set; }

        [StringLength(50)]
        public string Text { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string Target { get; set; }

        public bool Status { get; set; }

        public int? MenuTypeID { get; set; }

        public int? MenuParentID { get; set; }

        public virtual MenuType MenuType { get; set; }
    }
}
