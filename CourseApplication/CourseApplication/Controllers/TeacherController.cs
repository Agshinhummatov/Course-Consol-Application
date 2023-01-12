using DomianLayer.Common;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApplication.Controllers
{
    public class TeacherController
    {
        private readonly ITeacherService _teacherService;

        public TeacherController()
        {
            _teacherService = new TeacherService();
        }

        public void Create()
        {
            ConsoleColor.DarkGreen.WriteConsole("Please add teacher name :");
            TeacherName: string teacherName = Console.ReadLine();

            if (teacherName == string.Empty)
            {
                ConsoleColor.DarkGreen.WriteConsole("Please dont empty teacher name");
                goto TeacherName;
            }


            ConsoleColor.DarkGreen.WriteConsole("Please add teacher surname ");
            TeacherSurname : string teacherSurname = Console.ReadLine();

            if (teacherSurname == string.Empty)
            {
                ConsoleColor.DarkGreen.WriteConsole("Please dont empty teacher surname");
                goto TeacherSurname;
            }

            ConsoleColor.DarkGreen.WriteConsole("Please add teacher adress ");
            TeacherAddress: string teacherAddress = Console.ReadLine();

            if (teacherAddress == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty teacher adress");
                goto TeacherAddress;
            }


            ConsoleColor.Red.WriteConsole("Please add teacher age ");
            TeacherAge : string teacherAgestr = Console.ReadLine();

            int teacherAge;

            bool isCorrectTeacherAge = int.TryParse(teacherAgestr, out teacherAge);

            if (isCorrectTeacherAge)
            {

                try
                {
                    Teacher teacher = new Teacher
                    {
                        Name = teacherName,

                        Surname = teacherSurname,

                        Address = teacherAddress,

                        Age = teacherAge

                    };

                    var response = _teacherService.Create(teacher);


                    ConsoleColor.Green.WriteConsole($"Id: {response.Id} {response.Name} {response.Surname} {response.Age} {response.Address}");


                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Plase try again");
                    goto TeacherName;
                }


            }
            else
            {

                ConsoleColor.Red.WriteConsole("Please add correct format teacher age");
                goto TeacherAge;
            }






        }

        public void GetAll()
        {
            var result = _teacherService.GetAll();

            if (result.Count == 0)
            {
                ConsoleColor.Red.WriteConsole("Data not found");
            }
            else
            {
                foreach (var item in result)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname} Age:{item.Age} {item.Address}");
                }
            }
        }


        public void Delete()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id for delete:");
          TeacherId : string teacherId = Console.ReadLine();

            int id;

            bool isCorrectId = int.TryParse(teacherId, out id);

            if (isCorrectId)
            {
                try
                {
                    _teacherService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Successfully deleted");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher id again");
                    goto TeacherId;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add correct format teacher id");
                goto TeacherId;
            }
        }


        public void SerachTeacher()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add search text:");
            SearchText: string searchText = Console.ReadLine();

            if (searchText == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty search text");
                goto SearchText;
            }

            try
            {
                var response = _teacherService.Search(searchText);

                foreach (var item in response)
                {
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname}");
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add search text again");
                goto SearchText;
            }
        }

       
        public void GetById()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id :");
            TeacherId: string teacherId = Console.ReadLine();

            int id;
            bool isCorrectId = int.TryParse(teacherId, out id);

            if (isCorrectId)
            {
                try
                {
                    var response = _teacherService.GetById(id);
                    
            
                        ConsoleColor.Green.WriteConsole($"Id: {response.Id}, Name: {response.Name}, Surname: {response.Surname} Age:{response.Age} {response.Address}");
                    
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher id again");
                    goto TeacherId;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add correct format teacher id");
                goto TeacherId;
            }

            
        }
       

    }
}


