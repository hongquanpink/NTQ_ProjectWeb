namespace DAL_Data_Access_Layer_.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            Medias = new HashSet<Medias>();
            Reviews = new HashSet<Reviews>();
        }

        public int Id { get; set; }

        public int? CategoryID { get; set; }

        public string  ProductName { get; set; }
        public string  Path { get; set; }

        [StringLength(100)]
        public string Slug { get; set; }

        [StringLength(100)]
        public string Detail { get; set; }

        public bool  Trending { get; set; }

        public bool Status { get; set; }

        public double? NumberViews { get; set; }

        public double? Price { get; set; }

        [StringLength(100)]
        public string MetaKey { get; set; }

        public DateTime? CreatAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public DateTime? DeleteAt { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medias> Medias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
