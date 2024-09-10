using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<ActionResult> LayDiemThi(int type, string? username, Guid? kyThiId, Guid? monThiId)
        {
            var result = await _iDiemThiRepository.LayDiemThi(type, username, kyThiId, monThiId);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemDiemThi")]
        public async Task<ActionResult> ThemDiemThi([FromBody] DiemThiDto diemThiDto)
        {
            var result = await _iDiemThiRepository.ThemDiemThi(diemThiDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemListDiemThi")]
        public async Task<ActionResult> ThemListDiemThi(ListDiemThiDto diemThiDto)
        {
            var result = await _iDiemThiRepository.ThemListDiemThi(diemThiDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("PhucKhaoDiemThi")]
        public async Task<ActionResult> PhucKhaoDiemThi(string username, string namHoc, Guid kyThiId, List<Guid> listMonThiId)
        {
            var result = await _iDiemThiRepository.PhucKhaoDiemThi(username, namHoc, kyThiId, listMonThiId);
            return Ok(result);
        }

        [HttpPost]
        [Route("SuaDiemThi")]
        public async Task<ActionResult> SuaDiemThi(int type, Guid diemThiId, decimal diem)
        {
            var result = await _iDiemThiRepository.SuaDiemThi(type, diemThiId, diem);
            return Ok(result);
        }

        [HttpGet]
        [Route("LayDiemThiTheoUser")]
        public async Task<ActionResult> LayDiemThiTheoUser(string username, Guid monThiId, Guid kyThiId)
        {
            var result = await _iDiemThiRepository.LayDiemThiTheoUser(username, monThiId, kyThiId);
            return Ok(result);
        }
    }
}
