namespace CleanMOQasine.Business.Models
{
    public class GradeModel
    {
        public int Id { get; set; }
        public bool IsAnonymous { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool IsDeleted { get; set; }
        public OrderModel Order { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is GradeModel model &&
                   Id == model.Id &&
                   IsAnonymous == model.IsAnonymous &&
                   Comment == model.Comment &&
                   Rating == model.Rating &&
                   EqualityComparer<OrderModel>.Default.Equals(Order, model.Order);
        }
    }
}
