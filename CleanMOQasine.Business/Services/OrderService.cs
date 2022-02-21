using AutoMapper;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Business.Exceptions;

namespace CleanMOQasine.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRpository, IUserRepository userRepository
            , IMapper mapper)
        {
            _orderRepository = orderRpository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public OrderModel GetOrderById(int id)
        {
            var entity = _orderRepository.GetOrderById(id);
            return _mapper.Map<OrderModel>(entity);
        }

        public List<OrderModel> GetAllOrders()
        {
            var entities = _orderRepository.GetAllOrders();
            return _mapper.Map<List<OrderModel>>(entities);
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
