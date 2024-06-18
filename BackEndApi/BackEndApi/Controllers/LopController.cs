using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LopController : ControllerBase
    {
        private readonly ILogger<LopController> _logger;
        public ILopRepository _ilopRepository { get; set; }

        public LopController(ILogger<LopController> logger, ILopRepository ilopRepository)
        {
            _logger = logger;
            _ilopRepository = ilopRepository;
        }

        [HttpGet]
        [Route("LayTatCaLop")]
        public async Task<ActionResult<List<Lop>>> LayTatCaLop()
        {
            var listLop = await _ilopRepository.LayTatCaLop();
            return Ok(listLop);
        }
        [HttpPost]
        [Route("ThemLop")]
        public async Task<ActionResult> ThemLop([FromBody] LopDto lopDto)
        {

            if (String.IsNullOrEmpty(lopDto.MaLop))
            {
                throw new Exception("Mã lớp không được để trống");
            }
            if (String.IsNullOrEmpty(lopDto.TenLop))
            {
                throw new Exception("Tên lớp không được để trống");
            }
            if (String.IsNullOrEmpty(lopDto.Khoi.ToString()))
            {
                throw new Exception("Tên lớp không được để trống");
            }
            var result = await _ilopRepository.ThemLop(lopDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("SuaLop")]
        public IActionResult SuaLop([FromBody] Lop lop)
        {
            return _ilopRepository.SuaLop(lop);
        }

        [HttpPost]
        [Route("XoaLop")]
        public IActionResult XoaLop(Guid id)
        {
            return _ilopRepository.XoaLop(id);
        }
    }
}
