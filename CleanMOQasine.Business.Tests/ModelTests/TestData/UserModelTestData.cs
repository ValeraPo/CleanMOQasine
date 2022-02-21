using CleanMOQasine.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Tests.ModelTests
{
    public class UserModelTestData
    {
        public UserModel GetUsersForTest(int numberTestData)
        {
            return numberTestData switch
            {
                1 => new UserModel
                {
                    FirstName = "Виталя",
                    LastName = "Крутойоченев",
                    Email = "vital@gmail.com",
                    Login = "RealnyKeks",
                    Role = Data.Enums.Role.Cleaner,
                    Orders = new List<OrderModel>
                        {
                            new OrderModel
                            {
                                Grade = new GradeModel{ Rating = 5, Comment = "Пацаны ваще ребята" }
                            },
                            new OrderModel
                            {
                                Grade = new GradeModel{ Rating = 3, Comment = "Жидко достаточно" }
                            },
                            new OrderModel
                            {
                                Grade = new GradeModel{ Rating = 1, Comment = "Насрали по ковёр, нашли спустя неделю" }
                            },
                            new OrderModel(),
                            new OrderModel()
                        }
                },
                2 => new UserModel
                {
                    FirstName = "Залупа",
                    LastName = "Геннадьевна",
                    Email = "zalupa@gmail.com",
                    Login = "YaNeZalupa",
                    Role = Data.Enums.Role.Cleaner,
                    Orders = new List<OrderModel>
                        {
                            new OrderModel
                            {
                                Grade = new GradeModel{ Rating = 5, Comment = "Хочу ещё такую уборку" }
                            },
                            new OrderModel
                            {
                                Grade = new GradeModel{ Rating = 5, Comment = "Ауфная тигрица, хоть и 68 лет" }
                            },
                            new OrderModel
                            {
                                Grade = new GradeModel{ Rating = 5, Comment = "Это не топ, это вышка!" }
                            },
                            new OrderModel
                            {
                                Grade = new GradeModel{ Rating = 4, Comment = "Блин. Пришла и хавать просила((" }
                            },
                            new OrderModel
                            {
                                Grade = new GradeModel{ Rating = 3, Comment = "Приставала к мужу, но убрала норм.Я ей за это пизданула (^_^)" }
                            },
                            new OrderModel(),
                            new OrderModel()
                        }
                },
                3 => new UserModel
                {
                    FirstName = "Диспетчер",
                    LastName = "Сильворгузбаньевичносисоссков",
                    Email = "dimas@gmail.com",
                    Login = "adidas3001",
                    Role = Data.Enums.Role.Cleaner,
                    Orders = new List<OrderModel>
                        {
                            new OrderModel(),
                            new OrderModel(),
                            new OrderModel(),
                            new OrderModel()
                        }
                },
                4 => new UserModel
                {
                    FirstName = "Артём",
                    LastName = "Кулик",
                    Email = "pluxurysport@gmail.com",
                    Login = "BoulevardDepo",
                    Role = Data.Enums.Role.Client
                },
                5 => new UserModel
                {
                    FirstName = "Давид",
                    LastName = "Джангирян",
                    Email = "hellahillz@gmail.com",
                    Login = "Jeembo",
                    Role = Data.Enums.Role.Admin
                },
                _ => new UserModel(),
            };
            ;
            
        }
    }
}
