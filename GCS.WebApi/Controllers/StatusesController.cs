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
    public class StatusesController : BaseController
    {
        IApi<WorkOrderStatus> api;

        public StatusesController()
        {
            api = new StatusesApi();
        }

        public object Get(string filter = "")
        {
            var response = api.Get(filter);
            AddContentRange(HttpContext.Current.Response, "statuses", response.Count.ToString());
            return response;
        }
    }
}
