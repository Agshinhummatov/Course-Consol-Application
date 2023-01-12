using DomianLayer.Common;
using RepositoryLayer.Repositories;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly TeacherRepository _repo;

        private int _count = 1;

        public TeacherService()
        {
            _repo = new TeacherRepository();
        }

        public Teacher Create(Teacher teacher)
        {
            
            teacher.Id = _count;
            Teacher existTeacher = _repo.Get(m=>m.Name.ToLower() == teacher.Name.ToLower());
            if (existTeacher != null) throw new Exception("Data already exist");

            _repo.Create(teacher);
            _count++;
            return teacher;
        }

        public void Delete(int? id)
        {
            if(id is null) throw new ArgumentNullException();

            Teacher dbTeacher = _repo.Get(m => m.Id == id);

            if (dbTeacher == null) throw new NullReferenceException("Data notfound");

            _repo.Delete(dbTeacher);
        
        }

        public List<Teacher> GetAll()
        {
            return _repo.GetAll();
        }

        public Teacher GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> Search(string searchText)
        {
            throw new NotImplementedException();
        }

        public Teacher Update(int id, Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
