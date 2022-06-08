using ClinicalApp.Interface;
using System.Security.Claims;

namespace ClinicalApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpContextAccessor _htppContext;

        public UserRepository(IHttpContextAccessor htppContext)
        {
            _htppContext = htppContext;
        }

        public string GetUserId()
        {
            return _htppContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public bool IsAuthenticated()
        {
            return _htppContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
