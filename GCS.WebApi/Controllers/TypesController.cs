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
    public class TypesController : BaseController
    {
        IApi<WorkOrderType> api;
        public TypesController()
        {
            api = new TypesApi();
        }

        public object Get(string filter = "")
        {
            var response = api.Get(filter);
            AddContentRange(HttpContext.Current.Response, "types", response.Count.ToString());
            return Ok(response);
        }
    }
}
