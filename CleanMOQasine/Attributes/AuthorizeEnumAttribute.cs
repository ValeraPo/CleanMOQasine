using Microsoft.AspNetCore.Authorization;

namespace CleanMOQasine.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizeEnumAttribute : AuthorizeAttribute
    {
        public AuthorizeEnumAttribute(params object[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("The passed argument is not a enum.");

            this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }
    }
}
