namespace CleanMOQasine.API.Models
{
    public class OrderInsertInputModel : OrderUpdateInputModel
    {
        public int ClientId { get; set; } //скорее всего здесь будет не int, а какой-нибудь UserInputModel
    }
}

