using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class CleaningTypeRepository : ICleaningTypeRepository
    {
        private readonly CleanMOQasineContext _context;
        public CleaningTypeRepository()
        {
            _context = CleanMOQasineContext.GetInstance();
        }
        public CleaningType GetCleaningTypeById(int id)
        {
            return _context.CleaningTypes.Include(ca => ca.CleaningAdditions)
                           .FirstOrDefault(ct => ct.Id == id);
        }

        public List<CleaningType> GetAllCleaningTypes()
        {
            return _context.CleaningTypes.Include(ca => ca.CleaningAdditions).ToList();
        }

        public void AddCleaningType(CleaningType cleaningType)
        {
            _context.CleaningTypes.Add(cleaningType);
            _context.SaveChanges();
        }

        public void UpdateCleaningType(int id, CleaningType updatedCleaningType)
        {
            var cleaningType = GetCleaningTypeById(id);
            cleaningType.Name = updatedCleaningType.Name;
            cleaningType.CleaningAdditions = updatedCleaningType.CleaningAdditions;
            cleaningType.Price = updatedCleaningType.Price;
            cleaningType.Order = updatedCleaningType.Order;

            _context.SaveChanges();
        }

        public void AddCleaningAdditionToCleaningType(int cleaningTypeId, CleaningAddition cleaningAddition)
        {
            var interstedCleaningType = GetCleaningTypeById(cleaningTypeId);
            interstedCleaningType.CleaningAdditions.Add(cleaningAddition);
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
