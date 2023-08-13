using AutoMapper;
using Game.Models.RequestModels;
using Game.Models.ResponseModels;
using Game.Services;
using Microsoft.AspNetCore.Mvc;
using NhanVatGame.Models.ResponseModels;

namespace Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVatController : ControllerBase
    {
        private readonly INhanVatService _NhanVatService;
        private readonly IMapper _mapper;

        public NhanVatController(INhanVatService NhanVatService, IMapper mapper)
        {
            _NhanVatService = NhanVatService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetNhanVats()
        {
            var result = await _NhanVatService.GetNhanVats();
            if (result == null)
            {
                return NotFound("No NhanVat found");
            }
            return Ok(_mapper.Map<List<NhanVatResponse>>(result));
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetNhanVatById(string NhanVatId)
        {
            var result = await _NhanVatService.GetNhanVat(NhanVatId);
            if (result == null)
            {
                return NotFound("No NhanVat found");
            }
            return Ok(_mapper.Map<NhanVatResponse>(result));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNhanVat([FromBody] NhanVatRequest NhanVatRequest)
        {
            if (NhanVatRequest == null)
            {
                return BadRequest();
            }
            _NhanVatService.CreateNhanVat(NhanVatRequest);
            return Ok("Add Succed!!!");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateNhanVat(string ID, [FromBody] NhanVatRequest NhanVatRequest)
        {
            if (NhanVatRequest == null)
            {
                return BadRequest();
            }
            _NhanVatService.UpdateNhanVat(ID, NhanVatRequest);
            return Ok("Update Succed!!!");
        }
        [HttpPut("delete")]
        public async Task<IActionResult> DeleteNhanVat(string ID)
        {
            if (ID == null)
            {
                return BadRequest();
            }
            _NhanVatService.DeleteNhanVat(ID);
            return Ok("Delete Succed!!!");
        }


    }
}
