﻿using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using Homes.DataAccess.Configuration;
using Homes.DataAccess.Repository;
using Homes.Model;

namespace Homes.DataAccess
{
    public class HomesDataContext : DbContext, IDbContext
    {
        //This makes sures that the database initailizer gets called everytime
        
        static HomesDataContext()
        {
            Database.SetInitializer(new CustomDatabaseInitializer());
        }

        public HomesDataContext()
            : base(nameOrConnectionString: ConnectionString)
        {
           
        }

        //This will run a select * on the respective tables in the Database
        public DbSet<Home> Homes { get; set; }

        public DbSet<User> Users { get; set; }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["Homes_Connection_String"] ?? "DefaultConnectionString";
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HomeConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());
            modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());
            modelBuilder.Configurations.Add(new RolesConfiguration());

        }

        public override int SaveChanges()
        {
            this.ApplyRules();

            return base.SaveChanges();
        }

        private void ApplyRules()
        {
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.Entity is IAuditInfo && (e.State == EntityState.Modified) || (e.State == EntityState.Added)))
            {
                IAuditInfo e = entry.Entity as IAuditInfo;
                if (entry.State == EntityState.Added)
                {
                    e.CreatedOn = DateTime.Now;
                }
                e.ModifiedOn = DateTime.Now;
            }
        }      
        
    }
}