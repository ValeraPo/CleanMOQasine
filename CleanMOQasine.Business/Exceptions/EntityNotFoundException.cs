namespace CleanMOQasine.Business.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, string entityName) : base($"{entityName} {id} cannot be found") { }
    }
}
