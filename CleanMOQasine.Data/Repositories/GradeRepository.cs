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
        protected Garbage Info = Garbage.GetInstance();

        public IEnumerable<Grade> GetAllGrades()
        {
            return Info.Context.Grade.Where(g => !g.IsDeleted).ToList();
        }

        public Grade GetGradeById (int id)
        {
            var grade = Info.Context.Grade.FirstOrDefault(g => g.Id == id && !g.IsDeleted);
            return grade;
        }

        public void UpdateGradeById(Grade grade)
        {
            var oldGrade = Info.Context.Grade.FirstOrDefault(g => g.Id == grade.Id && !g.IsDeleted);
            oldGrade = grade;
            Info.Context.SaveChanges();
        }

        public void DeleteGradeById (int id)
        {
            var oldGrade = Info.Context.Grade.FirstOrDefault(g => g.Id == id && !g.IsDeleted);
            if (oldGrade is null)
                return;
            oldGrade.IsDeleted = true;
            Info.Context.SaveChanges();
            //ef check
        }

        public void AddGrade(Grade grade)
        {
            Info.Context.Grade.Add(grade);
            Info.Context.SaveChanges();
        }

    }
}
