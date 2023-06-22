using HotelManagement.Infrastructure.Interfaces;
using HotelManagement_data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly AppDbContext context;
        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            return entity;
        }


        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            context.Set<T>().Update(entity);

            return entity;
        }
    }
}
