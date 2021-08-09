using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ProEventosContext context;

        public GeralPersist(ProEventosContext _context)
        {
            context = _context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity); 
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
