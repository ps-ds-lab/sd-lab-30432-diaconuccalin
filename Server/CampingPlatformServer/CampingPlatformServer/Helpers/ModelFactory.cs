using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace CampingPlatformServer.Helpers
{
    public class ModelFactory
    {
        private UrlHelper _UrlHelper;

        public ModelFactory(HttpRequestMessage request)
        {
            _UrlHelper = new UrlHelper(request);
        }
        public RoleReturnModel Create(IdentityRole appRole)
        {
            return new RoleReturnModel
            {
                Url = _UrlHelper.Link("GetRoleById", new { id = appRole.Id }),
                Id = appRole.Id,
                Name = appRole.Name
            };
        }
    }

    public class RoleReturnModel
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
