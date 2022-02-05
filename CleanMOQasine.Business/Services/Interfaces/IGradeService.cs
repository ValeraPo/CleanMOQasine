﻿using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IGradeService
    {
        void AddGrade(GradeModel grade, int orderId);
        int DeleteGradeById(int id);
        IEnumerable<GradeModel> GetAllGrades();
        GradeModel GetGradeById(int id);
        void UpdateGrade(GradeModel grade, int id);
    }
}