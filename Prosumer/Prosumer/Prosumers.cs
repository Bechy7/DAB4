 namespace Prosumer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prosumers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public virtual C00_00 C00_00 { get; set; }

        public virtual C01_00 C01_00 { get; set; }

        public virtual C02_00 C02_00 { get; set; }

        public virtual C03_00 C03_00 { get; set; }

        public virtual C04_00 C04_00 { get; set; }

        public virtual C05_00 C05_00 { get; set; }

        public virtual C06_00 C06_00 { get; set; }

        public virtual C07_00 C07_00 { get; set; }

        public virtual C08_00 C08_00 { get; set; }

        public virtual C09_00 C09_00 { get; set; }

        public virtual C10_00 C10_00 { get; set; }

        public virtual C11_00 C11_00 { get; set; }

        public virtual C12_00 C12_00 { get; set; }

        public virtual C13_00 C13_00 { get; set; }

        public virtual C14_00 C14_00 { get; set; }

        public virtual C15_00 C15_00 { get; set; }

        public virtual C16_00 C16_00 { get; set; }

        public virtual C17_00 C17_00 { get; set; }

        public virtual C18_00 C18_00 { get; set; }

        public virtual C19_00 C19_00 { get; set; }

        public virtual C20_00 C20_00 { get; set; }

        public virtual C21_00 C21_00 { get; set; }

        public virtual C22_00 C22_00 { get; set; }

        public virtual C23_00 C23_00 { get; set; }
    }
}
