using GCSApi.Apis;
using GCSApi.Models;
using System.Web;
using System.Web.Http;

namespace GCS.WebApi.Controllers
{
    public class WorkOrdersController : BaseController
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
        public object Get(string filter = "")
        {
            var response = api.Get(filter);
            AddContentRange(HttpContext.Current.Response, "workorders", response.Count.ToString());
            return response;
        }

        [HttpDelete]
        public object Delete(int id)
        {
            var response = api.Delete(id);
            return response == null ? NotFound() : (object)Ok(response);
        }

        [HttpPut]
        public object Put(WorkOrder data)
        {
            var response = api.Update(data);
            return response == null ? NotFound() : (object)Ok(response);
        }
    }
}
