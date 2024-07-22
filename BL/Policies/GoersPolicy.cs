using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using BL.Managers;

namespace BL.Policies {
    public class GoersPolicy 
    {
    }

    public class GoersPolicyRequirement : IAuthorizationRequirement
    {
    }

    public class GoersPolicyHandler : AuthorizationHandler<GoersPolicyRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager _userManager; 

        public GoersPolicyHandler(IHttpContextAccessor httpContextAccessor) // we can use inyection dependecies for userManager 
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = new UserManager();
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GoersPolicyRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Request.Cookies.TryGetValue("user", out var cookieUser))
            {
              
                var user =  _userManager.RetrieveById(int.Parse(cookieUser)); // can be updated to string ID User --> db
                if(user != null){
                    if(user.TypeUserId == 2){  
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