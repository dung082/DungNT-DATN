using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiemDanhController : ControllerBase
    {
        private readonly ILogger<DiemDanhController> _logger;
        public IDiemDanhRepository _iDiemDanhRepository { get; set; }
        public DiemDanhController(ILogger<DiemDanhController> logger, IDiemDanhRepository iDiemDanhRepositoru)
        {
            _logger = logger;
            _iDiemDanhRepository = iDiemDanhRepositoru;
        }

        [HttpGet]
        [Route("LayDiemDanh")]
        public async Task<ActionResult> LayDiemDanh(DateTime? ngay, string username)
        {
            var result = await _iDiemDanhRepository.LayDanhSachDiemDanhTheoTuan(ngay, username);
            return Ok(result);
        }

        [HttpPost]
        [Route("ThemDiemDanh")]
        public async Task<ActionResult> ThemDiemDanh(DiemDanhDto diemDanhDto)
        {
            var result = await _iDiemDanhRepository.ThemDiemDanh(diemDanhDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("SuaDiemDanh")]
        public async Task<ActionResult> SuaDiemDanh(DiemDanh diemDanh)
        {
            var result = await _iDiemDanhRepository.SuaDiemDanh(diemDanh);
            return Ok(result);
        }

        [HttpPost]
        [Route("XoaDiemDanh")]
        public async Task<ActionResult> XoaDiemDanh(Guid diemDanhId)
        {
            var result = await _iDiemDanhRepository.XoaDiemDanh(diemDanhId);
            return Ok(result);
        }

        [HttpPost]
        [Route("DuyetDiemDanh")]
        public async Task<ActionResult> DuyetDiemDanh(Guid diemDanhId)
        {
            var result = await _iDiemDanhRepository.DuyetDiemDanh(diemDanhId);
            return Ok(result);
        }

        [HttpGet]
        [Route("LayLichDiemDanh")]
        public async Task<ActionResult> LayLichDiemDanh(int? type)
        {
            var result = await _iDiemDanhRepository.LayLichDiemDanh(type);
            return Ok(result);
        }
    }
}
