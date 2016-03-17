using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using LMS.Domain.Entities;
using System.Data.Entity.Infrastructure;
using LMS.Domain.EntityConfiguration;

namespace LMS.Domain
{
    public class LmsDbContext : DbContext
    {
        public IDbSet<Book> Book { get; set; }

        public IDbSet<Stock> Stock { get; set; }

        public IDbSet<Author> Author { get; set; }

        public IDbSet<Genre> Genre { get; set; }

        public IDbSet<Issue> Issue { get; set; }


        public LmsDbContext()
            : base(DBConnection.Create(Config.GetDatabaseConnectionString()), true)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new GenreMap());
            ////modelBuilder.Configurations.Add(new IssueMap());
            ////modelBuilder.Configurations.Add(new StockMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
