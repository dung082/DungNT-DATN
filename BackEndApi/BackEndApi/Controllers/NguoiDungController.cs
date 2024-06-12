using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NguoiDungController : ControllerBase
    {
        private readonly ILogger<NguoiDungController> _logger;
        public INguoiDungRepository _iNguoiDungRepository { get; set; }

        public NguoiDungController(ILogger<NguoiDungController> logger, INguoiDungRepository iNguoiDungRepository)
        {
            _logger = logger;
            _iNguoiDungRepository = iNguoiDungRepository;
        }

        [HttpGet]
        [Route("LayTatCaNguoiDung")]
        public async Task<ActionResult<List<NguoiDung>>> LayTatCaNguoiDung()
        {
            var listLop = await _iNguoiDungRepository.LayTatCaNguoiDung();
            return Ok(listLop);
        }

        [HttpGet]
        [Route("LayNguoiDungTheoIdLop")]
        public async Task<ActionResult<List<NguoiDung>>> LayNguoiDungTheoIdLop(Guid idLop)
        {
            var listLop = await _iNguoiDungRepository.LayNguoiDungTheoIdLop(idLop);
            return Ok(listLop);
        }

        [HttpPost]
        [Route("ThemNguoiDung")]
        public IActionResult ThemNguoiDung([FromBody] NguoiDungDto nguoiDungDto)
        {
            var result = _iNguoiDungRepository.ThemNguoiDung(nguoiDungDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("SuaNguoiDung")]
        public IActionResult SuaNguoiDung([FromBody] NguoiDung nguoiDung)
        {
            var result = _iNguoiDungRepository.SuaNguoiDung(nguoiDung);
            return Ok(result);
        }

        [HttpPost]
        [Route("XoaNguoiDung")]
        public IActionResult XoaNguoiDung(Guid idNguoiDung)
        {
            var result = _iNguoiDungRepository.XoaNguoiDung(idNguoiDung);
            return Ok(result);
        }

        [HttpGet]
        [Route("LayThongTinTaiKhoanDangNhap")]
        public async Task<ActionResult<NguoiDung>> GetUserInfo(string username)
        {
            var nguoiDung = await _iNguoiDungRepository.LayThongTinTaiKhoanDangNhap(username);
            return Ok(nguoiDung);
        }

        [HttpGet]
        [Route("LayThongTinNguoiDung")]
        public IActionResult LayThongTinNguoiDung(Guid id)
        {
            var nguoiDung = _iNguoiDungRepository.LayThongTinNguoiDung(id);
            return Ok(nguoiDung);
        }

    }
}
