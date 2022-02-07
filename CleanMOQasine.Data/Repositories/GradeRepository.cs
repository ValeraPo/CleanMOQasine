using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly CleanMOQasineContext _context;
        public bool _isInitialized;

        public GradeRepository(CleanMOQasineContext context)
        {
            _context = context;
            _isInitialized = true;
        }

        public IEnumerable<Grade> GetAllGrades()
            => _context.Grades.Where(g => !g.IsDeleted).ToList();

        public Grade? GetGradeById(int id) 
            => _context.Grades.FirstOrDefault(g => g.Id == id && !g.IsDeleted);

        public void UpdateGradeById(Grade grade)
        {
            var oldGrade = _context.Grades.FirstOrDefault(g => g.Id == grade.Id && !g.IsDeleted);
            oldGrade.Comment = grade.Comment;
            oldGrade.IsAnonymous = grade.IsAnonymous;
            oldGrade.IsDeleted = grade.IsDeleted;
            oldGrade.Rating = grade.Rating;
            _context.SaveChanges();
        }

        public int DeleteGradeById(int id)
        {
            var oldGrade = _context.Grades.FirstOrDefault(g => g.Id == id && !g.IsDeleted);
            if (oldGrade is null)
                return -1;
            oldGrade.IsDeleted = true;
            _context.SaveChanges();
            return 1;
        }

        public void AddGrade(Grade grade, int orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
            grade.Order = order;
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }

    }
}
