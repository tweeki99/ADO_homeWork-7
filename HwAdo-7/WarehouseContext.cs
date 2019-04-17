namespace HwAdo_7
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    class WarehouseContext : DbContext
    {
        public WarehouseContext()
            : base("DefaultConnection")
        { }

        public DbSet<Product> Products { get; set; }
    }
}