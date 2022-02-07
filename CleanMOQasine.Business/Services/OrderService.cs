﻿using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Repositories;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data;

namespace CleanMOQasine.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly Mapper _autoMapperInstance;

        public OrderService(IOrderRepository orderRpository, CleanMOQasineContext context, IUserRepository userRepository)
        {
            _orderRepository = orderRpository;
            _userRepository = userRepository;
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
            if (GetOrderById(id) is null)
                return;
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
            var order = _orderRepository.GetOrderById(idOrder);
            var cleaner = _userRepository.GetUserById(idUser);
            if (order is null || cleaner is null)
                return;
            _orderRepository.AddCleaner(order, cleaner);
        }

        public void RemoveCleaner(int idOrder, int idUser)
        {
            var order = _orderRepository.GetOrderById(idOrder);
            var cleaner = _userRepository.GetUserById(idUser);
            if (order is null || cleaner is null)
                return;
            _orderRepository.RemoveCleaner(order, cleaner);
        }

        public void DeleteOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order is null)
                return;
            _orderRepository.DeleteOrder(order);
        }

        public void RestoreOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order is null)
                return;
            _orderRepository.RestoreOrder(order);
        }
    }
}
