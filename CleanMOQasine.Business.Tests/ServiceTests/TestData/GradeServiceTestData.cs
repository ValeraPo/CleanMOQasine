using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Tests.ServiceTests
{
    public class GradeServiceTestData
    {
        public Grade GetGrade()
        {
            return new Grade
            {
                Comment = "За такую уборку можно даже отсосать!",
                Rating = 5,
                IsAnonymous = false,
                Id = 1,
                IsDeleted = false,
                Order = new Order
                {
                    Address = "Вяртсиля ага ага",
                    Cleaners = new List<User>(),
                    Client = new User
                    {
                        FirstName = "Antoxa",
                        LastName = "yaDa",
                        Role = Data.Enums.Role.Client
                    }
                }
            };
        }

        public List<Grade> GetGrades()
        {
            var grade1 = new Grade
            {
                Comment = "За такую уборку можно даже отсосать!",
                Rating = 5,
                IsAnonymous = false,
                Id = 1,
                IsDeleted = false,
                Order = new Order
                {
                    Address = "Вяртсиля ага ага",
                    Cleaners = new List<User>(),
                    Client = new User
                    {
                        FirstName = "Antoxa",
                        LastName = "yaDa",
                        Role = Data.Enums.Role.Client
                    }
                }
            };
            var grade2 = new Grade
            {
                Comment = "Я умер 2 года назад",
                Rating = 2,
                IsAnonymous = false,
                Id = 2,
                IsDeleted = false,
                Order = new Order
                {
                    Address = "Вяртсиля ага ага",
                    Cleaners = new List<User>(),
                    Client = new User
                    {
                        FirstName = "Виталя",
                        LastName = "КРасава",
                        Role = Data.Enums.Role.Client
                    }
                }
            };
            return new List<Grade> { grade1, grade2};
        }
    }
}
