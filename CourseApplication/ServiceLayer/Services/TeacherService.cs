using DomianLayer.Common;
using RepositoryLayer.Repositories;
using ServiceLayer.Exceptions;
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
            Teacher teacher = _repo.Get(m => m.Id == id);
            return teacher;
        }

        public List<Teacher> Search(string searchText)
        {
            List<Teacher> teachers = _repo.GetAll(m => m.Name.ToLower().Contains(searchText.ToLower()) || m.Surname.ToLower().Contains(searchText.ToLower()));

            if (teachers.Count == 0) throw new NotFoundException(ResponseMessages.NotFound);

            return teachers;
        }

        public Teacher Update(int id, Teacher teacher)
        {
            if (id == null) throw new ArgumentNullException();
            if (teacher == null) throw new ArgumentNullException();
            var result = GetById(id);

            if (result != null)
            {
                teacher.Id = result.Id;
                if (teacher.Name == string.Empty)
                    teacher.Name = result.Name;
                    result.Name= teacher.Name;
                teacher.Name = result.Name;
                if (teacher.Surname == string.Empty)
                    teacher.Surname = result.Surname;
                result.Surname=teacher.Surname;
                if (teacher.Address == string.Empty)
                    teacher.Address = result.Address;
                     result.Name = teacher.Name;
                result.Address = result.Address;
                if (teacher.Age== null)
                 teacher.Age = result.Age;
                    result.Age = teacher.Age;
                
                _repo.Update(teacher);

            }
            else
            {
                throw new ArgumentNullException();
            }
            return teacher;
           


        }



    }
}
