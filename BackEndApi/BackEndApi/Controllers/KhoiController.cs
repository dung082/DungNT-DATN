using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KhoiController : ControllerBase
    {
        private readonly ILogger<KhoiController> _logger;
        public IKhoiRepository _ikhoiRepository { get; set; }
        public KhoiController(ILogger<KhoiController> logger, IKhoiRepository ikhoiRepository)
        {
            _logger = logger;
            _ikhoiRepository = ikhoiRepository;
        }

        [HttpGet]
        [Route("LayTatCaKhoi")]
        public async Task<ActionResult<List<Khoi>>> LayTatCaKhoi()
        {
            var listKhoi = await _ikhoiRepository.LayTatCaKhoi();
            return Ok(listKhoi);
        }

        [HttpPost]
        [Route("ThemKhoi")]
        public IActionResult ThemKhoi(KhoiDto khoiDto)
        {
            return _ikhoiRepository.ThemKhoi(khoiDto);
        }

        [HttpPost]
        [Route("SuaKhoi")]
        public IActionResult SuaKhoi(Khoi khoi)
        {
            return _ikhoiRepository.SuaKhoi(khoi);
        }

        [HttpPost]
        [Route("XoaKhoi")]
        public IActionResult XoaKhoi(Guid id)
        {
            return _ikhoiRepository.XoaKhoi(id);
        }
    }
}
