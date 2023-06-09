﻿using CI_API.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CI_API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CI_API.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CiApiContext _db;
        private DbSet<T> dbSet;
        public GenericRepository(CiApiContext db)
        {
            _db=db;
            this.dbSet = _db.Set<T>();
        }
        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            
        }
    }
}
