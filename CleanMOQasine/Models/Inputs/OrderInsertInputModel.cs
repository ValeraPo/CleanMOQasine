namespace CleanMOQasine.API.Models
{
    public class OrderInsertInputModel : OrderUpdateInputModel
    {
        public int IdClient { get; set; } //скорее всего здесь будет не int, а какой-нибудь UserInputModel
    }
}

