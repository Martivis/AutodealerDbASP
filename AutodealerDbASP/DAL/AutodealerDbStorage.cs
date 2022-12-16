using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutodealerDbASP.Models.AutodealerDb.Entities;

namespace AutodealerDbWF
{
    public class AutodealerDbStorage
    {
        public AutodealerDbStorage(AutodealerDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }
        
        public IQueryable<T> GetAll<T>() where T : class
        {
            return _db.Set<T>();
        }

        public IQueryable<Model> GetAllModelsFull()
        {
            return _db.Set<Model>()
                .Include("CarColor")
                .Include("CarBrand");
        }

        public IQueryable<Lot> GetAvalableLotsWithModel()
        {
            return _db.Set<Lot>()
                .Include("Model")
                .Include("Model.CarColor")
                .Include("Model.CarBrand")
                .Include("ClientDeals")
                .Where(x => x.ClientDeals.Count == 0);
        }

        public IQueryable<Lot> GetAllLotsFull()
        {
            return _db.Set<Lot>()
                .Include("Model")
                .Include("Model.CarColor")
                .Include("Model.CarBrand")
				.Include("ClientDeals")
				.Include("Provider");
        }

        public IQueryable<ClientDeal> GetAllClientDealsFull()
        {
            return _db.Set<ClientDeal>()
                .Include("Lot")
                .Include("Client")
                .Include("Lot.Model")
                .Include("Lot.Model.CarBrand")
				.Include("Lot.Model.CarColor");
        }

        public T Get<T>(int id) where T : class
        {
            return _db.Set<T>().Find(id);
        }
        
        public Model GetModelFull(int id)
        {
            return _db.Models
                .Include("CarColor")
                .Include("CarBrand")
                .First(x => x.ModelId == id);
        }

        public Lot GetLotFull(int id)
        {
            return _db.Lots
				.Include("Model")
				.Include("Model.CarColor")
				.Include("Model.CarBrand")
				.Include("ClientDeals")
				.Include("Provider")
				.First(x => x.LotId == id);
        }
        
        public ClientDeal GetClientDealFull(int id)
        {
            return _db.ClientDeals
                .Include("Lot")
                .Include("Lot.Client")
                .Include("Lot.Model")
                .Include("Lot.Model.CarColor")
                .Include("Lot.Model.CarBrand")
                .First(x => x.ClientDealId == id);
        }

        public void Update<T>(T entity) where T : class
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        private AutodealerDbContext _db;
        
    }
}
