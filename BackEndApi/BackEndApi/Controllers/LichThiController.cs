using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LichThiController : ControllerBase
    {
        private readonly ILogger<LichThiController> _logger;
        public ILichThiRepository _iLichThiRepository { get; set; }
        public LichThiController(ILogger<LichThiController> logger, ILichThiRepository iLichThiRepository)
        {
            _logger = logger;
            _iLichThiRepository = iLichThiRepository;
        }

        [HttpGet]
        [Route("LayLichThi")]
        public async Task<ActionResult> LayLichThi(DateTime? ngayThi, string username)
        {
            var result = await _iLichThiRepository.LayLichThi(ngayThi , username);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemLichThi")]
        public async Task<ActionResult> ThemLichThi(LichThiDto lichThiDto)
        {
            var result = await _iLichThiRepository.ThemLichThi(lichThiDto);
            return Ok(result);
        }
    }
}
