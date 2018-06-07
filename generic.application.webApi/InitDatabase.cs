using System;
using System.Linq;
using generic.application.domain.entities;
using generic.application.repository.context;

namespace generic.application.webApi
{
    public class InitDatabase
    {
        public static void initDb(GenericContext _context)
        {
            _context.Database.EnsureCreated();
            if(_context.Users.Any()) {
                return;
            }

            var user = new User("Bruno Afonso", Convert.ToDateTime("25/04/1995"));
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}