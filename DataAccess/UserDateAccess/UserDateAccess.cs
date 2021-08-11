using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.UserDateAccess
{
    public class UserDateAccess : IUserDateAccess
    {
        private TestTaskABContext db;
        public IEnumerable<EntityEntry> el;
        public UserDateAccess(TestTaskABContext testTaskABContext)
        {
            db = testTaskABContext;
            db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        public void CreateAll(IEnumerable<UserDate> userDates)
        {
            el = db.ChangeTracker.Entries();
            db.UserDates.AddRange(userDates);
            
            
        }

        public void UpdateAll(IEnumerable<UserDate> userDates)
        {
            el = db.ChangeTracker.Entries();
            db.UserDates.UpdateRange(userDates);
            el = db.ChangeTracker.Entries();

        }

        public async Task<IEnumerable<UserDate>> GetAllAsync()
        {
            return await db.UserDates.AsNoTracking().ToListAsync();
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            el = db.ChangeTracker.Entries();
            db.SaveChanges();
            el = db.ChangeTracker.Entries();
        }
    }
}
