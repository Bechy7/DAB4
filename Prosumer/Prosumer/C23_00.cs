namespace Prosumer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("23:00")]
    public partial class C23_00
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Consume { get; set; }

        public virtual Prosumers Prosumers { get; set; }
    }
}
