using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using BL.Managers;

namespace BL.Policies {
    public class CoachPolicy 
    {
    }

    public class CoachPolicyRequirement : IAuthorizationRequirement
    {
    }

    public class CoachPolicyHandler : AuthorizationHandler<CoachPolicyRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager _userManager; 

        public CoachPolicyHandler(IHttpContextAccessor httpContextAccessor) // we can use inyection dependecies for userManager 
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = new UserManager();
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CoachPolicyRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Request.Cookies.TryGetValue("user", out var cookieUser))
            {
                Console.WriteLine(cookieUser);
                var user =  _userManager.RetrieveById(int.Parse(cookieUser)); // can be updated to string ID User --> db
                if(user != null && user.TypeUserId == 3){
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            context.Fail();
            return Task.CompletedTask; 
        }
    }
}