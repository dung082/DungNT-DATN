using BackEndApi.Dto;
using BackEndApi.Interface.IRepository;
using BackEndData.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NamHocController
    {
        private readonly ILogger<NamHocController> _logger;
        public INamHocRepository _iNamHocRepository { get; set; }
        public NamHocController(ILogger<NamHocController> logger, INamHocRepository iNamHocRepository)
        {
            _logger = logger;
            _iNamHocRepository = iNamHocRepository;
        }

        [HttpPost]
        [Route("ThemNamHoc")]
        public IActionResult ThemNamHoc([FromBody] NamHocDto namHocDto)
        {
            return _iNamHocRepository.ThemNamHoc(namHocDto);
        }

        [HttpGet]
        [Route("LayTatCaNamHoc")]
        public Task<ActionResult<List<NamHoc>>> LayTatCaNamHoc()
        {
            return _iNamHocRepository.LayTatCaNamHoc();
        }
    }
}
