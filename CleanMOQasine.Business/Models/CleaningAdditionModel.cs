namespace CleanMOQasine.Business
{
    public class CleaningAdditionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }

        public bool IsDeleted { get; set; }
    }
}