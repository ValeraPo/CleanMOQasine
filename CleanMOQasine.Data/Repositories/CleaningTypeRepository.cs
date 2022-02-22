using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class CleaningTypeRepository : ICleaningTypeRepository
    {
        private readonly CleanMOQasineContext _context;

        public CleaningTypeRepository(CleanMOQasineContext context)
        {
            _context = context;
        }

        public CleaningType? GetCleaningTypeById(int id)
        {
            return _context.CleaningTypes.Include(ca => ca.CleaningAdditions)
                           .FirstOrDefault(ct => ct.Id == id);
        }

        public List<CleaningType> GetAllCleaningTypes()
        {
            return _context.CleaningTypes.Include(ca => ca.CleaningAdditions).ToList();
        }

        public int AddCleaningType(CleaningType cleaningType)
        {
            _context.CleaningTypes.Add(cleaningType);
            _context.SaveChanges();
            return cleaningType.Id;
        }

        public bool UpdateCleaningType(int id, CleaningType updatedCleaningType)
        {
            var cleaningType = GetCleaningTypeById(id);
            if (cleaningType == null)
            {
                return false;
            }
            cleaningType.Name = updatedCleaningType.Name;
            cleaningType.CleaningAdditions = updatedCleaningType.CleaningAdditions;
            cleaningType.Price = updatedCleaningType.Price;
            cleaningType.Order = updatedCleaningType.Order;

            _context.SaveChanges();
            return true;
        }

        public void AddCleaningAdditionToCleaningType(int cleaningTypeId, int cleaningAdditionId)
        {
            var interstedCleaningType = GetCleaningTypeById(cleaningTypeId);
            var cleaningAddition = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == cleaningAdditionId && !ca.IsDeleted);
            interstedCleaningType.CleaningAdditions.Add(cleaningAddition);
            _context.SaveChanges();
        }

        public void DeleteCleaningAdditionFromCleaningType(int cleaningTypeId, int cleaningAdditionId)
        {
            var interstedCleaningType = GetCleaningTypeById(cleaningTypeId);
            var cleaningAddition = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == cleaningAdditionId && !ca.IsDeleted);
            interstedCleaningType.CleaningAdditions.Remove(cleaningAddition);
            _context.SaveChanges();
        }

        public void DeleteCleaningType(int id)
        {
            var cleaningType = GetCleaningTypeById(id);
            cleaningType.IsDeleted = true;
            _context.SaveChanges();
        }

        public void RestoreCleaningType(int id)
        {
            var cleaningType = GetCleaningTypeById(id);
            cleaningType.IsDeleted = false;
            _context.SaveChanges();
        }
    }
}
