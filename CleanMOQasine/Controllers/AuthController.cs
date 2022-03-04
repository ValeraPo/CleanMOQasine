using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("The controller is used to log users")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [SwaggerOperation("Login user to get token.")]
        public ActionResult Login([FromBody]AuthInputModel authInputModel)
        {
            var token = _authService.Login(authInputModel.Login, authInputModel.Password);

            return Json(token);
        }
    }
}
