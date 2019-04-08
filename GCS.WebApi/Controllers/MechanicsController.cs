using GCSApi.Apis;
using GCSApi.Models;
using System.Web;
using System.Web.Http;

namespace GCS.WebApi.Controllers
{
    public class MechanicsController : BaseController
    {
        IApi<Mechanic> api;

        public MechanicsController()
        {
            api = new MechanicsApi();
        }

        public object Get(int id)
        {
            var response = api.Get(id);
            return response == null ? NotFound(): (object)Ok(response);
        }

        public object Get(string filter="")
        {
            var response = api.Get(filter);
            AddContentRange(HttpContext.Current.Response, "mechanics", response.Count.ToString());            
            return Ok(response); 
        }

        [HttpPost]
        public object Post([FromBody]Mechanic data)
        {
            var response = api.Create(data);
            return Created(Request.RequestUri + "/" + response.Id, response);
        }

        [HttpPut]
        public object Put([FromBody]Mechanic data)
        {
            var response = api.Update(data);
            return response == null ? NotFound() : (object)Ok(response);
        }

        [HttpDelete]
        public object Delete(int id)
        {
            var response = api.Delete(id);
            return response == null ? NotFound() : (object)Ok(response);
        }
    }
}
