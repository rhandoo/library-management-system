using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using LMS.Domain.Entities;
namespace LMS.Domain.EntityConfiguration
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            HasKey(i => i.Id);
            ToTable("dbo.Book");
            HasRequired(x => x.Author).WithMany().HasForeignKey(y => y.AuthorId);
            HasRequired(x => x.Genre).WithMany().HasForeignKey(y => y.GenreId);
        }
    }
}
