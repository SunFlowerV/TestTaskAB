using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserDateAccess
{
    public interface IUserDateAccess
    {
        Task<IEnumerable<UserDate>> GetAllAsync();
        void CreateAll(IEnumerable<UserDate> userDates);
        void UpdateAll(IEnumerable<UserDate> userDates);
        void Save();
        void Dispose();
    }
}
