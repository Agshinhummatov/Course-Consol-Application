using DomianLayer.Entities;
using RepositoryLayer.Repositories;
using ServiceLayer.Exceptions;
using ServiceLayer.Helpers.Constants;
using ServiceLayer.Services.Interfaces;
using Group = DomianLayer.Entities.Group;

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

        

        public Group Create(Group group, int? teacherId)
        {
            group.Id = _count;
            Teacher teacher = _teacher.Get(m => m.Id == teacherId);
            group.Teacher = teacher;
            if (teacher is null) throw new Exception(ResponseMessages.NotFound);
            _repo.Create(group);
            _count++;
            return group;
        }

        public void Delete(int? id)
        {
            if (id is null) throw new NotFoundException(ResponseMessages.NotFound);
            Group dbGroup = _repo.Get(m => m.Id == id);
            if (dbGroup == null) throw new NotFoundException(ResponseMessages.NotFound);
            _repo.Delete(dbGroup);
        }

        public Group GetGroupById(int? id)
        {
            Group group = _repo.Get(m => m.Id == id);
            return group;
        }

        public List<Group> GetGroupsByCapity(int? capacity)
        {
            if (capacity == null) throw new NotFoundException(ResponseMessages.NotFound);
            List<Group> dbGroups = _repo.GetAll(m => m.Capacity == capacity);
            if (dbGroups.Count == 0) throw new NotFoundException(ResponseMessages.NotFound);
            return dbGroups;
        }

        public List<Group> GetGroupsByTeacherId(int? teacherId)
        {
            if (teacherId == null) throw new NotFoundException(ResponseMessages.NotFound);
            List<Group> dbGroup = _repo.GetAll(m => m.Teacher.Id == teacherId);
            if (dbGroup.Count == 0) throw new NotFoundException(ResponseMessages.NotFound);
            return dbGroup;
        }

        public List<Group> GetGroupsByTeacherName(string teacherName)
        {
            if (teacherName is null) throw new NotFoundException(ResponseMessages.NotFound);
            List<Group> dbGroups = _repo.GetAll(m => m.Teacher.Name.Trim().ToLower() == teacherName.Trim().ToLower());
            //List<Group> dbGroup = _repo.GetAll(m => m.Name.Trim().ToLower().Contains(teacherName.Trim().ToLower()));
            if (dbGroups.Count == 0) throw new NotFoundException(ResponseMessages.NotFound);
            return dbGroups;
        }

        public int GetGroupsCount()
        {
            return _repo.GetAll().Count;
        }

        public List<Group> SearchByName(string searchText)
        {
            //List<Group> group = _repo.GetAll(m => m.Name.Trim().ToLower().Contains(searchText.Trim().ToLower()));
            //List<Group> group = _repo.GetAll(m => m.Name.Trim().ToLower().Contains(searchText.Trim().ToLower()));
            List<Group> group = _repo.GetAll(m => m.Name.ToLower().Contains(searchText.ToLower()));
            if (group.Count == 0) throw new NotFoundException(ResponseMessages.NotFound);
            return group;
        }

        public Group Update(int? id, Group group)
        {
            throw new NotImplementedException();
        }

    }
}
