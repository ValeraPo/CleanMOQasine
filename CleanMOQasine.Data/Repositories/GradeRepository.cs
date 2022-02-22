using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanMOQasine.Data.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly CleanMOQasineContext _context;

        public GradeRepository(CleanMOQasineContext context)
        {
            _context = context;
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
            oldGrade.Rating = grade.Rating;
            _context.SaveChanges();
        }

        public void DeleteGradeById(int id)
        {
            var oldGrade = _context.Grades.FirstOrDefault(g => g.Id == id && !g.IsDeleted);
            oldGrade.IsDeleted = true;
            _context.SaveChanges();
        }

        public void AddGrade(Grade grade, int orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == orderId);
            grade.Order = order;
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }

        public List<Grade> GetGradesWithCleaners()
        {
            var grades = _context.Grades.Include(o => o.Order)
                .ThenInclude(c => c.Cleaners)
                .Where(g => !g.IsDeleted).ToList();
            return grades;
        }

        public List<Grade> GetGradesByCleaner(int cleanerId)
        {
            var grades = _context.Grades
                .Include(g=>g.Order)
                .ThenInclude(o=>o.Cleaners)
                .Where(g => !g.IsDeleted && g.Order.Cleaners.Any(c => c.Id == cleanerId)).ToList();
            return grades;
        }
    }
}
