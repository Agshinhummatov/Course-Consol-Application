using DomianLayer.Entities;
using RepositoryLayer.Repositories;
using ServiceLayer.Helpers.Constants;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class GroupService : IGroupService
    {
        private readonly GroupRepository _repo;
        private readonly TeacherRepository _teacher;
        public GroupService()
        {
            _repo=new GroupRepository();
            _teacher = new TeacherRepository();
        }

        private int _count = 1;

        public Group Create(Group group, int teacherId)
        {
            group.Id = _count;
            Teacher teacher =_teacher.Get(m=>m.Id == teacherId);
            group.Teacher = teacher;
            if (teacher is null) throw new Exception(ResponseMessages.NotFound); 
            _repo.Create(group);
            _count++;
            return group;
        }

        public void Delete(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            Group dbGroup = _repo.Get(m => m.Id == id);

            if (dbGroup == null) throw new NullReferenceException("Data notfound");

            _repo.Delete(dbGroup);
        }

        public Group GetGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupsByCapity(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupsByTeacherId(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupsByTeacherName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetGroupsCount()
        {
            throw new NotImplementedException();
        }

        public List<Group> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
