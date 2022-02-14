﻿using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IOrderService
    {
        void AddCleaner(int idOrder, int idUser);
        void AddOrder(OrderModel orderModel);
        void DeleteOrder(int id);
        List<OrderModel> GetAllOrders();
        OrderModel GetOrderById(int id);
        void RemoveCleaner(int idOrderl, int idUser);
        void RestoreOrder(int id);
        void UpdateOrder(int id, OrderModel orderModel);
        void AddPayment(PaymentModel payment, int orderId);
        void DeletePayment(int id);
        List<PaymentModel> GetAllPayments();
        PaymentModel GetPaymentById(int id);
        void UpdatePayment(PaymentModel payment);
    }
}