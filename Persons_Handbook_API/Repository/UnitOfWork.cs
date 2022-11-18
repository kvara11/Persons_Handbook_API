using Persons_Handbook_API.Database;
using Persons_Handbook_API.Models;

namespace Persons_Handbook_API.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AppDBContext _dbContext = new AppDBContext();
        private GenericRepository<Persons> _personsRepo;
        private bool disposed = false;
        public GenericRepository<Persons> PersonsRepository
        {
            get
            {
                if (_personsRepo == null)
                {
                    _personsRepo = new GenericRepository<Persons>(_dbContext);
                }
                return _personsRepo;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Disposed(bool disp)
        {
            if (!disposed)
            {
                if (disp)
                {
                    _dbContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}
