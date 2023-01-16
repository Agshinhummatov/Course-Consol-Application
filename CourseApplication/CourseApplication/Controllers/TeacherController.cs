using DomianLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System.Text.RegularExpressions;

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
        TeacherName: string teacherName = Console.ReadLine().Trim();

            string pattern =  @"^[a-zA-z]+$";


            if (teacherName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty teacher name");
                goto TeacherName;
            }
            else if (!Regex.IsMatch(teacherName, pattern))
            {
                ConsoleColor.Red.WriteConsole("Cannot be a symbol. Plase try again");
                goto TeacherName;
            }

            ConsoleColor.DarkGreen.WriteConsole("Please add teacher surname ");
        TeacherSurname: string teacherSurname = Console.ReadLine().Trim();

            if (teacherSurname == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty teacher surname");
                goto TeacherSurname;
            }
            else if (!Regex.IsMatch(teacherSurname, pattern))
            {
                ConsoleColor.Red.WriteConsole("Cannot be a symbol. Plase try again");
                goto TeacherSurname;
            }

            ConsoleColor.DarkGreen.WriteConsole("Please add teacher adress ");
            TeacherAddress: string teacherAddress = Console.ReadLine();

            if (teacherAddress == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty teacher adress");
                goto TeacherAddress;
            }


            ConsoleColor.DarkGreen.WriteConsole("Please add teacher age ");
            TeacherAge: string teacherAgestr = Console.ReadLine();

            if (teacherAgestr == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty teacher age");
                goto TeacherAge;
            }

            int teacherAge;
            bool isCorrectTeacherAge = int.TryParse(teacherAgestr, out teacherAge);

            if (isCorrectTeacherAge && teacherAge > 0)
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


                    ConsoleColor.Green.WriteConsole($"Id: {response.Id} Name : {response.Name}  Surname : {response.Surname}  Age : {response.Age}  Address : {response.Address}");


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
                    ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Surname: {item.Surname} Age: {item.Age} Address: {item.Address}");
                }
            }
        }


        public void Delete()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id for delete:");
        TeacherId: string teacherId = Console.ReadLine();

            //if (teacherId == string.Empty)
            //{
            //    ConsoleColor.Red.WriteConsole("Please dont empty delete");
            //    goto teacherId;
            //}

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


        public void Update()
        {
        idInput:
            ConsoleColor.Cyan.WriteConsole("Please add teacher id");
            string IdTeach = Console.ReadLine();

            int id;
            bool isCorrectId = int.TryParse(IdTeach, out id);
            if (!isCorrectId)
            {
                ConsoleColor.Red.WriteConsole("Please add correct format teacher id:");
                goto idInput;
            }
            else
            {
                id = Convert.ToInt32(IdTeach);
            }

            string pattern2 = @"^[a-zA-z]+$";


            ConsoleColor.Cyan.WriteConsole("Please add teacher name");
        TeacherName: string teacherName = Console.ReadLine();
            try
            {
                //if (!Regex.IsMatch(teacherName, pattern2))
                //{
                //    ConsoleColor.Cyan.WriteConsole("Please add correct teacher name");
                //    goto TeacherName;
                //}
            }
            catch (Exception ex)
            {

                ConsoleColor.Cyan.WriteConsole(ex.Message);
            }
            ConsoleColor.Cyan.WriteConsole("Please add teacher Surname");
        TeacherSurname: string teacherSurname = Console.ReadLine();
            try
            {
                if (!Regex.IsMatch(teacherSurname, pattern2))
                {
                    ConsoleColor.Cyan.WriteConsole("Please add correct teacher Surname");
                    goto TeacherSurname;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Cyan.WriteConsole(ex.Message);
            }

            ConsoleColor.Cyan.WriteConsole("Please add teacher address");
        TeachAddress: string teachAddress = Console.ReadLine();
            try
            {
                //if (!Regex.IsMatch(teacherName, pattern2))
                //{
                //    ConsoleColor.Cyan.WriteConsole("Update correct teacher name");
                //    goto TeachAddress;
                //}
            }
            catch (Exception ex)
            {
                ConsoleColor.Cyan.WriteConsole(ex.Message);
            }

            ConsoleColor.Cyan.WriteConsole("Please add teacher age");
        TeacherAge: string teacherAgesStr = Console.ReadLine();

            int teacherAge;

            int.TryParse(teacherAgesStr, out teacherAge);

            try
            {

                //if (!Regex.IsMatch(IdTeach, pattern2))
                //{
                //    ConsoleColor.Cyan.WriteConsole("Please add correct Id");
                //    goto TeacherSurname;
                //}
                Teacher teacher = new Teacher()
                {
                    Name = teacherName,
                    Surname = teacherSurname,
                    Address = teachAddress,
                    Age = teacherAge

                };
                Teacher teacher1 = new();
                teacher1 = _teacherService.Update(id, teacher);

                ConsoleColor.Cyan.WriteConsole("Succesfully updated");
            }
            catch (Exception ex)
            {
                ConsoleColor.Cyan.WriteConsole(ex.Message);
            }


        }



    }
}


