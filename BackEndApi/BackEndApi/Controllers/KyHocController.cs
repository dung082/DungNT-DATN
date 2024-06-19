using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KyHocController : ControllerBase
    {
        private readonly ILogger<CaHocController> _logger;
        public IKyHocRepository _iKyHocRepository { get; set; }

        public KyHocController(ILogger<CaHocController> logger, IKyHocRepository iKyHocRepository)
        {
            _logger = logger;
            _iKyHocRepository = iKyHocRepository;
        }

        [HttpGet]
        [Route("LayKyHocTheoNam")]
        public async Task<ActionResult> LayKyHocTheoNam(string? namHoc)
        {
            var result = await _iKyHocRepository.GetKyHocTheoNamHoc(namHoc);
            return Ok(result);
        }

        [HttpGet]
        [Route("LayTatCaKyHoc")]
        public async Task<ActionResult> LayTatCaKyHoc()
        {
            var result = await _iKyHocRepository.LayTatCaKyHoc();
            return Ok(result);
        }


        [HttpPost]
        [Route("ThemKyHoc")]
        public IActionResult ThemKyHoc(KyHocDto kyHocDto)
        {
            var result = _iKyHocRepository.ThemKyHoc(kyHocDto);
            return Ok(result);
        }
    }
}
