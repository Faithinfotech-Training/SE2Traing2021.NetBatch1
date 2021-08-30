using CRM_Demo.Models;
using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly CRMdbContext _crmdbContext;
        private DbSet<T> entities;


        public Repository(CRMdbContext CRMdbContext)
        {
            _crmdbContext = CRMdbContext;
            entities = _crmdbContext.Set<T>();
        }
        public T Get(int id)
        {
            return entities.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("Null Entity");
            }
            entities.Add(entity);
            _crmdbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("Null Entity");
            }
            entities.Remove(entity);

        }

        public void SaveChanges()
        {
            _crmdbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("Null Entity");
            }
            entities.Update(entity);
            _crmdbContext.SaveChanges();
        }
    }
}
