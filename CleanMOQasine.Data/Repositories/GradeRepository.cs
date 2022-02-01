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
        Garbage Info = Garbage.GetInstance();
        public IEnumerable<Grade> GetAllGrades()
        {
            return Info.Context.Grade.Where(g => !g.IsDeleted).ToList();
        }
        public Grade GetGradeById (int id)
        {
            return Info.Context.Grade.FirstOrDefault(g => g.Id == id && !g.IsDeleted);
        }

        public void UpdateGradeById(Grade grade)
        {
            var oldGrade = Info.Context.Grade.FirstOrDefault(g => g.Id == grade.Id && !g.IsDeleted);
            oldGrade = grade;
            Info.Context.SaveChanges();
        }
        public void Delete (int id)
        {
            var oldGrade = Info.Context.Grade.FirstOrDefault(g => g.Id == id && !g.IsDeleted);
            oldGrade.IsDeleted = true;
            oldGrade.Order.Grade = null;
            Info.Context.SaveChanges();
            //ef check
        }
        public void AddGrade(Grade grade)
        {
            Info.Context.Grade.Add(grade);
            var boundedOrder = Info.Context.Order.FirstOrDefault(o => o.Id == grade.OrderId);
            if (boundedOrder.Grade is null)
            {
                Info.Context.SaveChanges();
                return;
            }
            boundedOrder.Grade = grade;
            boundedOrder.GradeId = grade.Id;
            Info.Context.SaveChanges();
        }
    }
}
