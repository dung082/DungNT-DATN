using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThongBaoController : ControllerBase
    {
        private readonly ILogger<ThongBaoController> _logger;
        public IThongBaoRepository _iThongBaoRepository { get; set; }
        public ThongBaoController(ILogger<ThongBaoController> logger, IThongBaoRepository iThongBaoRepository)
        {
            _logger = logger;
            _iThongBaoRepository = iThongBaoRepository;
        }

        [HttpPost]
        [Route("ThemThongBao")]
        public async Task<ActionResult> ThemThongBao(ThongBaoDto thongBaoDto)
        {
            var tb = await _iThongBaoRepository.ThemThongBao(thongBaoDto);
            return Ok(tb);
        }

        [HttpPost]
        [Route("XoaThongBao")]
        public async Task<ActionResult> XoaThongBao(Guid thongBaoId)
        {
            var tb = await _iThongBaoRepository.XoaThongBao(thongBaoId);
            return Ok(tb);
        }

        [HttpPost]
        [Route("CapNhatTrangThai")]
        public async Task<ActionResult> CapNhatTrangThai(Guid thongBaoId)
        {
            var tb = await _iThongBaoRepository.CapNhatTrangThaiThongBao(thongBaoId);
            return Ok(tb);
        }

        [HttpPost]
        [Route("CapNhatTrangThaiListThongBao")]
        public async Task<ActionResult> CapNhatTrangThaiListThongBao(List<Guid> listTbId)
        {
            var tb = await _iThongBaoRepository.CapNhatTrangThaiListThongBao(listTbId);
            return Ok(tb);
        }

        [HttpGet]
        [Route("LayThongBao")]
        public async Task<ActionResult> LayThongBao(string username)
        {
            var tb = await _iThongBaoRepository.LayThongBao(username);
            return Ok(tb);
        }
    }
}
