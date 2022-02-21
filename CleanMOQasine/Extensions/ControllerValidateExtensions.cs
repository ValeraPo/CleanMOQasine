using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanMOQasine.API.Extensions
{
    public static class ControllerValidateExtensions
    {
        public static int GetUserId(this ControllerBase controllerBase)
        {
            var identity = controllerBase.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                int userId;
                var userIdStr = identity.FindFirst(ClaimTypes.UserData)?.Value;
                var parsed = int.TryParse(userIdStr, out userId);
                if (parsed)
                    return userId;
            }
            //return null;
            throw new Exception();
        }
    }
}
