using GCSApi.Apis;
using GCSApi.Models;
using System.Web;
using System.Web.Http;

namespace GCS.WebApi.Controllers
{
    public class OwnersController : BaseController
    {
        IApi<Owner> api;

        public OwnersController()
        {
            api = new OwnersApi();
        }
        public object Get(string filter = "")
        {
            var response = api.Get(filter);
            AddContentRange(HttpContext.Current.Response, "owners", response.Count.ToString());
            return response;
        }
    }
}
