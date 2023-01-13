using DomianLayer.Common;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Group entity)
        {
            throw new NotImplementedException();
        }

        public Group Get(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        //public void Update(Group entity)
        //{
        //    throw new NotImplementedException();
        //}

        bool IRepository<Group>.Update(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
