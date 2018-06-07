using System;
using System.Collections.Generic;
using System.Linq;
using generic.application.domain.contracts;
using generic.application.repository.context;
using Microsoft.EntityFrameworkCore;

namespace generic.application.repository.repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly GenericContext _context;
        public BaseRepository(GenericContext  context)
        {
            _context = context;
        }
        public int Delete(T data)
        {
            try 
            {
                _context.Set<T>().Update(data);
                return _context.SaveChanges();
            } 
            catch(Exception ex)
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
        }

        public int Insert(T data)
        {
            try
            {
                _context.Set<T>().Add(data);
                return _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
        }

        public IEnumerable<T> ListAll(string[] includes = null)
        {
            try
            {
                var query = _context.Set<T>().AsQueryable();
                if(includes == null) return query.ToList();

                foreach(var include in includes)
                {
                    query = query.Include(include);
                } 

                return query.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
        }

        public T searchById(int Id, string[] includes = null)
        {
            try
            {
                var primaryKey = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];
                var query = _context.Set<T>().AsQueryable();

                if(includes == null) return query.FirstOrDefault(e => EF.Property<int> (e, primaryKey.Name) == Id);

                foreach(var include in includes)
                {
                    query = query.Include(include);
                }

                return query.FirstOrDefault(e => EF.Property<int> (e, primaryKey.Name) == Id);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
        }

        public int Update(T data)
        {
            try 
            {
                _context.Set<T>().Update(data);
                return _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro Inesperado. " + ex.Message);
            }
        }
    }
}