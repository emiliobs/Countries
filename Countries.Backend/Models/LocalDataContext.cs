namespace Countries.Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Domain.Models;
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Countries.Backend.Models.UserType> UserTypes { get; set; }
    }
}