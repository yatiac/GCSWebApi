using GCSApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GCSApi.Apis
{
    public class MechanicsApi : IApi<Mechanic>
    {
        public Mechanic Create(Mechanic data)
        {
            using (var context = new dbContext())
            {
                var response = context.Mechanics.Add(data);
                context.SaveChanges();
                return response;
            }
        }

        public object Delete(int id)
        {
            using (var context = new dbContext())
            {
                var objectToDelete = context.Mechanics.Where(x => x.Id.Equals(id)).SingleOrDefault();
                if (objectToDelete != null)
                {
                    context.Mechanics.Remove(objectToDelete);
                    context.SaveChanges();
                }
                return objectToDelete;
            }
        }

        public List<Mechanic> Get()
        {
            using (var context = new dbContext())
            {
                var response = context.Mechanics.ToList();
                return response;
            }
        }

        public Mechanic Get(int id)
        {
            using (var context = new dbContext())
            {
                var response = context.Mechanics.Where(x => x.Id.Equals(id)).SingleOrDefault();
                return response;
            }
        }

        public Mechanic Update(Mechanic data)
        {
            using (var context = new dbContext())
            {
                var response = context.Mechanics.Where(x => x.Id.Equals(data.Id)).SingleOrDefault();
                if (response != null)
                {
                    context.Mechanics.AddOrUpdate(data);
                    context.SaveChanges();
                    response = data;
                }
                return response;
            }
        }
    }
}
