using Microsoft.EntityFrameworkCore;
using Persons_Handbook_API.Database;
using Persons_Handbook_API.Models;

namespace Persons_Handbook_API.Repository
{
    public class GenericRepository<T> where T : class
    {
        private AppDBContext _dbContext;
        private DbSet<T> _dbSet;

        public GenericRepository(AppDBContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(T obj)
        {
            _dbSet.Add(obj);
        }

        public virtual void Update(T obj)
        {
            _dbSet.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;

        }

        public virtual void Delete(object id)
        {
            T data = _dbSet.Find(id);
            _dbSet.Remove(data);
        }

        public virtual void UploadPhoto(Photos photo)
        {
            if (photo.PhotoLocation != null)
            {
                string path = "\\Uploads\\";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (FileStream fs = File.Create(path))
                {
                    photo.PhotoLocation = fs.
                }
            }
        }
    }
}
