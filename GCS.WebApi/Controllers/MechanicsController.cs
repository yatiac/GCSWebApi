using GCSApi.Apis;
using GCSApi.Models;
using System.Web.Http;

namespace GCS.WebApi.Controllers
{
    public class MechanicsController : ApiController
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

        public object Get()
        {
            var response = api.Get();
            return response;
        }

        [HttpPost]
        public object Post([FromBody]Mechanic data)
        {
            var response = api.Create(data);
            return Created(Request.RequestUri + "/" + response.Id, response);
        }

        [HttpPatch]
        public object Patch([FromBody]Mechanic data)
        {
            var response = api.Update(data);
            return response == null ? NotFound() : (object)Ok(response);
        }
    }
}
