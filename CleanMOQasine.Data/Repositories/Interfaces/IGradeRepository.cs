using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IGradeRepository
    {
        void AddGrade(Grade grade, int orderId);
        int DeleteGradeById(int id);
        IEnumerable<Grade> GetAllGrades();
        Grade? GetGradeById(int id);
        void UpdateGradeById(Grade grade);
    }
}