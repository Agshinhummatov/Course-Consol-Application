

using CourseApplication.Controllers;
using ServiceLayer.Helpers;
using ServiceLayer.Helpers.Enums;

TeacherController teacherController = new();

GroupController groupController = new();

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
            case 2:
                teacherController.GetAll(); 
                break;
            case 3:
                teacherController.Delete();
                break;
            case 4:
                teacherController.SerachTeacher();
                break;
            case 5:
                teacherController.GetById();
                break;
            case 6:
                teacherController.Update();
                break;
            case 7:

                groupController.Create();
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
    ConsoleColor.Cyan.WriteConsole("Teacher options : \n 1 -  Create Teacher, \n 2 - Get all teachers, \n 3 - Delete Teacher, \n 4 - Search teacher,\n 5 - Get teacher by id, \n 6 - Update");
}
