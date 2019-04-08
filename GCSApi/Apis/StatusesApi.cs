using GCSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSApi.Apis
{
    public class StatusesApi : IApi<WorkOrderStatus>
    {
        public WorkOrderStatus Create(WorkOrderStatus data)
        {
            throw new NotImplementedException();
        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<WorkOrderStatus> Get(string filter)
        {
            using (var context = new dbContext())
            {
                var response = context.WorkOrderStatuses.ToList();
                return response;
            }
        }

        public WorkOrderStatus Get(int id)
        {
            throw new NotImplementedException();
        }

        public WorkOrderStatus Update(WorkOrderStatus data)
        {
            throw new NotImplementedException();
        }
    }
}
