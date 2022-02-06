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

        public void UpdateOrder(int id, OrderModel orderModel)
        {
            var entity = _autoMapperInstance.Map<Order>(orderModel);
            _orderRepository.UpdateOrder(id, entity);
        }

        public void AddOrder(OrderModel orderModel)
        {
            var entity = _autoMapperInstance.Map<Order>(orderModel);
            _orderRepository.AddOrder(entity);
        }

        public void AddCleaner(int idOrder, int idUser)
        {
            _orderRepository.AddCleaner(idOrder, idUser);
        }

        public void RemoveCleaner(int idOrderl, int idUser)
        {
            _orderRepository.RemoveCleaner(idOrderl, idUser);
        }

        public void DeleteOrder(int id) => _orderRepository.DeleteOrder(id);

        public void RestoreOrder(int id) => _orderRepository.RestoreOrder(id);
    }
}
