using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Exceptions;
using CleanMOQasine.Data.Repositories;

namespace CleanMOQasine.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRpository, IUserRepository userRepository, IMapper mapper)
        {
            _orderRepository = orderRpository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public OrderModel GetOrderById(int id)
        {
            var entity = _orderRepository.GetOrderById(id);
            ExceptionsHelper.ThrowIfEntityNotFound(id, entity);
            return _mapper.Map<OrderModel>(entity);
        }

        public List<OrderModel> GetAllOrders()
        {
            var entities = _orderRepository.GetAllOrders();
            return _mapper.Map<List<OrderModel>>(entities);
        }

        public List<OrderModel> GetOrdersByCleanerId(int idCleaner)
        {
            var orders = new List<OrderModel>();
            foreach (var order in GetAllOrders())
            {
                if (order.Cleaners.Select(c => c.Id).Contains(idCleaner))
                    orders.Add(order);
            }
            return orders;
        }

        public void UpdateOrder(int id, OrderModel orderModel)
        {
            var order = _orderRepository.GetOrderById(id);
            ExceptionsHelper.ThrowIfEntityNotFound(id, order);
            var entity = _mapper.Map<Order>(orderModel);
            _orderRepository.UpdateOrder(order, entity);
        }

        public void AddOrder(OrderModel orderModel)
        {
            //Выбираем наименее загруженного клинера
            var cleaner = SearchCleaners(orderModel).MinBy(c => c.Orders.Count());
            orderModel.Cleaners.Add(cleaner);
            var entity = _mapper.Map<Order>(orderModel);
            _orderRepository.AddOrder(entity);
        }

        public void AddCleaner(int idOrder, int idUser)
        {
            var order = _orderRepository.GetOrderById(idOrder);
            ExceptionsHelper.ThrowIfEntityNotFound(idOrder, order);
            var cleaner = _userRepository.GetUserById(idUser);
            ExceptionsHelper.ThrowIfEntityNotFound(idUser, cleaner);
            _orderRepository.AddCleaner(order, cleaner);
        }

        public void RemoveCleaner(int idOrder, int idUser)
        {
            var order = _orderRepository.GetOrderById(idOrder);
            ExceptionsHelper.ThrowIfEntityNotFound(idOrder, order);
            var cleaner = _userRepository.GetUserById(idUser);
            ExceptionsHelper.ThrowIfEntityNotFound(idUser, cleaner);
            _orderRepository.RemoveCleaner(order, cleaner);
        }

        public void DeleteOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            ExceptionsHelper.ThrowIfEntityNotFound(id, order);
            _orderRepository.DeleteOrder(order);
        }

        public void RestoreOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            ExceptionsHelper.ThrowIfEntityNotFound(id, order);
            _orderRepository.RestoreOrder(order);
        }

        public List <UserModel> SearchCleaners(OrderModel orderModel)
        {
            var conditions = new List<Func<User, bool>>()
            {
                // Выбираем только клинеров
                new Func<User, bool>(u => u.Role == Data.Enums.Role.Cleaner),
                // Выбираем тех кто работает в это время
                new Func<User, bool>(u => u.WorkingHours
                .Where(h => (int)h.Day % 7 == (int)orderModel.Date.DayOfWeek)
                .ToList()
                .TrueForAll(h => h.StartTime <= orderModel.Date
                    && h.EndTime >= orderModel.Date + orderModel.TotalDuration)),
                // Выбираем тех кто не занят в это время
                new Func<User, bool>(u => u.CleanerOrders
                .Select(o => o.Date)
                .ToList()
                .TrueForAll(o => o != orderModel.Date))
            };
            var cleaners = _userRepository.GetUsersByConditions(conditions);
            if (cleaners.Count == 0)
                throw new NotFoundException("Все клинеры в это время заняты");

            return _mapper.Map<List<UserModel>>(cleaners);
        }
    }
}
