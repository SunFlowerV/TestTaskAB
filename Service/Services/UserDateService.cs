using AutoMapper;
using DataAccess.Model;
using DataAccess.UserDateAccess;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserDateService : IUserDateService
    {
        private IUserDateAccess Database;

        public UserDateService()
        {
            Database = (IUserDateAccess)ServiceProviderFactorys.ServiceProvider.GetService(typeof(IUserDateAccess));
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<IEnumerable<UserDateDTO>> GetListUserDateAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDate, UserDateDTO>()).CreateMapper();
            IEnumerable<UserDate> userDates = await Database.GetAllAsync();
            return mapper.Map<IEnumerable<UserDate>, List<UserDateDTO>>(userDates);
        }

        public void MakeListUserDate(IEnumerable<UserDateDTO> userDateDTOs)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDateDTO, UserDate>()).CreateMapper();
            Database.CreateAll(mapper.Map <IEnumerable<UserDateDTO>, List<UserDate>>(userDateDTOs));
            Database.Save();
        }

        public void UpdateListUserDate(IEnumerable<UserDateDTO> userDateDTOs)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDateDTO, UserDate>()).CreateMapper();
            Database.UpdateAll(mapper.Map<IEnumerable<UserDateDTO>, List<UserDate>>(userDateDTOs));
            Database.Save();
        }
    }
}
