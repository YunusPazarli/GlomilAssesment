using GlomilAssesment.Models.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlomilAssesment.Models.VM;

namespace GlomilAssesment.Models.ORM.Context
{
    public class GlomilContext : DbContext
    {
        public GlomilContext(DbContextOptions<GlomilContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<GlomilAssesment.Models.VM.UserRegisterVM> UserRegisterVM { get; set; }
        public DbSet<MathEntity> mathEntity { get; set; }
        public DbSet<GlomilAssesment.Models.VM.MathVM> MathVM { get; set; }

        

    }
}
