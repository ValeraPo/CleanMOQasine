using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Business.Exceptions;

namespace CleanMOQasine.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICleaningAdditionRepository _cleaningAdditionRepository;
        private readonly ICleaningTypeRepository _cleaningTypeRepository;
       // private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRpository, 
            IUserRepository userRepository, 
            IMapper mapper,
            ICleaningAdditionRepository cleaningAdditionRepository,
            ICleaningTypeRepository cleaningTypeRepository)
            //IRoomRepository roomRepository)
        {
            _orderRepository = orderRpository;
            _userRepository = userRepository;
            _mapper = mapper;
            _cleaningAdditionRepository = cleaningAdditionRepository;
            _cleaningTypeRepository = cleaningTypeRepository;
           // _roomRepository = roomRepository;
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

        public List<OrderModel> GetOrdersByClientId(int idClient) =>
           GetAllOrders().Where(o => o.Client.Id == idClient).ToList();

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
            var cleaners = SearchCleaners(orderModel);
            // Определяем количество клинеров
            for (int i = 0; i <= (int)(orderModel.TotalDuration / TimeSpan.FromHours(4)); i++)
            {
                //Выбираем наименее загруженного клинера
                var cleaner = cleaners.MinBy(c => c.Orders.Count());
                orderModel.Cleaners.Add(cleaner);
            }
            
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

        public List<UserModel> SearchCleaners(OrderModel orderModel)
        {
            var cleaningAdditionModels = new List<CleaningAdditionModel>();
            cleaningAdditionModels.AddRange(orderModel.CleaningType.CleaningAdditions);
            if (orderModel.CleaningType != null)
                cleaningAdditionModels.AddRange(orderModel.CleaningAdditions);
            var cleaningAdditions = _mapper.Map<List<CleaningAddition>>(cleaningAdditionModels);

            var cleaners = _userRepository.GetCleaners(cleaningAdditions, orderModel.Date, orderModel.TotalDuration);
            // Смотрим даты на меся вперед
            int count = 0;
            while (cleaners.Count == 0 || count >= 30)
            {
                orderModel.Date.AddDays(1);
                cleaners = _userRepository.GetCleaners(cleaningAdditions, orderModel.Date, orderModel.TotalDuration);
                count++;
            }
            //Если в желаемый день не нашли клинеров говорим что можем сдвинуть заказ на несколько дней
            if (count > 0)
            { //выводим сообщение пользователю
            }
            return _mapper.Map<List<UserModel>>(cleaners);
        }


        public void AddPayment(PaymentModel payment, int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            if (order is null)
                throw new NotFoundException($"Order with id {orderId} does not exist");
            var newPayment = _mapper.Map<Payment>(payment);
            _orderRepository.AddPayment(newPayment, order);
        }
    }
}
