using GCSApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSApi.Apis
{
    public class VehiclesApi : IApi<Vehicle>
    {
        public Vehicle Create(Vehicle data)
        {            
            using (var context = new dbContext())
            {
                var response = context.Vehicles.Add(data);
                context.SaveChanges();
                return response;
            }
        }

        public object Delete(int id)
        {
            using (var context = new dbContext())
            {
                var objectToDelete = context.Vehicles.Where(x => x.Id.Equals(id)).SingleOrDefault();
                if (objectToDelete != null)
                {
                    context.Vehicles.Remove(objectToDelete);
                    context.SaveChanges();
                }
                return objectToDelete;
            }
        }

        public List<Vehicle> Get()
        {
            using (var context = new dbContext())
            {
                var response = context.Vehicles.Include("Owner").ToList();
                return response;
            }
        }

        public Vehicle Get(int id)
        {
            using (var context = new dbContext())
            {
                var response = context.Vehicles.Include("Owner").Where(x => x.Id.Equals(id)).SingleOrDefault();
                return response;
            }
        }

        public Vehicle Update(Vehicle data)
        {
            using (var context = new dbContext())
            {
                var response = context.Vehicles.Where(x => x.Id.Equals(data.Id)).SingleOrDefault();
                if (response != null)
                {
                    context.Vehicles.AddOrUpdate(data);
                    context.SaveChanges();
                    response = data;
                }
                return response;
            }
        }
    }
}
