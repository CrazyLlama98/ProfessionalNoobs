using Symbiose.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiose.Services.Interfaces
{
    interface IGenericDbService
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T : Entity;
        IQueryable<T> Set<T>() where T : Entity;
        Task<T> GetByIdAsync<T>(int id) where T : Entity;
    }
}
