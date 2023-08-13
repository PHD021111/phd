using AutoMapper;
using Game.Models.RequestModels;
using Game.Models.ResponseModels;
using Game.Services;
using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KyNangController : ControllerBase
    {
        private readonly IKyNangService _KyNangService;
        private readonly IMapper _mapper;

        public KyNangController(IKyNangService KyNangService, IMapper mapper)
        {
            _KyNangService = KyNangService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetKyNangs()
        {
            var result = await _KyNangService.GetKyNangs();
            if (result == null)
            {
                return NotFound("No KyNang found");
            }
            return Ok(_mapper.Map<List<KyNangResponse>>(result));
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetKyNangById(string KyNangId)
        {
            var result = await _KyNangService.GetKyNang(KyNangId);
            if (result == null)
            {
                return NotFound("No KyNang found");
            }
            return Ok(_mapper.Map<KyNangResponse>(result));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateKyNang([FromBody] KyNangRequest KyNangRequest)
        {
            if (KyNangRequest == null)
            {
                return BadRequest();
            }
            _KyNangService.CreateKyNang(KyNangRequest);
            return Ok("Add Succed!!!");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateKyNang(string ID, [FromBody] KyNangRequest KyNangRequest)
        {
            if (KyNangRequest == null)
            {
                return BadRequest();
            }
            _KyNangService.UpdateKyNang(ID, KyNangRequest);
            return Ok("Update Succed!!!");
        }
        [HttpPut("delete")]
        public async Task<IActionResult> DeleteKyNang(string ID)
        {
            if (ID == null)
            {
                return BadRequest();
            }
            _KyNangService.DeleteKyNang(ID);
            return Ok("Delete Succed!!!");
        }


    }
}
