namespace GCSApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GCSApi.Models.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GCSApi.Models.dbContext context)
        {
            context.Mechanics.AddOrUpdate(x => x.Name,
                new Models.Mechanic() { Name = "Tony Stark" },
                new Models.Mechanic() { Name = "Peter Parker" },
                new Models.Mechanic() { Name = "Natasha Romanoff" },
                new Models.Mechanic() { Name = "Bruce Banner" }
                );

            context.WorkOrderStatuses.AddOrUpdate(x => x.Name,
                new Models.WorkOrderStatus() { Name = "Nuevo" },
                new Models.WorkOrderStatus() { Name = "En Progreso" },
                new Models.WorkOrderStatus() { Name = "Terminado" },
                new Models.WorkOrderStatus() { Name = "Cancelado" }
                );

            context.WorkOrderTypes.AddOrUpdate(x => x.Name,
                new Models.WorkOrderType() { Name = "Mecánica" },
                new Models.WorkOrderType() { Name = "Chapistería" },
                new Models.WorkOrderType() { Name = "Aire Acondicionado" }
                );

            context.Vehicles.AddOrUpdate(x => x.Plate,
                new Models.Vehicle()
                {
                    Plate = "650035",
                    Color = "Blanco",
                    Maker = "Nissan",
                    Model = "Almera",
                    VIN = "ASK2394ASMX",
                    Year = 2019,
                    Owner = new Models.Owner()
                    {
                        Name = "Rafael Echeverría",
                        Email = "master.152@gmail.com",
                        Phone = "+50769817547"
                    }
                });
        }
    }
}

