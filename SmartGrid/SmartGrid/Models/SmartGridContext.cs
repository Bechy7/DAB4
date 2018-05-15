namespace SmartGrid.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SmartGridContext : DbContext
    {
        public SmartGridContext()
            : base("name=SmartGridContext")
        {
        }

        public virtual DbSet<SmartGrid> SmartGrid { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SmartGrid>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<SmartGrid>()
                .Property(e => e.Smartmeter)
                .IsUnicode(false);

            modelBuilder.Entity<SmartGrid>()
                .Property(e => e.ProduktionsType)
                .IsUnicode(false);
        }
    }
}
