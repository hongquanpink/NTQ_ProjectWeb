namespace DAL_Data_Access_Layer_.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reviews
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? ProductID { get; set; }

        public int? UserID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreatAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public DateTime? DeleteAt { get; set; }

        public virtual Products Products { get; set; }

        public virtual User User { get; set; }
    }
}
