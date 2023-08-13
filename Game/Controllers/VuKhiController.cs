using AutoMapper;
using Game.Models.RequestModels;
using Game.Models.ResponseModels;
using Game.Services;
using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class VuKhiController : ControllerBase
        {
            private readonly IVuKhiService _VuKhiService;
            private readonly IMapper _mapper;

            public VuKhiController(IVuKhiService VuKhiService, IMapper mapper)
            {
                _VuKhiService = VuKhiService;
                _mapper = mapper;
            }

            [HttpGet("getAll")]
            public async Task<IActionResult> GetVuKhis()
            {
                var result = await _VuKhiService.GetVuKhis();
                if (result == null)
                {
                    return NotFound("No VuKhi found");
                }
                return Ok(_mapper.Map<List<VuKhiResponse>>(result));
            }

            [HttpGet("getById")]
            public async Task<IActionResult> GetVuKhiById(string VuKhiId)
            {
                var result = await _VuKhiService.GetVuKhi(VuKhiId);
                if (result == null)
                {
                    return NotFound("No VuKhi found");
                }
                return Ok(_mapper.Map<VuKhiResponse>(result));
            }

            [HttpPost("create")]
            public async Task<IActionResult> CreateVuKhi([FromBody] VuKhiRequest VuKhiRequest)
            {
                if (VuKhiRequest == null)
                {
                    return BadRequest();
                }
                _VuKhiService.CreateVuKhi(VuKhiRequest);
                return Ok("Add Succed!!!");
            }
            [HttpPut("update")]
            public async Task<IActionResult> UpdateVuKhi(string ID, [FromBody] VuKhiRequest VuKhiRequest)
            {
                if (VuKhiRequest == null)
                {
                    return BadRequest();
                }
                _VuKhiService.UpdateVuKhi(ID, VuKhiRequest);
                return Ok("Update Succed!!!");
            }
            [HttpPut("delete")]
            public async Task<IActionResult> DeleteVuKhi(string ID)
            {
                if (ID == null)
                {
                    return BadRequest();
                }
                _VuKhiService.DeleteVuKhi(ID);
                return Ok("Delete Succed!!!");
            }


    }
    }

