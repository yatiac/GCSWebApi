using GCSApi;
using GCSApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GCS.WebApi.Controllers
{
    public class WorkOrdersController : ApiController
    {
        IApi api;

        public WorkOrdersController()
        {
            api = new Api();
        }

        public object Get(string id)
        {
            var response = api.GetWorkOrder(id);
            return response;
        }

        [HttpPost]
        public object Post([FromBody]WorkOrder data)
        {
            var response = api.CreateWorkOrder(data);
            return Created(data.Id, response);
        }


        [HttpGet]
        public object Get()
        {
            var response = api.GetWorkOrders();
            return response;
        }

        [HttpDelete]
        public object Delete(string id)
        {
            var response = api.DeleteWorkOrder(id);
            return response;
        }
    }
}
