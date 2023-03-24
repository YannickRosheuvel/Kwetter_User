
using Kwetter_User.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Kwetter_User.DAL
{
    public partial class ClinicalContext : DbContext
    {
        public ClinicalContext()
        {
        }

        public ClinicalContext(DbContextOptions<ClinicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=mssqlstud.fhict.local;Database=dbi429901_kwetterus;User Id=dbi429901_kwetterus;Password=StarWars1;TrustServerCertificate=True;");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{


        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
