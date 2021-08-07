using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IUserDateService
    {
        void MakeListUserDate(IEnumerable<UserDateDTO> userDateDTOs);
        void UpdateListUserDate(IEnumerable<UserDateDTO> userDateDTOs);
        Task<IEnumerable<UserDateDTO>> GetListUserDateAsync();
        void Dispose();
    }
}
