using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IGradeRepository
    {
        void AddGrade(Grade grade, int orderId);
        void DeleteGradeById(int id);
        IEnumerable<Grade> GetAllGrades();
        Grade? GetGradeById(int id);
        void UpdateGradeById(Grade grade);
        List<Grade> GetGradesWithCleaners();
        List<Grade> GetGradesByCleaner(int cleanerId);

    }
}