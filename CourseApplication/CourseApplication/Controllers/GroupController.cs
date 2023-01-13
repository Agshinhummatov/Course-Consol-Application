using DomianLayer.Common;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = DomianLayer.Common.Group;

namespace CourseApplication.Controllers
{
    public class GroupController
    {
        private readonly IGroupService _groupService;
        public GroupController()
        {
            ConsoleColor.DarkGreen.WriteConsole("Please add group name :");
           GroupName: string groupName = Console.ReadLine();

            string pattern = @"^(?!\\s+$)[a-zA-Z,'. -]+$";


            if (groupName == string.Empty)
            {
                ConsoleColor.DarkGreen.WriteConsole("Please dont empty group name");
                goto GroupName;
            }
            else if (!Regex.IsMatch(groupName, pattern))
            {
                ConsoleColor.Red.WriteConsole("Cannot be a symbol. Plase try again");
                goto GroupName;
            }


            //DateTime dateTime= DateTime.Now;


            //bool dateTime = DateTime.TryParse(groupCapacitystr, out groupCapacity);

            ConsoleColor.Red.WriteConsole("Please add group capacity ");
            GroupCapacity: string groupCapacitystr = Console.ReadLine();

            int groupCapacity;

            bool isCorrectgroupCapacitystr = int.TryParse(groupCapacitystr, out groupCapacity);

            if (isCorrectgroupCapacitystr)
            {

                try
                {
                    Group group = new Group
                    {
                        Name = groupName,
                        Capacity = groupCapacity

                    };

                    var response = _groupService.Create(group);


                    ConsoleColor.Green.WriteConsole($" Id: {response.Id} {response.Name} {response.Capacity}");


                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message + "/" + "Plase try again");
                    goto GroupName;
                }


            }
            else
            {

                ConsoleColor.Red.WriteConsole("Please add correct format group capacity");
                goto GroupCapacity;
            }
        }
    }
}
