using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonHocController : ControllerBase
    {
        private readonly ILogger<MonHocController> _logger;
        public IMonHocRepository _iMonHocRepository { get; set; }
        public MonHocController(ILogger<MonHocController> logger, IMonHocRepository iMonHocRepository)
        {
            _logger = logger;
            _iMonHocRepository = iMonHocRepository;
        }

        [HttpPost]
        [Route("ThemMonHoc")]
        public IActionResult ThemMonHoc(MonHocDto monHocDto)
        {
            return _iMonHocRepository.ThemMonHoc(monHocDto);
        }

        [HttpGet]
        [Route("LayTatCaMonHoc")]
        public async Task<ActionResult<List<KhoaHoc>>> LayTatCaMonHoc()
        {
            var listKhoaHoc = await _iMonHocRepository.LayTatCaMonHoc();
            return Ok(listKhoaHoc);
        }

        [HttpGet]
        [Route("LayMonHocTheoKhoi")]
        public async Task<ActionResult<List<MonHocTheoKhoiDto>>> LayMonHocTheoKhoi(Guid? KhoiId)
        {
            var listKhoaHoc = await _iMonHocRepository.LayMonHocTheoKhoi(KhoiId);
            return Ok(listKhoaHoc);
        }
    }
}
