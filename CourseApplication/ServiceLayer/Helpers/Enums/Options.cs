using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Enums
{
    public enum Options
    {
        CreateTecher = 1,
        UpDateTeacher,
        DeleteTeacher,
        GetTeacherById,
        GetAllTeacherById,
        SearchForTeacherNameAnSurname,
        CreateGroup,
        UpdateGroup,
        DeleteGroup,
        GetGroupById,
        GetGroupsByTeacherName,
        SearchForGroupByName,
        GetAllGroupsCount
    }
}
