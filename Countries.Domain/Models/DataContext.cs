namespace Countries.Domain.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }
        public System.Data.Entity.DbSet<Countries.Domain.Models.User> Users { get; set; }

    }
}

    
