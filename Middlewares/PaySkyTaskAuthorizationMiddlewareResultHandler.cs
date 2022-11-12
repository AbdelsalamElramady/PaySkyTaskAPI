using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using System.Net.Http.Headers;

namespace PaySkyTaskAPI.Middlewares
{
    public class PaySkyTaskAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler DefaultHandler = new AuthorizationMiddlewareResultHandler();
        private readonly IConfiguration _configuration;

        public PaySkyTaskAuthorizationMiddlewareResultHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task HandleAsync(
            RequestDelegate requestDelegate,
            HttpContext httpContext,
            AuthorizationPolicy authorizationPolicy,
            PolicyAuthorizationResult policyAuthorizationResult)
        {
            if (!AuthenticationHeaderValue.TryParse(httpContext.Request.Headers.Authorization, out var headerValue))
                throw new Exception("Unauthorized");

            var idToken = headerValue.Parameter;

            FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance
                .VerifyIdTokenAsync(idToken);

            if (string.IsNullOrEmpty(decodedToken.Uid))
                throw new Exception("Invalid Token");

            policyAuthorizationResult = PolicyAuthorizationResult.Success();
            await DefaultHandler.HandleAsync(requestDelegate, httpContext, authorizationPolicy, policyAuthorizationResult);

        }
    }
}
