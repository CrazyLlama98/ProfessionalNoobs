﻿using Symbiose.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Symbiose.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Symbiose.Services
{
    public class GenericDbService : IGenericDbService
    {
        public DbContext Context { get; set; }

        public GenericDbService(DbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : Entity
        {
            return await Context.Set<T>().ToListAsync();
        }

        public IQueryable<T> Set<T>() where T : Entity
        {
            return Context.Set<T>();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : Entity
        {
            return await Context.Set<T>().FindAsync(id);
        }
    }
}