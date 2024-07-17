using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using BL.Managers;

namespace BL.Policies {
    public class SubscribersPolicy 
    {
    }

    public class SubscribersPolicyRequirement : IAuthorizationRequirement
    {
    }

    public class SubscribersPolicyHandler : AuthorizationHandler<SubscribersPolicyRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager _userManager; 

        public SubscribersPolicyHandler(IHttpContextAccessor httpContextAccessor) // we can use inyection dependecies for userManager 
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = new UserManager();
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubscribersPolicyRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Request.Cookies.TryGetValue("user", out var cookieUser))
            {
                Console.WriteLine("cookie");
                Console.WriteLine(cookieUser);
                var user =  _userManager.RetrieveById(int.Parse(cookieUser)); // can be updated to string ID User --> db
                if(user != null){
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
                        context.Fail();
            return Task.CompletedTask; 
        }
    }
}