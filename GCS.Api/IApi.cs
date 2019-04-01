using GCS.Models;
using System;

namespace GCS
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
