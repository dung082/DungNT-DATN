using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KhoaHocController : ControllerBase
    {
        private readonly ILogger<KhoaHocController> _logger;
        public IKhoaHocRepository _iKhoaHocRepository { get; set; }
        public KhoaHocController(ILogger<KhoaHocController> logger, IKhoaHocRepository iKhoaHocRepository)
        {
            _logger = logger;
            _iKhoaHocRepository = iKhoaHocRepository;
        }

        [HttpPost]
        [Route("ThemKhoaHoc")]
        public IActionResult ThemKhoaHoc([FromBody] KhoaHocDto khoaHocDto)
        {
            return _iKhoaHocRepository.ThemKhoaHoc(khoaHocDto);
        }

        [HttpGet]
        [Route("LayTatCaKhoaHoc")]
        public async Task<ActionResult<List<KhoaHoc>>> LayTatCaKhoaHoc()
        {
            var listKhoaHoc = await  _iKhoaHocRepository.LayTatCaKhoaHoc();
            return Ok(listKhoaHoc);
        }
    }
}
