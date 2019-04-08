using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GCS.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        public void AddContentRange(HttpResponse response, string unit, string count)
        {
           response.Headers.Add("Content-Range", string.Format("{1} 0-{0}/{0}", count, unit));
        }
    }
}