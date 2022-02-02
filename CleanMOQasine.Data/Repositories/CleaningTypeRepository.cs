using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class CleaningTypeRepository
    {
        private readonly CleanMOQasineContext _context;
        public CleaningTypeRepository()
        {
            _context = CleanMOQasineContext.GetInstance();
        }
        public CleaningType GetCleaningTypeById(int id)
        {
            return _context.CleaningType.Include(ca => ca.CleaningAdditions)
                                       .FirstOrDefault(ct => ct.Id == id);
        }

        public List<CleaningType> GetAllCleaningTypes()
        {
            
            return _context.CleaningType.Include(ca => ca.CleaningAdditions).ToList();
        }

        public void AddCleaningType(CleaningType cleaningType)
        {
            
            _context.CleaningType.Add(cleaningType);

            _context.SaveChanges();
        }

        public void UpdateCleaningType(CleaningType updatedCleaningType)
        {

            var cleaningType = GetCleaningTypeById(updatedCleaningType.Id);
            cleaningType = updatedCleaningType;

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
