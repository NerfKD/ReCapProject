using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CBCContext : DbContext
    {
        //FrameWork paketi ile gelen DBCOntext implemente ediyoruz.
        //Onconfiguring ile UseSqlServer kullanacağımızı belirterek cs yazıyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database= CBC; Trusted_Connection=true");
        }
        //Db içinde ki tabloları nesneler ile ilişkilendiriyoruz.
        public DbSet<Car> Car { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Brand> Brand { get; set; }
    }
}
