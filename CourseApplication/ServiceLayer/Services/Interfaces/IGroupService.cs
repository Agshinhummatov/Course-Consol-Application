using DomianLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IGroupService
    {

        Group Create(Group group, int? teacherId);

        void Delete(int? id);
        Group GetGroupById(int? id);
        List<Group>  SearchGroupByName(string searchText);

        Group Update(int? id, Group group);

        List<Group> GetGroupsByCapacity(int? Id);
        List<Group> GetGroupsByTeacherName(string name);

        List<Group> GetGroupsByTeacherId(int? teacherId);

        public int GetGroupsCount();



    }
}
