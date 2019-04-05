using GCSApi.Apis;
using GCSApi.Models;
using System.Web.Http;

namespace GCS.WebApi.Controllers
{
    public class WorkOrdersController : ApiController
    {
        IApi<WorkOrder> api;

        public WorkOrdersController()
        {
            api = new WorkOrdersApi();
        }

        public object Get(int id)
        {
            var response = api.Get(id);
            return response == null ? NotFound() : (object)Ok(response);
        }

        [HttpPost]
        public object Post([FromBody]WorkOrder data)
        {
            var response = api.Create(data);
            return Created(Request.RequestUri + "/" + response.Id, response);
        }

        [HttpGet]
        public object Get()
        {
            var response = api.Get();
            return response;
        }

        [HttpDelete]
        public object Delete(int id)
        {
            var response = api.Delete(id);
            return response;
        }
    }
}
