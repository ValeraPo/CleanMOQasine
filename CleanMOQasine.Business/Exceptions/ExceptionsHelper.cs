using CleanMOQasine.Business.Exceptions;

namespace CleanMOQasine.Business.Services
{
    public static class ExceptionsHelper
    {
        public static void ThrowIfEntityNotFound<T>(int id, T entity)
        {
            if (entity is null)
                throw new EntityNotFoundException(id, typeof(T).Name);
        }
    }
}
