

using CourseApplication.Controllers;
using ServiceLayer.Helpers;

TeacherController teacherController = new();


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
            case 1:
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
    ConsoleColor.Cyan.WriteConsole("Teacher options : 1 - Create, 2 - Get all, 3 - Delete, 4 - Search teacher");
}
