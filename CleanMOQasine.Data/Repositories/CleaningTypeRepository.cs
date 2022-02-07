using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class CleaningTypeRepository : ICleaningTypeRepository
    {
        private readonly CleanMOQasineContext _context;
        private readonly ICleaningAdditionRepository _cleaningAdditionRepository;
        public CleaningTypeRepository(CleanMOQasineContext context, ICleaningAdditionRepository cleaningAdditionRepository)
        {
            _cleaningAdditionRepository = cleaningAdditionRepository;
            _context = context;
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

        public void AddCleaningAdditionToCleaningType(int cleaningTypeId, int cleaningAdditionId)
        {
            var interstedCleaningType = GetCleaningTypeById(cleaningTypeId);
            var cleaningAddition = _cleaningAdditionRepository.GetCleaningAdditionById(cleaningAdditionId);
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
