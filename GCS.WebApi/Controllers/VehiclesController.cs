using GCSApi.Apis;
using GCSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GCS.WebApi.Controllers
{
    public class VehiclesController : BaseController
    {
        IApi<Vehicle> api;

        public VehiclesController()
        {
            api = new VehiclesApi();
        }

        public object Get(string filter="")
        {
            var response = api.Get(filter);
            AddContentRange(HttpContext.Current.Response, "vehicles", response.Count.ToString());
            return Ok(response);
        }

        public object Get(int id)
        {
            var response = api.Get(id);
            return response == null ? NotFound() : (object)Ok(response);
        }

        public object Post([FromBody]Vehicle vehicle)
        {
            var response = api.Create(vehicle);
            return Created(Request.RequestUri + "/" + response.Id, response);
        }

        public object Patch([FromBody]Vehicle vehicle)
        {
            var response = api.Update(vehicle);
            return response == null ? NotFound() : (object)Ok(response);
        }
    }
}
