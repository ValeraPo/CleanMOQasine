using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Data.Repositories
{
    public class GradeRepository
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
            oldGrade = grade;
            _context.SaveChanges();
        }

        public void DeleteGradeById (int id)
        {
            var oldGrade = _context.Grades.FirstOrDefault(g => g.Id == id && !g.IsDeleted);
            if (oldGrade is null)
                return;
            oldGrade.IsDeleted = true;
            _context.SaveChanges();
        }

        public void AddGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }

    }
}
