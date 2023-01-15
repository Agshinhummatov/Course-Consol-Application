using DomianLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Helpers.Constants;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CourseApplication.Controllers
{
    public class GroupController 
    {

        private readonly IGroupService _groupService;
        public GroupController()
        {
            _groupService = new GroupService();

        }

        string pattern = "^(?!\\s+$)['.-]+$";
        string msg = "/Plase enter agin";


        public void Create()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add group name");       //Namede go to etmir
            GroupName: string groupName = Console.ReadLine();
            try
            {
                if (String.IsNullOrWhiteSpace(groupName))
                {
                    ConsoleColor.Red.WriteConsole(ResponseMessages.StringMessage + msg);
                }
                else if (Regex.IsMatch(groupName, pattern))
                {
                    Console.WriteLine(ResponseMessages.StringCharacterMessage + msg);
                    goto GroupName;
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto GroupName;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add group capacity");
            Capacity: string capacityStr = Console.ReadLine();
            int capacity;
            bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);
            if (!isCorrectCapacity && capacity < 0)
            {
                ConsoleColor.Red.WriteConsole("Plase, enter teacher id for group");
                goto Capacity;
            }
            else if (capacity >= 30)
            {
                ConsoleColor.Red.WriteConsole("Can not be greater than 30");
                goto Capacity;

            }


            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id");
            GroupIdStr : string idStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);

            if(idStr == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Plase, enter correct id");
            }
            if (isCorrectId || id < 0)
            {

                try
                {
                    DomianLayer.Entities.Group group = new DomianLayer.Entities.Group
                    {

                        Name = groupName,
                        Capacity = capacity,
                        CreateDate = DateTime.Now
                    };
                    _groupService.Create(group, id);
                    ConsoleColor.Green.WriteConsole
                    (
                        $"id: {group.Id}, Name: {group.Name} Capacity : {group.Capacity}," +
                        $" Creat data {group.CreateDate.ToString("yyyy,MM,dd")}," +
                        $" Teacher:{group.Teacher.Id},{group.Teacher.Name} {group.Teacher.Surname}," +
                        $"{group.Teacher.Age},{group.Teacher.Address}"
                    );

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto GroupName;
                }



            }
            else
            {
                ConsoleColor.Red.WriteConsole("Plase, enter format id" + msg);
                goto GroupIdStr;

            }




        }




        public void Delete()
        {

           ConsoleColor.DarkCyan.WriteConsole("Please add teacher id for delete:");
           GroupId: string groupId = Console.ReadLine();

            int id;

            bool isCorrectId = int.TryParse(groupId, out id);

            if (isCorrectId && id > 0)
            {
                try
                {
                    _groupService.Delete(id);
                    ConsoleColor.Green.WriteConsole("Successfully deleted");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add teacher id again");
                    goto GroupId;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add correct format teacher id");
                goto GroupId;
            }

        }




        public void GetGroupsByCapity()
        {

            ConsoleColor.DarkCyan.WriteConsole("Please add group capacity");
            Capacity: string capacityStr = Console.ReadLine();
            int capacity;
            bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);
            if (isCorrectCapacity)
            {

                try
                {
                    var group = _groupService.GetGroupsByCapity(capacity);

                    foreach (var item in group)
                    {

                        ConsoleColor.Green.WriteConsole($" Id: {item.Id},Name : {item.Name},Capacity : {item.Capacity} ");
                    }
                    
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Capacity;
                }

            }


        }


        public void GetGroupsCount()
        {
            var result = _groupService.GetGroupsCount();
            ConsoleColor.Green.WriteConsole($" All group count : {result}");
        }


        public void GetGroupsByTeacherId()
        {

            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id");
            Id: string teacherIdStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(teacherIdStr, out id);
            if (isCorrectId && id > 0)
            {

                try
                {

                    var groups = _groupService.GetGroupsByTeacherId(id);

                    foreach (DomianLayer.Entities.Group group in groups)
                    {
                        ConsoleColor.Green.WriteConsole
                         (
                         $"id: {group.Id}, Name: {group.Name} Capacity : {group.Capacity}," +
                         $" Creat data {group.CreateDate.ToString("yyyy,MM,dd")}," +
                         $" Teacher:{group.Teacher.Id},{group.Teacher.Name} {group.Teacher.Surname}," +
                         $"{group.Teacher.Age},{group.Teacher.Address}"
                         );
                    }


                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            }
        }

        public void GetAllGroupsByTeacherName()                             // adi kicik ile olani tapmir
        {

            ConsoleColor.DarkCyan.WriteConsole("Please add groups teacher name:");
            SearhcName : string teacherName = Console.ReadLine();

            if (teacherName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Plase, add correct format teacher name");
            }
            else
            {


                try
                {

                    var groups = _groupService.GetGroupsByTeacherName(teacherName);            // getallgropsbyteachername elemelisen

                    foreach (var group in groups)
                    {
                        ConsoleColor.Green.WriteConsole
                         (
                         $"id: {group.Id}, Name: {group.Name} Capacity : {group.Capacity}," +
                         $" Creat data {group.CreateDate.ToString("yyyy,MM,dd")}," +
                         $" Teacher:{group.Teacher.Id},{group.Teacher.Name} {group.Teacher.Surname}," +
                         $"{group.Teacher.Age},{group.Teacher.Address}"
                         );
                    }


                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto SearhcName;
                }

            }
            

        }         



        public void SearchByName()                                          //Searchin adini servide deyis
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
                var response = _groupService.Search(searchText);
                foreach (var group in response)
                {
                    ConsoleColor.Green.WriteConsole
                          (
                          $"id: {group.Id}, Name: {group.Name} Capacity : {group.Capacity}," +
                          $" Creat data {group.CreateDate.ToString("yyyy,MM,dd")}," +
                          $" Teacher:{group.Teacher.Id},{group.Teacher.Name} {group.Teacher.Surname}," +
                          $"{group.Teacher.Age},{group.Teacher.Address}"
                          );
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add search text again");
                goto SearchText;
            }
        }


        public void GetGroupById()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add serach geoup id:");
            GroupId: string groupId = Console.ReadLine();

            int id;
            bool isCorrectId = int.TryParse(groupId, out id);

            if (isCorrectId)
            {
                try
                {
                    var response = _groupService.GetGroupById(id);


                    ConsoleColor.Green.WriteConsole($"Id: {response.Id}, Name: {response.Name},{response.Capacity}");

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add group id again");
                    goto GroupId;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add correct format group id");
                goto GroupId;
            }

        }

    }
}
