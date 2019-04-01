using GCSApi.Models;
using System;

namespace GCSApi
{
    public interface IApi
    {
        object GetWorkOrders();
        object GetWorkOrder(string id); 
        object CreateWorkOrder(WorkOrder data);
        object UpdateWorkOrder(string id);
        object DeleteWorkOrder(string id);
    }
}
