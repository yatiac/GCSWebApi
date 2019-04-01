using System.Data.Entity;

namespace GCSApi.Models
{
    public class dbContext : DbContext
    {
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; }
        public DbSet<WorkOrderType> WorkOrderTypes { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
    }
}
