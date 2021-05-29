using GlomilAssesment.Models.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlomilAssesment.Models.ORM.Context
{
    public class GlomilContext : DbContext
    {
        public GlomilContext(DbContextOptions<GlomilContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

    }
}
