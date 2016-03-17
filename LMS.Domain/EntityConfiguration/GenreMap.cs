using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using LMS.Domain.Entities;

namespace LMS.Domain.EntityConfiguration
{
    public class GenreMap: EntityTypeConfiguration<Genre>
    {
        public GenreMap()
        {
            HasKey(i => i.Id);
            ToTable("dbo.Genre");
        }
    }
}
