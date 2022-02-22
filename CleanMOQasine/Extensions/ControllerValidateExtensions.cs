using CleanMOQasine.API.Controllers;
using CleanMOQasine.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanMOQasine.API.Extensions
{
    public static class ControllerValidateExtensions
    {
        public static int GetUserId(this GradesController controller)
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
            throw new Exception("Вы не авторизованы");
        }

        public static void CheckCustomerOrder(this GradesController controller, List<OrderModel> orders, int orderId)
        {
            
            if (orders == null || orders.Count == 0)
            {
                throw new Exception("У этого клиента не было заказов");
            }
            bool containsThisOrder = orders.Any(o => o.Id == orderId);
            if (!containsThisOrder)
                throw new Exception("У этого клиента не было такого заказа");
        }
    }
}
