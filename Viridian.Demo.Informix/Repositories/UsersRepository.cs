using System;
using System.Collections.Generic;
using System.Linq;
using Viridian.Demo.Informix.DataAccess;
using Viridian.Demo.Informix.Repositories.Interfaces;

namespace Viridian.Demo.Informix.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DemoContext _context;
        
        public UsersRepository(DemoContext context)
        {
            _context = context;
        }
        
        public List<Users> FindAll()
        {
            return (
                from users in _context.Users
                select users
            ).ToList();
        }

        public List<Users> FindByStatus(string status)
        {
            return (
                from users in _context.Users
                where users.Status == status
                select users
            ).ToList();
        }

        public Users Insert(Users model)
        {
            var entity = _context.Add(model);
            
            var returnCode = _context.SaveChanges();

            if (returnCode <= 0)
                throw new Exception("Insert failed");

            return entity.Entity;
        }

        public Users Update(Users model)
        {
            var entity = _context.Update(model);
            
            var returnCode = _context.SaveChanges();

            if (returnCode <= 0)
                throw new Exception("Update failed");

            return entity.Entity;
        }
    }
}