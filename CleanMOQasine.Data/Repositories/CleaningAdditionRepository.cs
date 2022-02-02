using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class CleaningAdditionRepository
    {
        private readonly CleanMOQasineContext _context;
        public CleaningAdditionRepository()
        {
            _context = CleanMOQasineContext.GetInstance();
        }
        public CleaningAddition GetCleaningAdditionById(int id)
        {
            return _context.CleaningAddition.Include(ca => ca.CleaningTypes)
                           .FirstOrDefault(ca => ca.Id == id);
        }

        public List<CleaningAddition> GetAllCleaningAdditions()
        {
            return _context.CleaningAddition.Include(ca => ca.CleaningTypes)
                            .Include(ca => ca.Users)
                            .ToList();
        }

        public List<CleaningAddition> GetCleaningAdditionsByCleaningType(CleaningType cleaningType)
        {
            return _context.CleaningAddition.Where(ca => ca.CleaningTypes.Contains(cleaningType))
                           .Include(ca => ca.CleaningTypes)
                           .Include(ca => ca.Users)
                           .ToList();
        }

        public void AddCleaningAddition(CleaningAddition cleaningAddition)
        {
            _context.CleaningAddition.Add(cleaningAddition);
            _context.SaveChanges();
        }

        public void UpdateCleaningAddition(CleaningAddition updatedCleaningAddition)
        {
            var cleaningAddition = GetCleaningAdditionById(updatedCleaningAddition.Id);
            cleaningAddition = updatedCleaningAddition;
            _context.SaveChanges();
        }

        public void DeleteCleaningAddition(int id)
        {
            var cleaningaddition = _context.CleaningAddition.FirstOrDefault(ca => ca.Id == id);
            cleaningaddition.IsDeleted = true;
            _context.SaveChanges();
        }

        public void RestoreCleaningAddition(int id)
        {
            var cleaningaddition = _context.CleaningAddition.FirstOrDefault(ca => ca.Id == id);
            cleaningaddition.IsDeleted = false;
            _context.SaveChanges();
        }
    }
}
