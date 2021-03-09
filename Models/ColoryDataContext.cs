using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CaloryCounterProject.Models
{
    public class ColoryDataContext:DbContext
    {
        public ColoryDataContext(): base()
        {
          
        }
      public DbSet<Diet>diets { get; set; }
      public DbSet<Food>foods { get; set; }
      public DbSet<Foodxdiet>foodxdiets{ get; set; }
      public DbSet<User> users{get; set;}
      public DbSet<UserWeight> userweights { get; set; }
    }
}