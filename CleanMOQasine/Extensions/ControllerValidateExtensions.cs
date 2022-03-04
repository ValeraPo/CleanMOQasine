using CleanMOQasine.API.Controllers;
using CleanMOQasine.Business.Exceptions;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanMOQasine.API.Extensions
{
    public static class ControllerValidateExtensions
    {
        public static int GetUserId(this ControllerBase controller)
        {
            var identity = controller.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                int userId;
                var userIdStr = identity.FindFirst(ClaimTypes.UserData)?.Value;
                var parsed = int.TryParse(userIdStr, out userId);
                if (parsed)
                    return userId;
            }
            throw new AuthenticationException("Вы не авторизованы");
        }

        public static void CheckCustomerOrder(this GradesController controller, List<OrderModel> orders, int orderId)
        {
            
            if (orders == null || orders.Count == 0)
            {
                throw new NotFoundException("У этого клиента не было заказов");
            }
            bool containsThisOrder = orders.Any(o => o.Id == orderId);
            if (!containsThisOrder)
                throw new NoAccessException("У этого клиента не было такого заказа");
        }

        public static void CheckAccessCleanerToWorkingTime(this WorkingTimesController controller, int cleanerId)
        {
            var identity = controller.HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return;
            
            var roleStr = identity.FindFirst(ClaimTypes.Role)?.Value;
            if (roleStr == Role.Admin.ToString())
                return;
            
            int userId = Int32.Parse(identity.FindFirst(ClaimTypes.UserData)?.Value);
            if (userId != cleanerId)
            {
                throw new NoAccessException("Клинер может взаимодействовать только со своими рабочими часами");
            }



        }
    }
}
