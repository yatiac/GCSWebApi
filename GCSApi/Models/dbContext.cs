using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace GCSApi.Models
{
    public class dbContext : DbContext
    {
        public dbContext()
        {
            Database.SetInitializer(new dbInitializer());
        }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; }
        public DbSet<WorkOrderType> WorkOrderTypes { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
    }

    public class dbInitializer : DropCreateDatabaseIfModelChanges<dbContext>
    {
        protected override void Seed(dbContext context)
        {
            List<Mechanic> defaultMechanics = new List<Mechanic>();

            defaultMechanics.Add(new Mechanic() { Name = "Tony Stark" });
            defaultMechanics.Add(new Mechanic() { Name = "Steve Rogers" });
            defaultMechanics.Add(new Mechanic() { Name = "Bruce Banner" });
            defaultMechanics.Add(new Mechanic() { Name = "Natasha Romanof" });

            context.Mechanics.AddRange(defaultMechanics);

            base.Seed(context);
        }
    }
}
