using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndApi.Repository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChiTietLopHocController : ControllerBase
    {
        private readonly ILogger<ChiTietLopHocController> _logger;
        public IChiTietLopHocRepository _iChiTietLopHocRepository { get; set; }
        public ChiTietLopHocController(ILogger<ChiTietLopHocController> logger, IChiTietLopHocRepository iChiTietLopHocRepository)
        {
            _logger = logger;
            _iChiTietLopHocRepository = iChiTietLopHocRepository;
        }

        [HttpPost]
        [Route("ThemHocSinhVaoLop")]
        public IActionResult ThemHocSinhVaoLop([FromBody] ChiTietLopHocDto chiTietLopHocDto)
        {
            return _iChiTietLopHocRepository.ThemHocSinhVaoLop(chiTietLopHocDto);
        }

        [HttpPost]
        [Route("ChuyenLop")]
        public IActionResult ChuyenLop([FromBody] ChiTietLopHocDto chiTietLopHocDto)
        {
            return _iChiTietLopHocRepository.ChuyenLop(chiTietLopHocDto);
        }

        [HttpGet]
        [Route("LayHocSinhTrongLop")]
        public async Task<ActionResult> LayHocSinhTrongLop(string username)
        {
            var hocSinh = await _iChiTietLopHocRepository.LayHocSinhTrongLop(username);
            return Ok(hocSinh);
        }


    }
}
