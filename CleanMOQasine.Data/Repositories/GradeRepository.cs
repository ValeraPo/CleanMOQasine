using CleanMOQasine.Data.Entities;
using Microsoft.EntityFrameworkCore;
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

        public GradeRepository()
        {
            _context = CleanMOQasineContext.GetInstance();
        }

        public IEnumerable<Grade> GetAllGrades()
            => _context.Grade.Include(o => o.Order).Where(g => !g.IsDeleted).ToList();

        public Grade? GetGradeById(int id)
        {

            var a =  _context.Grade.Include(o => o.Order).FirstOrDefault(g => g.Id == id && !g.IsDeleted);
            return a;
        }

        public void UpdateGradeById(Grade grade)
        {
            var oldGrade = _context.Grade.FirstOrDefault(g => g.Id == grade.Id && !g.IsDeleted);
            grade.OrderId = oldGrade.OrderId;
            oldGrade = grade;
            _context.SaveChanges();
        }

        public void DeleteGradeById (int id)
        {
            var oldGrade = _context.Grade.FirstOrDefault(g => g.Id == id && !g.IsDeleted);
            if (oldGrade is null)
                return;
            oldGrade.IsDeleted = true;
            _context.SaveChanges();
        }

        public void AddGrade(Grade grade)
        {
            _context.Grade.Add(grade);
            _context.SaveChanges();
        }

    }
}
