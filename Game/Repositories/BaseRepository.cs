﻿using Game.Data;
using Microsoft.EntityFrameworkCore;

namespace Game.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DataContext _context;

        protected BaseRepository()
        {
            _context = new DataContext();
        }
        public IQueryable<T> GetAll()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }

        public async Task<T?> GetByIntId(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
        public async Task Add(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding entity: {ex.Message}", ex);
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating entity: {ex.Message}", ex);
            }
        }
        public async Task Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error remove entity: {ex.Message}", ex);
            }
        }
    }
}
