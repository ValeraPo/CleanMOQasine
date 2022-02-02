using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Repositories
{
    public class CleaningAdditionRepository
    {
        public CleaningAddition GetCleaningAdditionById(int id)
        {
            CleanMOQasineContext context = CleanMOQasineContext.GetInstance();
            return context.CleaningAddition.FirstOrDefault(ca => ca.Id == id);
        }

        public List<CleaningAddition> GetAllCleaningAdditions()
        {
            CleanMOQasineContext context = CleanMOQasineContext.GetInstance();
            return context.CleaningAddition.Include(ca => ca.CleaningTypes)
                                           .Include(ca => ca.Users)
                                           .ToList();
        }

        public List<CleaningAddition> GetCleaningAdditionsByCleaningType(CleaningType cleaningType)
        {
            CleanMOQasineContext context = CleanMOQasineContext.GetInstance();
            List<CleaningAddition> cleaningAdditions = context.CleaningAddition.Where(ca => ca.CleaningTypes.Contains(cleaningType))
                                                                               .Include(ca => ca.CleaningTypes)
                                                                               .Include(ca => ca.Users)
                                                                               .ToList();
            return cleaningAdditions;
        }

        public void AddCleaningAddition(CleaningAddition cleaningAddition)
        {
            CleanMOQasineContext context = CleanMOQasineContext.GetInstance();
            context.CleaningAddition.Add(cleaningAddition);

            context.SaveChanges();
        }

        public void UpdateCleaningAddition(CleaningAddition updatedCleaningAddition)
        {
            CleanMOQasineContext context = CleanMOQasineContext.GetInstance();
            CleaningAddition cleaningAddition = GetCleaningAdditionById(updatedCleaningAddition.Id);
            cleaningAddition = updatedCleaningAddition;
            
            context.SaveChanges();
        }

        public void DeleteCleaningAddition(int id)
        {
            CleanMOQasineContext context = CleanMOQasineContext.GetInstance();
            CleaningAddition cleaningaddition = context.CleaningAddition.FirstOrDefault(ca => ca.Id == id);
            cleaningaddition.IsDeleted = true;
            context.SaveChanges();
        }

        public void RestoreCleaningAddition(int id)
        {
            CleanMOQasineContext context = CleanMOQasineContext.GetInstance();
            CleaningAddition cleaningaddition = context.CleaningAddition.FirstOrDefault(ca => ca.Id == id);
            cleaningaddition.IsDeleted = false;

            context.SaveChanges();
        }
    }
}
