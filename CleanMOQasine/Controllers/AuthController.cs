using CleanMOQasine.API.Models;
using CleanMOQasine.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanMOQasine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]AuthInputModel authInputModel)
        {
            var token = _authService.Login(authInputModel.Login, authInputModel.Password);

            return Json(token);
        }
    }
}
