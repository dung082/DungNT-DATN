using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KyThiController : ControllerBase
    {
        private readonly ILogger<KyThiController> _logger;
        public IKyThiRepository _iKyThiRepository { get; set; }
        public KyThiController(ILogger<KyThiController> logger, IKyThiRepository iKyThiRepository)
        {
            _logger = logger;
            _iKyThiRepository = iKyThiRepository;
        }
        [HttpGet]
        [Route("LayKyThiTheoNam")]
        public async Task<ActionResult<List<DanToc>>> LayKyThiTheoNam(string? namhoc)
        {
            var lstKyThi = await _iKyThiRepository.LayKyThiTheoNamHoc(namhoc);
            return Ok(lstKyThi);
        }

        [HttpPost]
        [Route("ThemKyThi")]
        public async Task<ActionResult> ThemKyThi([FromBody] KyThiDto kyThiDto)
        {
            return await _iKyThiRepository.ThemKyThi(kyThiDto);
        }
    }
}
