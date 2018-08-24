using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SeedAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeedAPI.Models.Context
{
    internal class ApplicationContext : IdentityDbContext<User>, IApplicationContext
    {
        private IDbContextTransaction dbContextTransaction;

        public ApplicationContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<User> UsersDB { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public void BeginTransaction()
        {
            dbContextTransaction = Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Rollback();
            }
        }

        public void DisposeTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Dispose();
            }
        }
    }
}