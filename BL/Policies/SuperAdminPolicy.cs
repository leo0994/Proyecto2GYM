using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using BL.Managers;

namespace BL.Policies {
    public class SuperAdminPolicy 
    {
    }

    public class SuperAdminPolicyRequirement : IAuthorizationRequirement
    {
    }

    public class SuperAdminPolicyHandler : AuthorizationHandler<SuperAdminPolicyRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager _userManager; 

        public SuperAdminPolicyHandler(IHttpContextAccessor httpContextAccessor) // we can use inyection dependecies for userManager 
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = new UserManager();
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SuperAdminPolicyRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Request.Cookies.TryGetValue("user", out var cookieUser))
            {
               
                var user =  _userManager.RetrieveById(int.Parse(cookieUser)); // can be updated to string ID User --> db
                if(user != null){
                    if(user.TypeUserId == 1){
                        context.Succeed(requirement);
                        return Task.CompletedTask;
                    }
                }
            }
            context.Fail();
            return Task.CompletedTask; 
        }
    }
}