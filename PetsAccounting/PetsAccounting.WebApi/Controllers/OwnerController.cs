using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

using PetsAccounting.BLL.Dto;
using PetsAccounting.BLL.Interfaces;
using PetsAccounting.BLL.Utils;

namespace PetsAccounting.WebApi.Controllers
{
    public class OwnerController : ApiController
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        [Route("api/owner")]
        public async Task<IEnumerable<OwnerDto>> Get(int pageNumber = 1, int pageSize = int.MaxValue)
        {
            var filterInfo = new FilterInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return await _ownerService.GetFilteredAsync(filterInfo);
        }

        [HttpGet]
        [Route("api/owner/count")]
        public async Task<int> GetCount()
        {
            return await _ownerService.GetCountAsync();
        }

        [HttpPost]
        [Route("api/owner")]
        public async Task<int> Post([FromBody] OwnerDto owner)
        {
            var id = await _ownerService.CreateAsync(owner.Name);

            return id;
        }

        [HttpDelete]
        [Route("api/owner/{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _ownerService.DeleteAsync(id);

            return Ok();
        }
    }
}