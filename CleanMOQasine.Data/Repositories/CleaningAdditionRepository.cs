using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class CleaningAdditionRepository : ICleaningAdditionRepository
    {
        private readonly CleanMOQasineContext _context;
        public CleaningAdditionRepository(CleanMOQasineContext context)
        {
            _context = context;
        }
        public CleaningAddition GetCleaningAdditionById(int id)
        {
            return _context.CleaningAdditions.Include(ca => ca.CleaningTypes)
                           .FirstOrDefault(ca => ca.Id == id && !ca.IsDeleted);
        }

        public List<CleaningAddition> GetAllCleaningAdditions()
        {
            return _context.CleaningAdditions.Where(ca => !ca.IsDeleted)
                           .Include(ca => ca.CleaningTypes)
                           .Include(ca => ca.Users)
                           .ToList();
        }

        public List<CleaningAddition> GetCleaningAdditionsByCleaningType(CleaningType cleaningType)
        {
            return _context.CleaningAdditions.Where(ca => ca.CleaningTypes.Contains(cleaningType) && !ca.IsDeleted)
                           .Include(ca => ca.CleaningTypes)
                           .Include(ca => ca.Users)
                           .ToList();
        }

        public void AddCleaningAddition(CleaningAddition cleaningAddition)
        {
            _context.CleaningAdditions.Add(cleaningAddition);
            _context.SaveChanges();
        }

        public void UpdateCleaningAddition(int id, CleaningAddition updatedCleaningAddition)
        {
            var cleaningAddition = GetCleaningAdditionById(id);
            cleaningAddition.Price = updatedCleaningAddition.Price;
            cleaningAddition.Duration = updatedCleaningAddition.Duration;
            cleaningAddition.Name = updatedCleaningAddition.Name;
            _context.SaveChanges();
        }

        public void DeleteCleaningAddition(int id)
        {
            var cleaningaddition = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == id);
            cleaningaddition.IsDeleted = true;
            _context.SaveChanges();
        }

        public void RestoreCleaningAddition(int id)
        {
            var cleaningaddition = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == id && ca.IsDeleted);
            cleaningaddition.IsDeleted = false;
            _context.SaveChanges();
        }
    }
}
