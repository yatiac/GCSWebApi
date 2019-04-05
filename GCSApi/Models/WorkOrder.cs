using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCSApi.Models
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public WorkOrderType Type { get; set; }

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public WorkOrderStatus Status { get; set; }

        public int MechanicId { get; set; }
        [ForeignKey("MechanicId")]
        public Mechanic Mechanic { get; set; }

        public int VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        public string Symptoms { get; set; }
    }
    public class WorkOrderType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class WorkOrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
