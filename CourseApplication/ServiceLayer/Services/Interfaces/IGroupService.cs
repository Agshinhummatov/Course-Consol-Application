using DomianLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IGroupService
    {

        Group Create(Group group);

        public void Delete(int? id);
        Group GetById(int id);
        List<Group> Search(string searchText);

        List<Group> GetAll();
        Group Update(int id, Teacher group);
    }
}
