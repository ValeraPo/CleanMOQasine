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

        public CleaningAddition? GetCleaningAdditionById(int id)
        {
            var entity = _context.CleaningAdditions/*.Include(ca => ca.CleaningTypes)*/
                           .FirstOrDefault(ca => ca.Id == id);
            return entity;
        }

        public List<CleaningAddition> GetAllCleaningAdditions()
        {
            return _context.CleaningAdditions.Where(ca => !ca.IsDeleted)
                           .Include(ca => ca.CleaningTypes)
                           .Include(ca => ca.Users)
                           .ToList();
        }

        public int AddCleaningAddition(CleaningAddition cleaningAddition)
        {
            _context.CleaningAdditions.Add(cleaningAddition);
            _context.SaveChanges();
            return cleaningAddition.Id;
        }

        public void UpdateCleaningAddition(int id, CleaningAddition updatedCleaningAddition)
        {
            var cleaningAddition = GetCleaningAdditionById(id);
            cleaningAddition.Price = updatedCleaningAddition.Price;
            cleaningAddition.Duration = updatedCleaningAddition.Duration;
            cleaningAddition.Name = updatedCleaningAddition.Name;
            _context.SaveChanges();
        }

        public void AddCleaningAdditionToCleaner(int cleaningAdditionId, int userId)
        {
            var user = _context.Users.First(u => u.Id == userId);
            var cleaningAddition = GetCleaningAdditionById(cleaningAdditionId);
            user.CleaningAdditions.Add(cleaningAddition);
            _context.SaveChanges();
        }

        public void DeleteCleaningAddition(int id)
        {
            var cleaningAddition = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == id);
            cleaningAddition.IsDeleted = true;
            _context.SaveChanges();
        }

        public void RestoreCleaningAddition(int id)
        {
            var cleaningaddition = _context.CleaningAdditions.FirstOrDefault(ca => ca.Id == id && ca.IsDeleted);
            cleaningaddition.IsDeleted = false;
            _context.SaveChanges();
        }

        //возможно в нём нет необходимости
        //public List<CleaningAddition> GetCleaningAdditionsByCleaningType(CleaningType cleaningType)
        //{
        //    return _context.CleaningAdditions.Where(ca => ca.CleaningTypes.Contains(cleaningType) && !ca.IsDeleted)
        //                   .Include(ca => ca.CleaningTypes)
        //                   .Include(ca => ca.Users)
        //                   .ToList();
        //}
    }
}