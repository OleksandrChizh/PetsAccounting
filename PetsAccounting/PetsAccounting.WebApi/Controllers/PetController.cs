using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

using PetsAccounting.BLL.Dto;
using PetsAccounting.BLL.Interfaces;
using PetsAccounting.BLL.Utils;

namespace PetsAccounting.WebApi.Controllers
{
    public class PetController : ApiController
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        [Route("api/owner/{ownerId}/pet")]
        public async Task<IEnumerable<PetDto>> Get(int ownerId, int pageNumber = 1, int pageSize = int.MaxValue)
        {
            var filterInfo = new FilterInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return await _petService.GetFilteredAsync(ownerId, filterInfo);
        }

        [HttpGet]
        [Route("api/owner/{ownerId}/pet/count")]
        public async Task<int> GetCount(int ownerId)
        {
            return await _petService.GetCountAsync(ownerId);
        }

        [HttpPost]
        [Route("api/owner/{ownerId}/pet")]
        public async Task<int> Post([FromUri] int ownerId, PetDto pet)
        {
            var id = await _petService.CreateAsync(ownerId, pet.Name);

            return id;
        }

        [HttpDelete]
        [Route("api/pet/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _petService.DeleteAsync(id);

            return Ok();
        }
    }
}