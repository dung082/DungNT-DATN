using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    public class DiemThiController : ControllerBase
    {
        private readonly ILogger<DiemThiController> _logger;
        public IDiemThiRepository _iDiemThiRepository { get; set; }

        public DiemThiController(ILogger<DiemThiController> logger, IDiemThiRepository iDiemThiRepository)
        {
            _logger = logger;
            _iDiemThiRepository = iDiemThiRepository;
        }

        [HttpGet]
        [Route("LayDiemThi")]
        public async Task<ActionResult> LayDiemThi(int type, string? username, Guid? lopId, Guid? kyThiId)
        {
            var result = await _iDiemThiRepository.LayDiemThi(type, username, lopId, kyThiId);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemDiemThi")]
        public  async Task<ActionResult> ThemDiemThi([FromBody] DiemThiDto diemThiDto)
        {
            var result =await _iDiemThiRepository.ThemDiemThi(diemThiDto);
            return Ok(result);
        }
    }
}
