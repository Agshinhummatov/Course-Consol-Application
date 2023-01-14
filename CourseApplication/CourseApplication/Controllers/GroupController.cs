﻿using DomianLayer.Entities;
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
        string msg =  "/Plase enter agin";


        public void Create()
        {
            ConsoleColor.DarkCyan.WriteConsole("Please add group name");
           GroupName: string groupName = Console.ReadLine();
            try
            {
                if (String.IsNullOrWhiteSpace(groupName))
                {
                    ConsoleColor.Red.WriteConsole(ResponseMessages.StringMessage + msg );
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
            if (!isCorrectCapacity && capacity < 0 )
            {
                ConsoleColor.Red.WriteConsole("Plase, enter teacher id for group");
                goto Capacity;
            }
            else if(capacity >= 30 )
            {
                ConsoleColor.Red.WriteConsole("Can not be greater than 30");
                goto Capacity;
                
            }

            
            ConsoleColor.DarkCyan.WriteConsole("Please add teacher id");
            Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);
            if (isCorrectId || id < 0)
            {

                try
                {
                    DomianLayer.Entities.Group group = new DomianLayer.Entities.Group
                    {

                        Name= groupName,
                        Capacity= capacity,
                        CreateDate =DateTime.Now
                    };
                    _groupService.Create(group,id);
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
                    goto Id;
                }

            }


  

        }


    }

}
