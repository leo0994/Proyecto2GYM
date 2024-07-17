using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using BL.Managers;

namespace BL.Policies {
    public class EmployeePolicy 
    {
    }

    public class EmployeePolicyRequirement : IAuthorizationRequirement
    {
    }

    public class EmployeePolicyHandler : AuthorizationHandler<EmployeePolicyRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager _userManager; 

        public EmployeePolicyHandler(IHttpContextAccessor httpContextAccessor) // we can use inyection dependecies for userManager 
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = new UserManager();
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmployeePolicyRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Request.Cookies.TryGetValue("user", out var cookieUser))
            {
                Console.WriteLine("cookie");
                Console.WriteLine(cookieUser);
                var user =  _userManager.RetrieveById(int.Parse(cookieUser)); // can be updated to string ID User --> db
                if(user != null && user.TypeUserId == 1 || user.TypeUserId == 3 || user.TypeUserId == 4 ){
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask; 
        }
    }
}