using AutoMapper;
using Game.Models.RequestModels;
using Game.Models.ResponseModels;
using Game.Services;
using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KyNangNhanVatController : ControllerBase
    {
        private readonly IKyNangNhanVatService _KyNangNhanVatService;
        private readonly IMapper _mapper;

        public KyNangNhanVatController(IKyNangNhanVatService KyNangNhanVatService, IMapper mapper)
        {
            _KyNangNhanVatService = KyNangNhanVatService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetKyNangNhanVats()
        {
            var result = await _KyNangNhanVatService.GetKyNangNhanVats();
            if (result == null)
            {
                return NotFound("No KyNangNhanVat found");
            }
            return Ok(_mapper.Map<List<KyNangNhanVatResponse>>(result));
        }

        [HttpGet("getByNhanVatId")]
        public async Task<IActionResult> GetKyNangNhanVatById(string KyNangNhanVatId)
        {
            var result = await _KyNangNhanVatService.GetKyNangNhanVatByKyNangID(KyNangNhanVatId);
            if (result == null)
            {
                return NotFound("No KyNangNhanVat found");
            }
            return Ok(_mapper.Map<KyNangNhanVatResponse>(result));
        }
        [HttpGet("getByKyNangId")]
        public async Task<IActionResult> GetKyNangNhanVatByKyNangId(string KyNangNhanVatId)
        {
            var result = await _KyNangNhanVatService.GetKyNangNhanVatByNhanVatID(KyNangNhanVatId);
            if (result == null)
            {
                return NotFound("No KyNangNhanVat found");
            }
            return Ok(_mapper.Map<KyNangNhanVatResponse>(result));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateKyNangNhanVat([FromBody] KyNangNhanVatRequest KyNangNhanVatRequest)
        {
            if (KyNangNhanVatRequest == null)
            {
                return BadRequest();
            }
            _KyNangNhanVatService.CreateKyNangNhanVat(KyNangNhanVatRequest);
            return Ok("Add Succed!!!");
        }
        [HttpPut("delete")]
        public async Task<IActionResult> DeleteKyNangNhanVat(string idNV,string idKN)
        {
            if (idKN == null || idNV==null)
            {
                return BadRequest();
            }
            _KyNangNhanVatService.DeleteKyNangNhanVat(idNV,idKN);
            return Ok("Delete Succed!!!");
        }



    }
}
