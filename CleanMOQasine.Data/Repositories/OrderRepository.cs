using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public class OrderRepository
    {
        private readonly CleanMOQasineContext _dbContext;


        public IEnumerable<Order> GetAllOrders() => _dbContext.Order.Where(o => !o.IsDeleted).ToList();

        public Order GetOrderById(int id) => _dbContext.Order.FirstOrDefault(o => o.Id == id);

        public void UpdateOrder(Order order)
        {
            var oldOrder = _dbContext.Order.FirstOrDefault(o => o.Id == order.Id);
            oldOrder.CleaningType = order.CleaningType;
            oldOrder.Grade = order.Grade;
            oldOrder.Address = order.Address;
            oldOrder.TotalPrice = order.TotalPrice;
            oldOrder.TotalDuration = order.TotalDuration;
            oldOrder.Date = order.Date;
            oldOrder.Rooms = order.Rooms;
            oldOrder.CleaningAdditions = order.CleaningAdditions;
            Save(); 
        }

        public void AddCleaner(Order order, User cleaner)
        {
            var oldOrder = _dbContext.Order.FirstOrDefault(o => o.Id == order.Id);
            oldOrder.InvolvedUsers.Add(cleaner);
            Save();
        }

        public void RemoveCleaner(Order order, User cleaner)
        {
            var oldOrder = _dbContext.Order.FirstOrDefault(o => o.Id == order.Id);
            oldOrder.InvolvedUsers.Remove(cleaner);
            Save();
        }

        public void AddPayment(Order order, Payment payment)
        {
            var oldOrder = _dbContext.Order.FirstOrDefault(o => o.Id == order.Id);
            oldOrder.Payments.Add(payment);
            Save();
        }

        public void DeleteOrder(int id)
        {
            var order = _dbContext.Order.FirstOrDefault(o => o.Id == id);
            order.IsDeleted = true;
            Save();
        }

        public void RestoreOrder(int id)
        {
            var order = _dbContext.Order.FirstOrDefault(o => o.Id == id);
            order.IsDeleted = true;
            Save();
        }

        public void AddOrder(Order order)
        {
            _dbContext.Order.Add(order);
            Save();
        }

        private void Save() => _dbContext.SaveChanges();
    }
}
