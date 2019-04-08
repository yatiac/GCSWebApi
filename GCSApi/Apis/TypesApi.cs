using GCSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSApi.Apis
{
    public class TypesApi : IApi<WorkOrderType>
    {
        public WorkOrderType Create(WorkOrderType data)
        {
            throw new NotImplementedException();
        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<WorkOrderType> Get(string filter)
        {
            using (var context = new dbContext())
            {
                var response = context.WorkOrderTypes.ToList();
                return response;
            }
        }

        public WorkOrderType Get(int id)
        {
            throw new NotImplementedException();
        }

        public WorkOrderType Update(WorkOrderType data)
        {
            throw new NotImplementedException();
        }
    }
}
