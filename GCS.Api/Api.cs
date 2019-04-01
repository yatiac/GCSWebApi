using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GCS.Models;

namespace GCS
{
    public class Api : IApi
    {

        public object CreateWorkOrder(WorkOrder data)
        {
            throw new NotImplementedException();
        }

        public object DeleteWorkOrder(string id)
        {
            throw new NotImplementedException();
        }

        public object GetWorkOrder(string id)
        {
            using (var context = new dbContext())
            {
                var response = context.WorkOrders.Where(x => x.Id.Equals(id)).FirstOrDefault();
                return response;
            }
        }

        public object GetWorkOrders()
        {
            using (var context = new dbContext())
            {
                var response = context.WorkOrders.ToList();
                return response;
            }
        }

        public object UpdateWorkOrder(string id)
        {
            throw new NotImplementedException();
        }
    }
}
