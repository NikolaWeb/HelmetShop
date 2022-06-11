using HelmetShop.Domain;
using System.Collections.Generic;

namespace HelmetShop.Api.Core
{
    public class JwtUser : IApplicationUser
    {
        public string Identity {get; set;}

        public int Id { get; set; }

        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();

        public string Username { get; set; }
    }

    public class AnonymousUser : IApplicationUser
    {
        public string Identity => "Anonymous";

        public int Id => 0;

        public IEnumerable<int> UseCaseIds => new List<int> { 4 };

        public string Username => "Anonymous";
    }
}
