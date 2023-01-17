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

        string pattern = @"^[a-zA-Z]+$";
        string msg = "/Plase enter agin";
        string pattren2 = @"^\w+$";

        public void Create()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add group name");       
            GroupName: string groupName = Console.ReadLine();
            if (groupName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty group name");
                goto GroupName;
            }
            else if (!Regex.IsMatch(groupName, pattren2))
            {
                ConsoleColor.Red.WriteConsole("Cannot be a symbol. Plase try again");
                goto GroupName;
            }

            ConsoleColor.DarkCyan.WriteConsole("Please add group capacity");
            Capacity: string capacityStr = Console.ReadLine();
            int capacity;
            bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);
            if(capacityStr == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty group capacity");
                goto Capacity;
            }
            if (!isCorrectCapacity || capacity < 1)
            {
                ConsoleColor.Red.WriteConsole("Plase, enter correct capacity for group");      
                goto Capacity;
            }
            else if (capacity >= 30 )
            {
                ConsoleColor.Red.WriteConsole("Can not be greater than 30 ");
                goto Capacity;

            }
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id");
            GroupIdStr : string idStr = Console.ReadLine();


            int id;
            bool isCorrectId = int.TryParse(idStr, out id);

           
            if (isCorrectId && id > 0)
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
                        $"Group Id: {group.Id}, Group name: {group.Name} Group capacity: {group.Capacity}," +
                        $" Creat data {group.CreateDate.ToString("yyyy,MM,dd")}," +
                        $" Teacher id: {group.Teacher.Id}, Teacher name: {group.Teacher.Name}  Teacher surname: {group.Teacher.Surname}," +
                        $" Teacher age : {group.Teacher.Age}, Teacher Address: {group.Teacher.Address}"
                    );

                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto GroupIdStr;
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




        public void GetGroupsByCapacity()
        {

            ConsoleColor.DarkCyan.WriteConsole("Please add group capacity");
            Capacity: string capacityStr = Console.ReadLine();

            if (capacityStr == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Plase, dont empty capacity");
                goto Capacity;
            }
            int capacity;
            bool isCorrectCapacity = int.TryParse(capacityStr, out capacity);
            if (isCorrectCapacity && capacity > 0 && capacity < 30 )
            {

                try
                {
                    var group = _groupService.GetGroupsByCapacity(capacity);

                    foreach (var item in group)
                    {

                        ConsoleColor.Green.WriteConsole($" Id: {item.Id}, Name : {item.Name}, Capacity : {item.Capacity} ");
                    }
                    
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Please add different capacity");
                    goto Capacity;
                }

            }
            else 
            {
                ConsoleColor.Red.WriteConsole("Plase correct format  capacity");
                goto Capacity;
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

            if (teacherIdStr == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Plase, dont empty teacher id ");
                goto Id;
            }
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
                           $"Group Id: {group.Id}, Group name: {group.Name} Group capacity: {group.Capacity}," +
                           $" Creat data {group.CreateDate.ToString("yyyy,MM,dd")}," +
                           $" Teacher id: {group.Teacher.Id}, Teacher name: {group.Teacher.Name}  Teacher surname: {group.Teacher.Surname}," +
                           $" Teacher age : {group.Teacher.Age}, Teacher Address: {group.Teacher.Address}"
                         );
                    }


                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Plase correct format id");
                goto Id;
            }
        }

        public void GetAllGroupsByTeacherName()                            
        {  
            

            ConsoleColor.DarkCyan.WriteConsole("Please add groups teacher name:");
            TeacherName: string teacherName = Console.ReadLine().Trim();

            if (teacherName == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Plase dont empty teacher name");
                goto TeacherName;
            }
            else if (!Regex.IsMatch(teacherName, pattern))
            {
                ConsoleColor.Red.WriteConsole("Cannot be a symbol. Plase try again");
                goto TeacherName;
            }

            
            {


                try
                {

                    var groups = _groupService.GetGroupsByTeacherName(teacherName);            

                    foreach (var group in groups)
                    {
                        ConsoleColor.Green.WriteConsole
                         (
                         $"id: {group.Id}, Name: {group.Name} Capacity : {group.Capacity}," +
                         $" Creat data {group.CreateDate.ToString("yyyy,MM,dd")}," +
                         $" Teacher id:{group.Teacher.Id}, Teacher name : {group.Teacher.Name}, Teacher surname: {group.Teacher.Surname}," +
                         $" Teacher age : {group.Teacher.Age}, Teacher Address {group.Teacher.Address}"
                         );
                    }


                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto TeacherName;
                }

            }
            

        }         



        public void SearchGroupByName()                                          
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add search text:");
         SearchText: string searchText = Console.ReadLine().Trim(); 

            if (searchText == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty search text");
                goto SearchText;
            }

            try
            {
                var response = _groupService.SearchGroupByName(searchText);
                foreach (var group in response)
                {
                    ConsoleColor.Green.WriteConsole
                          (
                          $"id: {group.Id}, Name: {group.Name} Capacity : {group.Capacity}," +
                          $" Creat data:{group.CreateDate.ToString("yyyy,MM,dd")}," +
                          $" Teacher:{group.Teacher.Id}, Teacher name {group.Teacher.Name}, Teacher surname : {group.Teacher.Surname}," +
                          $" Teacher age:{group.Teacher.Age}, Teacher Address : {group.Teacher.Address}"
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
            if (groupId == string.Empty)
            {
                ConsoleColor.Red.WriteConsole("Please dont empty group id");
                goto GroupId;
            }
            int id;
            bool isCorrectId = int.TryParse(groupId, out id);

            if (isCorrectId)
            {
                try
                {
                    var response = _groupService.GetGroupById(id);


                    ConsoleColor.Green.WriteConsole($"Id: {response.Id}, Name: {response.Name}, Capacity :{response.Capacity}");

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
