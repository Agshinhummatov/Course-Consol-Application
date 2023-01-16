using DomianLayer.Entities;
using RepositoryLayer.Repositories;
using ServiceLayer.Exceptions;
using ServiceLayer.Helpers.Constants;
using ServiceLayer.Services.Interfaces;

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
            if (id is null) throw new ArgumentNullException();

            Teacher dbTeacher = _repo.Get(m => m.Id == id);

            if (dbTeacher == null) throw new NullReferenceException("Data notfound");

            _repo.Delete(dbTeacher);

        }

        public List<Teacher> GetAll()
        {
            return _repo.GetAll();
        }

        public Teacher GetById(int? id)
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

        public Teacher Update(int? id, Teacher teacher)
        {
            if (id == null) throw new ArgumentNullException();
            if (teacher == null) throw new ArgumentNullException();
            Teacher result = GetById(id);

            if (result != null)
            {
                if (teacher.Name != string.Empty && teacher.Name != null)
                    result.Name = teacher.Name;
                if (teacher.Surname != string.Empty && teacher.Surname != null)
                    result.Surname = teacher.Surname;
                if (teacher.Address != string.Empty && teacher.Address != null)
                    result.Address = result.Address;
                if (teacher.Age != null && teacher.Age != 0)
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
