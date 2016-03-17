using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using LMS.Domain.Entities;

namespace LMS.Domain.EntityConfiguration
{
    public class AuthorMap : EntityTypeConfiguration<Author>
    {
        public AuthorMap()
        {
            HasKey(i => i.Id);
            ToTable("dbo.Author");
        }
    }

}

