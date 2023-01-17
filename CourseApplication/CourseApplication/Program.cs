

using CourseApplication.Controllers;
using ServiceLayer.Helpers;
using ServiceLayer.Helpers.Enums;

TeacherController teacherController = new();
GroupController groupController= new();


while (true)
{
    GetOptions();

    Option: string option = Console.ReadLine();

    int selectOption;

    bool isCorrectOption = int.TryParse(option, out selectOption);

    if (isCorrectOption)
    {
        switch (selectOption)
        {
            
               case (int)Options.CreateTecher:
                teacherController.Create();
                break;
            case
                (int)Options.GetAllTeachers:
                teacherController.GetAll(); 
                break;
            case (int)Options.DeleteTeacher:
                teacherController.Delete();
                break;
            case (int)Options.SearchForTeacherNameAnSurname:
                teacherController.SerachTeacher();
                break;
            case (int)Options.GetTeacherById:
                teacherController.GetById();
                break;
            case (int)Options.UpDateTeacher:
                teacherController.Update();
                break;
            case (int)Options.CreateGroup:
                groupController.Create();
                break;
            case (int)Options.GetGroupsByCapacity:
                groupController.GetGroupsByCapacity();
                break;
            case (int)Options.DeleteGroup:
                groupController.Delete();
                break;
            case (int)Options.GetAllGroupsCount:
                groupController.GetGroupsCount();
                break;
            case (int)Options.GetGroupsByTeacherId:
                groupController.GetGroupsByTeacherId();
                break;
            case (int)Options.GetAllGroupsByTeacherName:
                groupController.GetAllGroupsByTeacherName();
                break;
            case (int)Options.SearchGroupByName:
                groupController.SearchGroupByName();
                break;
            case (int)Options.GetGroupById:
                groupController.GetGroupById();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Please add correct option");
                goto Option;

        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Please add correct format option");
        goto Option;

    }

}

static void GetOptions()
{
    ConsoleColor.Cyan.WriteConsole("Please select one option :");
    ConsoleColor.Cyan.WriteConsole("Teacher options : \n 1 - Create Teacher, \n 2 - Get all teachers, \n 3 - Delete Teacher, \n 4 - Search teacher,\n 5 - Get teacher by id, \n 6 - Update teacher \n Groups Options \n 7 - Create group, \n 8 - Get groups by capity  \n 9 - Group Delete  \n 10 - Groups count   \n 11 - Groups by teacher id   \n 12 - Get all groups by teacher name  \n 13 - Search group by name \n 14 - Get group by id \n 15 - Update group");
}
