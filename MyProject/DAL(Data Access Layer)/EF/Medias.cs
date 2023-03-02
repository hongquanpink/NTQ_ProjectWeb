namespace DAL_Data_Access_Layer_.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? ProductsID { get; set; }

        [StringLength(50)]
        public string Path { get; set; }

        public DateTime? CreatAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public virtual Products Products { get; set; }
    }
}
