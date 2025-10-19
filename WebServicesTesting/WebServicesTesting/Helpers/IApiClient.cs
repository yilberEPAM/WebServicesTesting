using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServicesTesting.Helpers
{
    public interface IApiClient
    {
        RestResponse Execute(RestRequest request);
    }
}
