using System;

namespace GCSApi.Models
{
    public class WorkOrder
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public WorkOrderType Type { get; set; }
        public WorkOrderStatus Status { get; set; }
        public Mechanic Mechanic { get; set; }
        public Vehicle Vehicle { get; set; }
        public String[] Symptoms { get; set; }
    }
    public class WorkOrderType
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class WorkOrderStatus
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
