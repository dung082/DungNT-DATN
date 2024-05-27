using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    public class KhoaHocController
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
        public IActionResult ThemKhoaHoc(KhoaHocDto khoaHocDto)
        {
            return _iKhoaHocRepository.ThemKhoaHoc(khoaHocDto);
        }

        [HttpGet]
        [Route("LayTatCaKhoaHoc")]
        public Task<ActionResult<List<KhoaHoc>>> LayTatCaKhoaHoc()
        {
            return _iKhoaHocRepository.LayTatCaKhoaHoc();
        }
    }
}
