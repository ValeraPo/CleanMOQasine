using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanMOQasine.Business.Exeptions;

namespace CleanMOQasine.Business.Services
{
    public static class ThrowEntityException
    {
        public static void ThrowEntityNotFound<T>(int id, T entity)
        {
            if (entity is null)
                throw new EntityNotFoundException(id, typeof(T).Name);
        }
    }
}
