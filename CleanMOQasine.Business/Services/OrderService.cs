using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Entities;


namespace CleanMOQasine.Business.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly Mapper _autoMapperInstance;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _autoMapperInstance = AutoMapperToData.GetInstance();
        }

        public OrderModel GetOrderById(int id)
        {
            var entity = _orderRepository.GetOrderById(id);
            return _autoMapperInstance.Map<OrderModel>(entity);
        }

        public List<OrderModel> GetAllOrders()
        {
            var entities = _orderRepository.GetAllOrders();
            return _autoMapperInstance.Map<List<OrderModel>>(entities);
        }

        public void UpdateOrder(OrderModel orderModel)
        {
            var entity = _autoMapperInstance.Map<Order>(orderModel);
            _orderRepository.UpdateOrder(entity);
        }

        public void AddOrder(OrderModel orderModel)
        {
            var entity = _autoMapperInstance.Map<Order>(orderModel);
            _orderRepository.AddOrder(entity);
        }

        public void AddCleaner(OrderModel orderModel, int idUser)
        {
            var entity = _autoMapperInstance.Map<Order>(orderModel);
            _orderRepository.AddCleaner(entity, idUser);
        }

        public void RemoveCleaner(OrderModel orderModel, int idUser)
        {
            var entity = _autoMapperInstance.Map<Order>(orderModel);
            _orderRepository.RemoveCleaner(entity, idUser);
        }

        public void AddPayment(OrderModel orderModel, int idPayment)
        {
            var entity = _autoMapperInstance.Map<Order>(orderModel);
            _orderRepository.AddPayment(entity, idPayment);
        }

        public void DeleteOrder(int id) => _orderRepository.DeleteOrder(id);

        public void RestoreOrder(int id) => _orderRepository.RestoreOrder(id);
    }
}
