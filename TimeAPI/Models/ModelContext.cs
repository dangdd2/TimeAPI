using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAPI.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DescriptorEntry>().HasKey(de => new { de.DescriptorId , de.EntryId });
            builder.Entity<DescriptorEntry>().ToTable("DescriptorEntries");

            builder.Entity<Entry>().ToTable("Entries");
            builder.Entity<Entry>().HasKey(p => p.Id);
            builder.Entity<Entry>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Entry>().Property(p => p.ElapsedTime).IsRequired();
            builder.Entity<Entry>().Property(p => p.StartTime).IsRequired();
            builder.Entity<Entry>().Property(p => p.Narrative).IsRequired();

            builder.Entity<Descriptor>().ToTable("Descriptors");
            builder.Entity<Descriptor>().HasKey(p => p.Id);
            builder.Entity<Descriptor>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Descriptor>().Property(p => p.Name).IsRequired();
            builder.Entity<Descriptor>().Property(p => p.Identifier).IsRequired();

            builder.Entity<Matter>().ToTable("Matters");
            builder.Entity<Matter>().HasKey(p => p.Id);
            builder.Entity<Matter>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Matter>().Property(p => p.Name).IsRequired();
            builder.Entity<Matter>().Property(p => p.Identifier).IsRequired();

            builder.Entity<Client>().ToTable("Clients");
            builder.Entity<Client>().HasKey(p => p.Id);
            builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Client>().Property(p => p.Name).IsRequired();
            builder.Entity<Client>().Property(p => p.Identifier).IsRequired();

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Matter> Matters { get; set; }
        public DbSet<Descriptor> Descriptors { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<DescriptorEntry> DescriptorEntries { get; set; }

    }
}
