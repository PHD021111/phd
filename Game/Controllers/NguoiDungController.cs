using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Game.Services;

using Game.Models.RequestModels;
using NhanVatGame.Models.ResponseModels;

namespace Game.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungService _NguoiDungService;
        private readonly IMapper _mapper;

        public NguoiDungController(INguoiDungService NguoiDungService, IMapper mapper)
        {
            _NguoiDungService = NguoiDungService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetNguoiDungs()
        {
            var result = await _NguoiDungService.GetNguoiDungs();
            if (result == null)
            {
                return NotFound("No NguoiDung found");
            }
            return Ok(_mapper.Map<List<NguoiDungResponse>>(result));
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetNguoiDungById(string NguoiDungId)
        {
            var result = await _NguoiDungService.GetNguoiDung(NguoiDungId);
            if (result == null)
            {
                return NotFound("No NguoiDung found");
            }
            return Ok(_mapper.Map<NguoiDungResponse>(result));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNguoiDung([FromBody] NguoiDungRequest NguoiDungRequest)
        {
            if (NguoiDungRequest == null)
            {
                return BadRequest();
            }
             _NguoiDungService.CreateNguoiDung(NguoiDungRequest);
            return Ok("Add Succed!!!");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateNguoiDung(string ID,[FromBody] NguoiDungRequest NguoiDungRequest)
        {
            if (NguoiDungRequest == null)
            {
                return BadRequest();
            }
            _NguoiDungService.UpdateNguoiDung(ID,NguoiDungRequest);
            return Ok("Update Succed!!!");
        }
        [HttpPut("delete")]
        public async Task<IActionResult> DeleteNguoiDung(string ID)
        {
            if (ID == null)
            {
                return BadRequest();
            }
            _NguoiDungService.DeleteNguoiDung(ID);
            return Ok("Delete Succed!!!");
        }


    }
}
