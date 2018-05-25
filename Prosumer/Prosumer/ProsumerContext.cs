namespace Prosumer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProsumerContext : DbContext
    {
        public ProsumerContext()
            : base("name=ProsumerContext")
        {
        }

        public virtual DbSet<Prosumers> Prosumers { get; set; }
        public virtual DbSet<C00_00> C00_00 { get; set; }
        public virtual DbSet<C01_00> C01_00 { get; set; }
        public virtual DbSet<C02_00> C02_00 { get; set; }
        public virtual DbSet<C03_00> C03_00 { get; set; }
        public virtual DbSet<C04_00> C04_00 { get; set; }
        public virtual DbSet<C05_00> C05_00 { get; set; }
        public virtual DbSet<C06_00> C06_00 { get; set; }
        public virtual DbSet<C07_00> C07_00 { get; set; }
        public virtual DbSet<C08_00> C08_00 { get; set; }
        public virtual DbSet<C09_00> C09_00 { get; set; }
        public virtual DbSet<C10_00> C10_00 { get; set; }
        public virtual DbSet<C11_00> C11_00 { get; set; }
        public virtual DbSet<C12_00> C12_00 { get; set; }
        public virtual DbSet<C13_00> C13_00 { get; set; }
        public virtual DbSet<C14_00> C14_00 { get; set; }
        public virtual DbSet<C15_00> C15_00 { get; set; }
        public virtual DbSet<C16_00> C16_00 { get; set; }
        public virtual DbSet<C17_00> C17_00 { get; set; }
        public virtual DbSet<C18_00> C18_00 { get; set; }
        public virtual DbSet<C19_00> C19_00 { get; set; }
        public virtual DbSet<C20_00> C20_00 { get; set; }
        public virtual DbSet<C21_00> C21_00 { get; set; }
        public virtual DbSet<C22_00> C22_00 { get; set; }
        public virtual DbSet<C23_00> C23_00 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C00_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C01_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C02_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C03_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C04_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C05_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C06_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C07_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C08_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C09_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C10_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C11_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C12_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C13_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C14_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C15_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C16_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C17_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C18_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C19_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C20_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C21_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C22_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<Prosumers>()
                .HasOptional(e => e.C23_00)
                .WithRequired(e => e.Prosumers);

            modelBuilder.Entity<C00_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C01_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C02_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C03_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C04_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C05_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C06_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C07_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C08_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C09_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C10_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C11_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C12_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C13_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C14_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C15_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C16_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C17_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C18_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C19_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C20_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C21_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C22_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);

            modelBuilder.Entity<C23_00>()
                .Property(e => e.Consume)
                .IsUnicode(false);
        }
    }
}
