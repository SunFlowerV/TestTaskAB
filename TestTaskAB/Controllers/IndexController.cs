using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.DTO;
using Service.Services;

namespace TestTaskAB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndexController : ControllerBase
    {
        private IUserDateService uds;
        public IndexController(IUserDateService userDateService)
        {
            uds = userDateService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDateDTO>>> Get()
        {
            IEnumerable<UserDateDTO> userDateDTOs = await uds.GetListUserDateAsync();
            if(userDateDTOs == null)
            {
                
                return NotFound();
            }
            
            return new ObjectResult(userDateDTOs);
        }
        [HttpPost]
        public async Task<ActionResult> Create(IEnumerable<UserDateDTO> userDateDTOs)
        {
            if (userDateDTOs == null)
            {
                return BadRequest();
            }
            IEnumerable<UserDateDTO> oldUserDateDTOs = await uds.GetListUserDateAsync();
            List<UserDateDTO> updateUserDateDTOs = new List<UserDateDTO>();
            for (int i = 0; i < oldUserDateDTOs.Count(); i++)
            {
                updateUserDateDTOs.Add(userDateDTOs.ElementAt(i));
            }
            List<UserDateDTO> saveUserDateDTOs = new List<UserDateDTO>();
            for (int i = oldUserDateDTOs.Count(); i < userDateDTOs.Count(); i++)
            {
                saveUserDateDTOs.Add(userDateDTOs.ElementAt(i));
                
            }
            foreach(var saveUserDateDTO in saveUserDateDTOs)
            {
                saveUserDateDTO.Id = 0;
            }
            uds.UpdateListUserDate(updateUserDateDTOs);
            if(saveUserDateDTOs.Count != 0)
            {
                uds.MakeListUserDate(saveUserDateDTOs);
            }
            
            
            return Ok(userDateDTOs);

        }
        //protected override void Dispose(bool disposing)
        //{
        //    uds.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
