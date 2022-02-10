using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanMOQasine.Business.Exeptions;

namespace CleanMOQasine.Business.Services
{
    public static class ThrowEntityException
    {
        public static void ThrowEntityNotFound(int id, object? obj)
        {
            if (obj is null)
                throw new EntityNotFoundException(id, obj);
        }
    }
}
