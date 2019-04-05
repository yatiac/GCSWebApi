using GCSApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GCSApi.Apis
{
    public class WorkOrdersApi : IApi<WorkOrder>
    {
        public WorkOrder Create(WorkOrder data)
        {
            data.Date = DateTime.Now;

            using (var context = new dbContext())
            {
                var response = context.WorkOrders.Add(data);
                context.SaveChanges();
                return response;
            }
        }

        public object Delete(int id)
        {
            using (var context = new dbContext())
            {
                var objectToDelete = context.WorkOrders.Where(x => x.Id.Equals(id)).SingleOrDefault();
                if (objectToDelete != null)
                {
                    context.WorkOrders.Remove(objectToDelete);
                    context.SaveChanges();
                }
                return objectToDelete;
            }
        }

        public List<WorkOrder> Get()
        {
            using (var context = new dbContext())
            {
                var response = context.WorkOrders
                                    .Include("Mechanic")
                                    .Include("Status")
                                    .Include("Vehicle.Owner")
                                    .Include("Type")
                                    .ToList();
                return response;
            }
        }

        public WorkOrder Get(int id)
        {
            using (var context = new dbContext())
            {
                var response = context.WorkOrders.Where(x => x.Id.Equals(id)).SingleOrDefault();
                return response;
            }
        }

        public WorkOrder Update(WorkOrder data)
        {
            using (var context = new dbContext())
            {
                var response = context.WorkOrders.Where(x => x.Id.Equals(data.Id)).SingleOrDefault();
                if (response != null)
                {
                    context.WorkOrders.AddOrUpdate(data);
                    context.SaveChanges();
                    response = data;
                }
                return response;
            }
        }
    }
}
