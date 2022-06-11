using HelmetShop.Domain;
using System.Collections.Generic;

namespace HelmetShop.Api.Core
{
    public class JwtUser : IApplicationUser
    {
        public string Identity {get; set;}

        public int Id { get; set; }

        public IEnumerable<int> UseCaseIds { get; set; }

        public string Username { get; set; }
    }
}
