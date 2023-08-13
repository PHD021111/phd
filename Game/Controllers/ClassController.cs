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
    public class ClassController : ControllerBase
    {
        private readonly IClassService _ClassService;
        private readonly IMapper _mapper;

        public ClassController(IClassService ClassService, IMapper mapper)
        {
            _ClassService = ClassService;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetClasss()
        {
            var result = await _ClassService.GetClasss();
            if (result == null)
            {
                return NotFound("No Class found");
            }
            return Ok(_mapper.Map<List<ClassResponse>>(result));
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetClassById(string ClassId)
        {
            var result = await _ClassService.GetClass(ClassId);
            if (result == null)
            {
                return NotFound("No Class found");
            }
            return Ok(_mapper.Map<ClassResponse>(result));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClass([FromBody] ClassRequest ClassRequest)
        {
            if (ClassRequest == null)
            {
                return BadRequest();
            }
            _ClassService.CreateClass(ClassRequest);
            return Ok("Add Succed!!!");
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateClass(string ID, [FromBody] ClassRequest ClassRequest)
        {
            if (ClassRequest == null)
            {
                return BadRequest();
            }
            _ClassService.UpdateClass(ID, ClassRequest);
            return Ok("Update Succed!!!");
        }

        [HttpPut("delete")]
        public async Task<IActionResult> DeleteClass(string ID)
        {
            if (ID == null)
            {
                return BadRequest();
            }
            _ClassService.DeleteClass(ID);
            return Ok("Delete Succed!!!");
        }


    }
}
