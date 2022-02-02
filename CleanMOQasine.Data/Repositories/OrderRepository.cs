using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public class OrderRepository
    {
        Garbage Info = Garbage.GetInstance();
        public IEnumerable<Order> GetAllGrades()
        {
            return Info.Context.Order.Where(o => !o.IsDeleted).ToList();
        }
        public Order GetGradeById(int id)
        {
            return Info.Context.Order.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
        }

        public void UpdateGradeById(Order order)
        {
            var oldOrder = Info.Context.Order.FirstOrDefault(o => o.Id == order.Id && !o.IsDeleted);
            oldOrder = order;
            Info.Context.SaveChanges();
        }
        public void Delete(int id)
        {
            var order = Info.Context.Order.FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            if (order == null)
                return;
            order.Client.ClientOrders.Remove(order);
            foreach (var cleaner in order.Cleaners)
                cleaner.CleanerOrders.Remove(order);
            foreach (var orderCleaner in order.OrderCleaners)
                orderCleaner.IsDeleted = true;
            foreach (var add in order.CleaningAdditions)
                add.Orders.Remove(order);
            foreach (var orderCleaningAdd in order.OrderCleaningAdditions)
                orderCleaningAdd.IsDeleted = true;
            foreach(var room in order.Rooms)
                room.Orders.Remove(order);
            foreach(var payment in order.Payments)
                payment.IsDeleted = true;
            order.Grade.IsDeleted = true;

            order.IsDeleted = true;
            Info.Context.SaveChanges();
        }
        public void AddGrade(Order order)
        {
            Info.Context.Order.Add(order);
            Info.Context.SaveChanges();
        }
    }
}
