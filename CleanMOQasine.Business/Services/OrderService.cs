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

        //его можно разделить на несколько... и эксепшены поредачить (Т_Т)
        private List<UserModel> SearchCleaners(OrderModel orderModel)
        {
            TimeOnly timeStart = TimeOnly.FromDateTime(orderModel.Date);
            TimeOnly timeEnd = TimeOnly.FromDateTime(orderModel.Date + orderModel.TotalDuration);
            string day = orderModel.Date.DayOfWeek.ToString();

            var entities = _userRepository.GetCleaners(); //получение уборщиков
            if (entities.Count() == 0)
                throw new NotFoundException("Уборщиков нет (Т_Т)");

            var models = _mapper.Map<List<UserModel>>(entities); //маппинг в модели

            //объединение списков из дополнений к уборке (здесь как будто должно лежать в сервисе CleaningAdditions, например метод GetCleaningAdditionsByOrder
            //в котором ещё исключать одинаковые дополнения к уборке в CleaningAdditions заказа и CleaningType.CleaningAdditions заказа)
            var cleaningAdditions = orderModel.CleaningAdditions.Concat(orderModel.CleaningType.CleaningAdditions);

            //поиск по способностям -> если величина списка пересечения способностей с дополнениями совпадает с дополнениями к заказу
            //тут может в уборщиках искать по списку CleaningAdditions в другом методе
            var cleaners = models.Where(cl => cl.CleaningAdditions.Intersect(cleaningAdditions).Count() == cleaningAdditions.Count());
            if (cleaners.Count() == 0)
                throw new NotFoundException("Никто так не может (Т_Т)"); //тут хз как это разрешить

            //хотя бы один рабочий день совпадает с датой и временем заказа
            var freeCleaners = cleaners.Where(cl => cl.WorkingHours.Any(wh => wh.Day.ToString() == day
                                                                         && wh.StartTime <= timeStart
                                                                         && wh.EndTime >= timeEnd)

                                               //и нет ли других заказов на это время с учётом длитильности
                                               && cl.Orders.ToList().TrueForAll(o => o.Date + o.TotalDuration < orderModel.Date
                                                                                  || o.Date > orderModel.Date + orderModel.TotalDuration));
                                     

            if (freeCleaners.Count() == 0)
                throw new NotFoundException("Все клинеры в это время заняты");
                //здесь как ты сказал кидать ближайшую свободную дату, только вот это сообщение тоже
                //в виде эксепшена?

            return freeCleaners.ToList();
        }


    }
}
